import { HomeComponent } from "./components/home/home.component";
import { EditContactComponent } from "./components/edit-contact/edit-contact.component";
import { NewContactComponent } from "./components/new-contact/new-contact.component";

import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'edit', component: EditContactComponent },
    { path: 'new', component: NewContactComponent }
];