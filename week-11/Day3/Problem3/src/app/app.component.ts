import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { ContactList } from './components/contact-list';
import { ContactDetail } from './components/contact-detail';
import { AddContact } from './components/add-contact';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ContactList, ContactDetail, AddContact],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
}
