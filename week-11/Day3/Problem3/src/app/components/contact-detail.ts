import { Component, Input } from '@angular/core';
import { ContactService } from '../services/contact.service';
import { CommonModule } from '@angular/common';
import { Contact } from '../models/contact.model';

@Component({
  standalone: true,
  selector: 'contact-detail',
  imports: [CommonModule],
  templateUrl: './contact-detail.html'
})
export class ContactDetail {

  @Input() id!: number;
  contact: any;

  constructor(private service: ContactService) {}

  ngOnChanges() {
    this.contact = this.service.getContactById(this.id);
  }
}