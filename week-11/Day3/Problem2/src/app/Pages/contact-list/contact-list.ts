import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  standalone: true,
  selector: 'contact-list',
  imports: [RouterLink],
  templateUrl: './contact-list.html'
})
export class ContactList {

  contacts = [
    { id: 1, name: 'John' },
    { id: 2, name: 'Alice' }
  ];
}