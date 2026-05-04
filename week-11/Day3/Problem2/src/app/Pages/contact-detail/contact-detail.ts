import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  standalone: true,
  selector: 'contact-detail',
  templateUrl: './contact-detail.html'
})
export class ContactDetail {

  id: any;

  constructor(route: ActivatedRoute) {
    this.id = route.snapshot.paramMap.get('id');
  }
}