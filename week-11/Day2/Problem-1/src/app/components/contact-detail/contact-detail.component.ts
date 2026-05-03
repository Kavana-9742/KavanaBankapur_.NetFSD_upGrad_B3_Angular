// src/app/components/contact-detail/contact-detail.component.ts

import { Component, Input, OnChanges } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.component.html',
  styleUrls: ['./contact-detail.component.css']
})
export class ContactDetailComponent implements OnChanges {

  @Input() contactId!: number;
  contact?: Contact;

  constructor(private contactService: ContactService) {}

  ngOnChanges() {
    this.contact = this.contactService.getContactById(this.contactId);
  }
}