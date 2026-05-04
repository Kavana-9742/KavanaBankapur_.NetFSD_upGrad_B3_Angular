import { Injectable } from '@angular/core';
import { Contact } from '../models/contact.model';

@Injectable({ providedIn: 'root' })
export class ContactService {

  private contacts: Contact[] = [
    { id: 1, name: 'John', email: 'john@test.com', phone: '9999999999' },
    { id: 2, name: 'Alice', email: 'alice@test.com', phone: '8888888888' }
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