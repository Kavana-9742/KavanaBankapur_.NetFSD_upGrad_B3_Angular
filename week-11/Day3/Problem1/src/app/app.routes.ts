import { Routes } from '@angular/router';
import { ContactList } from './Pages/contact-list/contact-list';
import { ContactForm } from './Pages/contact-form/contact-form';
import { ContactDetail } from './Pages/contact-detail/contact-detail';

export const routes: Routes = [
    { path: 'contacts', component: ContactList },
  { path: 'add', component: ContactForm },
  { path: 'edit/:id', component: ContactForm },
  { path: 'detail/:id', component: ContactDetail },
  { path: '', redirectTo: 'contacts', pathMatch: 'full' }
];
