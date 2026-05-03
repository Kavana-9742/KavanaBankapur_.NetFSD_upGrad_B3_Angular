// src/app/components/contact-detail/contact-detail.ts

import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact';

@Component({
  selector: 'contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.html',
  styleUrls: ['./contact-detail.css']
})
export class ContactDetail {

  contact?: Contact;

  constructor(
    private route: ActivatedRoute,
    private service: ContactService
  ) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.contact = this.service.getContactById(id);
  }
}