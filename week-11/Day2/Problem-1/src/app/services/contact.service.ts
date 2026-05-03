// src/app/services/contact.service.ts

import { Injectable } from '@angular/core';
import { Contact } from '../models/contact.model';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  private contacts: Contact[] = [
    { id: 1, name: 'John Doe', email: 'john@mail.com', phone: '9876543210' },
    { id: 2, name: 'Jane Smith', email: 'jane@mail.com', phone: '9123456780' },
    { id: 3, name: 'Alice Brown', email: 'alice@mail.com', phone: '9988776655' }
  ];

  getContacts(): Contact[] {
    return this.contacts;
  }

  addContact(contact: Contact): void {
    this.contacts.push(contact);
  }

  getContactById(id: number): Contact | undefined {
    return this.contacts.find(c => c.id === id);
  }
}