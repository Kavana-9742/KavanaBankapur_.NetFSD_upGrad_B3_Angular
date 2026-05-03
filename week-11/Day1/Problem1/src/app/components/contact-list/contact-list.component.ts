// src/app/components/contact-list/contact-list.component.ts

import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { PhoneFormatPipe } from '../../pipes/phone-format.pipe';
import { StatusPipe } from '../../pipes/status.pipe';
import { SearchFilterPipe } from '../../pipes/search.pipe';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    PhoneFormatPipe,
    StatusPipe,
    SearchFilterPipe
  ],
  templateUrl: './contact-list.component.html',
  styleUrls: ['./contact-list.component.css']
})
export class ContactListComponent {

  searchText = '';
  showLimit = 5;

  contacts = [
    { name: 'john doe', email: 'JOHN@MAIL.COM', phone: '9876543210', status: true },
    { name: 'jane smith', email: 'JANE@MAIL.COM', phone: '9123456780', status: false },
    { name: 'alice brown', email: 'ALICE@MAIL.COM', phone: '9988776655', status: true },
    { name: 'bob martin', email: 'BOB@MAIL.COM', phone: '9871234560', status: false },
    { name: 'charlie', email: 'CHARLIE@MAIL.COM', phone: '9998887776', status: true },
    { name: 'david', email: 'DAVID@MAIL.COM', phone: '8887776665', status: false },
    { name: 'emma', email: 'EMMA@MAIL.COM', phone: '7776665554', status: true },
    { name: 'frank', email: 'FRANK@MAIL.COM', phone: '6665554443', status: false },
    { name: 'grace', email: 'GRACE@MAIL.COM', phone: '5554443332', status: true },
    { name: 'harry', email: 'HARRY@MAIL.COM', phone: '4443332221', status: false }
  ];

  toggleStatus(contact: any) {
    contact.status = !contact.status;
  }

  showMore() {
    this.showLimit = this.contacts.length;
  }

  showLess() {
    this.showLimit = 5;
  }
}