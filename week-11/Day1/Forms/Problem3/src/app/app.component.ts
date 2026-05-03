import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ContactReactive } from './Pages/contact-relative/contact-reactive';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ContactReactive],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Problem3';
}
