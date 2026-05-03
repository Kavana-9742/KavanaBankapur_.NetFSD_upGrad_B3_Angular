import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'app-contact-list',
  imports: [RouterLink, CommonModule],
  templateUrl: './contact-list.component.html'
})
export class ContactListComponent {

  contacts = [
    { id: 1, name: 'John' },
    { id: 2, name: 'Alice' }
  ];
}