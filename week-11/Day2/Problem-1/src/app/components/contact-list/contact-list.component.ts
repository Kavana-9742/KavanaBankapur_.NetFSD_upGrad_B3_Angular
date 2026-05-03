// src/app/components/contact-list/contact-list.component.ts

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';
import { ContactDetailComponent } from '../contact-detail/contact-detail.component';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, FormsModule, ContactDetailComponent],
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {

  contacts: Contact[] = [];
  selectedContactId: number | null = null;

  // Form fields
  newName = '';
  newEmail = '';
  newPhone = '';

  constructor(private contactService: ContactService) {
    this.contacts = this.contactService.getContacts();
  }

  addContact() {
    const newContact: Contact = {
      id: this.contacts.length + 1,
      name: this.newName,
      email: this.newEmail,
      phone: this.newPhone
    };

    this.contactService.addContact(newContact);

    // refresh list
    this.contacts = this.contactService.getContacts();

    // clear form
    this.newName = '';
    this.newEmail = '';
    this.newPhone = '';
  }

  viewDetails(id: number) {
    this.selectedContactId = id;
  }
}