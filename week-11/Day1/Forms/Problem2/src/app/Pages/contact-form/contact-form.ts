import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Contact } from '../../models/contact.model';

@Component({
  standalone: true,
  selector: 'contact-form',
  imports: [FormsModule, CommonModule],
  templateUrl: './contact-form.html',
  styleUrls: ['./contact-form.css']
})
export class ContactForm {

  contacts: Contact[] = [];

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    isActive: true
  };

  idCounter = 1;

  onSubmit(form: any) {
    if (form.valid) {
      this.contact.contactId = this.idCounter++;

      this.contacts.push({ ...this.contact });

      form.reset();
      this.contact.isActive = true;
    }
  }
}