import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Contact } from '../models/contact.model';
import { ContactService } from '../services/contact.service';
import { ContactDetail } from './contact-detail';

@Component({
  standalone: true,
  selector: 'contact-list',
  imports: [CommonModule, ContactDetail],
  templateUrl: './contact-list.html'
})
export class ContactList {

  contacts : Contact[] = [];
  selectedId: number | null = null;

  constructor(private service: ContactService) {
    this.contacts = this.service.getContacts();
  }

  select(id: number) {
    this.selectedId = id;
  }
}