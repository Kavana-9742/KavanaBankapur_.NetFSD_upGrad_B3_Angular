import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Contact } from '../../models/contact.model';

@Component({
  standalone: true,
  selector: 'contact-list',
  imports: [CommonModule],
  templateUrl: './contact-list.html',
  styleUrls: ['./contact-list.css']
})
export class ContactList {

  contacts: Contact[] = [
    {
      contactId: 1,
      name: 'John Doe',
      email: 'john@example.com',
      phone: '9876543210',
      isActive: true
    },
    {
      contactId: 2,
      name: 'Alice Smith',
      email: 'alice@example.com',
      phone: '9123456780',
      isActive: false
    }
  ];
}