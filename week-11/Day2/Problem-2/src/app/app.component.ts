import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  template: `
    <h1>Contact App</h1>

    <a routerLink="/contacts">Contacts</a> |
    <a routerLink="/add-contact">Add</a>

    <hr>

    <router-outlet></router-outlet>
  `
})
export class AppComponent {
  title = 'Problem2';
}
