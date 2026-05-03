// src/app/services/contact.service.ts

import { Injectable } from '@angular/core';
import { Contact } from '../models/contact';

@Injectable({ providedIn: 'root' })
export class ContactService {

  private contacts: Contact[] = [
    { id: 1, name: 'John', email: 'john@mail.com', phone: '9876543210' },
    { id: 2, name: 'Jane', email: 'jane@mail.com', phone: '9123456780' }
  ];

  getContacts(): Contact[] {
    return this.contacts;
  }

  addContact(contact: Contact) {
    this.contacts.push(contact);
  }

  getContactById(id: number): Contact | undefined {
    return this.contacts.find(c => c.id === id);
  }
}