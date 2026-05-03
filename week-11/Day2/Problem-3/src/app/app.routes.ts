import { Routes } from '@angular/router';
import { ContactListComponent } from './components/contact-list/contact-list.component';
import { AddContactComponent } from './components/add-contact/add-contact.component';
import { ContactDetailComponent } from './components/contact-detail/contact-detail.component';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'contacts', component: ContactListComponent },

  { 
    path: 'add-contact', 
    component: AddContactComponent,
    canActivate: [authGuard]
  },

  { 
    path: 'contact/:id', 
    component: ContactDetailComponent,
    canActivate: [authGuard]
  },

  { path: '', redirectTo: 'contacts', pathMatch: 'full' }
];