import { Routes } from '@angular/router';
import { ContactList } from './Pages/contact-list/contact-list';
import { AddContact } from './Pages/add-contact/add-contact';
import { ContactDetail } from './Pages/contact-detail/contact-detail';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: 'contacts', component: ContactList }, // ✅ Public

  {
    path: 'add-contact',
    component: AddContact,
    canActivate: [authGuard] // 🔒 Protected
  },

  {
    path: 'contact/:id',
    component: ContactDetail,
    canActivate: [authGuard] // 🔒 Protected
  },

  { path: '', redirectTo: 'contacts', pathMatch: 'full' }
];