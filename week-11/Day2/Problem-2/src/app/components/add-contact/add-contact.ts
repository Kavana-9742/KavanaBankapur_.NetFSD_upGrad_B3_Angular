// src/app/components/add-contact/add-contact.ts

import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

import { ContactService } from '../../services/contact.service';

@Component({
  selector: 'add-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-contact.html',
  styleUrls: ['./add-contact.css']
})
export class AddContact {

  name = '';
  email = '';
  phone = '';

  constructor(
    private service: ContactService,
    private router: Router
  ) {}

  add() {
    this.service.addContact({
      id: Date.now(),
      name: this.name,
      email: this.email,
      phone: this.phone
    });

    this.router.navigate(['/contacts']);
  }
}