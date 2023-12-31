import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HomeComponent } from './components/home/home.component';
import { NewContactComponent } from './components/new-contact/new-contact.component';
import { EditContactComponent } from './components/edit-contact/edit-contact.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { routes } from './app.routes';
import { RouterLink, RouterLinkActive, RouterOutlet, provideRouter } from '@angular/router';
import { CommonModule, DecimalPipe } from '@angular/common';
import { NgbdSortableHeader } from './directives/sorting.directive';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NewContactComponent,
    EditContactComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    CommonModule,
    RouterOutlet,
    RouterLink, 
    RouterLinkActive,
    FormsModule,
    ReactiveFormsModule,
    NgbdSortableHeader,
    DecimalPipe
  ],
  providers: [ provideRouter(routes), DecimalPipe ],
  bootstrap: [AppComponent]
})
export class AppModule { }
