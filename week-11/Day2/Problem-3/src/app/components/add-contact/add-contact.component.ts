import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-add-contact',
  imports: [FormsModule, CommonModule],
  templateUrl: './add-contact.component.html'
})
export class AddContactComponent {

  contact = {
    name: ''
  };

  save() {
    alert('Contact Saved: ' + this.contact.name);
  }
}