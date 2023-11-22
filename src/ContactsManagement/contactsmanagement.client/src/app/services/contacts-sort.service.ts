import { Injectable, PipeTransform } from '@angular/core';

import { BehaviorSubject, Observable, of, Subject } from 'rxjs';

import { Contact } from '../dto/contact';
import { DecimalPipe } from '@angular/common';
import { debounceTime, delay, switchMap, tap } from 'rxjs/operators';
import { SortColumn, SortDirection } from '../directives/sorting.directive';
import { ContactsService } from './contacts.service';

interface SearchResult {
	contacts: Contact[];
	total: number;
}

interface State {
	page: number;
	pageSize: number;
	searchTerm: string;
	sortColumn: SortColumn;
	sortDirection: SortDirection;
}

const compare = (v1: string | number, v2: string | number) => (v1 < v2 ? -1 : v1 > v2 ? 1 : 0);

function sort(contacts: Contact[], column: SortColumn, direction: string): Contact[] {
	if (direction === '' || column === '') {
		return contacts;
	} else {
		return [...contacts].sort((a, b) => {
			const res = compare(a[column], b[column]);
			return direction === 'asc' ? res : -res;
		});
	}
}

function matches(contact: Contact, term: string, pipe: PipeTransform) {
	return (
		contact.firstName.toLowerCase().includes(term.toLowerCase()) ||
		contact.lastName.toLowerCase().includes(term.toLowerCase()) ||
		contact.email.toLowerCase().includes(term.toLocaleLowerCase())
	);
}

@Injectable({ providedIn: 'root' })
export class ContactsSortService {
	private _loading$ = new BehaviorSubject<boolean>(true);
	private _search$ = new Subject<void>();
	private _contacts$ = new BehaviorSubject<Contact[]>([]);
	private _total$ = new BehaviorSubject<number>(0);

	private _state: State = {
		page: 1,
		pageSize: 4,
		searchTerm: '',
		sortColumn: '',
		sortDirection: '',
	};

	constructor(private pipe: DecimalPipe, private contactsService: ContactsService) {
        this.reload();
        this._search$.next();
	}

    reload() {
        this.contactsService.getContacts().subscribe(contacts => {
            this._search$
        		.pipe(
				tap(() => this._loading$.next(true)),
				switchMap(() => this._search(contacts)),
				tap(() => this._loading$.next(false)),
			)
			.subscribe((result) => {
				this._contacts$.next(result.contacts);
				this._total$.next(result.total);
			});
            
            this._search$.next();
        });
    }

	get contacts$() {
		return this._contacts$.asObservable();
	}
	get total$() {
		return this._total$.asObservable();
	}
	get loading$() {
		return this._loading$.asObservable();
	}
	get page() {
		return this._state.page;
	}
	get pageSize() {
		return this._state.pageSize;
	}
	get searchTerm() {
		return this._state.searchTerm;
	}

	set page(page: number) {
		this._set({ page });
	}
	set pageSize(pageSize: number) {
		this._set({ pageSize });
	}
	set searchTerm(searchTerm: string) {
		this._set({ searchTerm });
	}
	set sortColumn(sortColumn: SortColumn) {
		this._set({ sortColumn });
	}
	set sortDirection(sortDirection: SortDirection) {
		this._set({ sortDirection });
	}

	private _set(patch: Partial<State>) {
		Object.assign(this._state, patch);
		this._search$.next();
	}

	private _search(contactsList: Contact[]): Observable<SearchResult> {
		const { sortColumn, sortDirection, pageSize, page, searchTerm } = this._state;

		let contacts = sort(contactsList, sortColumn, sortDirection);

		contacts = contacts.filter((country) => matches(country, searchTerm, this.pipe));
		const total = contacts.length;

		contacts = contacts.slice((page - 1) * pageSize, (page - 1) * pageSize + pageSize);
		return of({ contacts: contacts, total });
	}
}