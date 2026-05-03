import { Component } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Contact } from '../../models/contact.model';

@Component({
  standalone: true,
  selector: 'contact-reactive',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './contact-reactive.html',
  styleUrls: ['./contact-reactive.css']
})
export class ContactReactive {

  contacts: Contact[] = [];
  idCounter = 1;

  constructor(private fb: FormBuilder) {}

  contactForm = this.fb.group({
    name: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', [Validators.required, Validators.minLength(10)]],
    isActive: [true]
  });

  get f() {
    return this.contactForm.controls;
  }

  onSubmit() {
    if (this.contactForm.valid) {

      const newContact: Contact = {
        contactId: this.idCounter++,
        name: this.f.name.value!,
        email: this.f.email.value!,
        phone: this.f.phone.value!,
        isActive: this.f.isActive.value!
      };

      this.contacts.push(newContact);

      this.contactForm.reset({ isActive: true });
    }
  }
}