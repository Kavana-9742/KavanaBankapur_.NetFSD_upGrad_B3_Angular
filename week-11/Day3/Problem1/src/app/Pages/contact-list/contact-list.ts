import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { Contact } from '../../models/contact.model';

@Component({
  standalone: true,
  selector: 'contact-list',
  imports: [CommonModule, RouterLink],
  templateUrl: './contact-list.html'
})
export class ContactList implements OnInit {

  contacts: Contact[] = [];
  error = '';
  loading = true;

  constructor(private service: ContactService) {}

  ngOnInit() {
    this.loadContacts();
  }

  loadContacts() {
    this.service.getContacts().subscribe({
      next: data => {
        this.contacts = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load contacts';
        this.loading = false;
      }
    });
  }

  delete(id: number) {
    this.service.deleteContact(id).subscribe(() => {
      this.loadContacts();
    });
  }
}