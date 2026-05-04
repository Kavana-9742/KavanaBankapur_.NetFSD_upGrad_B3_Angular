import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../services/contact.service';

@Component({
  standalone: true,
  selector: 'add-contact',
  imports: [FormsModule],
  templateUrl: './add-contact.html'
})
export class AddContact {

  name = '';
  email = '';
  phone = '';
  idCounter = 3;

  constructor(private service: ContactService) {}

  add() {
    if (!this.name || !this.email || !this.phone) return;

    this.service.addContact({
      id: this.idCounter++,
      name: this.name,
      email: this.email,
      phone: this.phone
    });

    this.name = '';
    this.email = '';
    this.phone = '';
  }
}