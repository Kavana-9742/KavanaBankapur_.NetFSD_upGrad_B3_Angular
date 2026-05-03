// src/app/components/contact-list/contact-list.ts

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';

@Component({
  selector: 'contact-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './contact-list.html',
  styleUrls: ['./contact-list.css']
})
export class ContactList {

  contacts: Contact[] = [];

  constructor(private service: ContactService) {
    this.contacts = this.service.getContacts();
  }
}