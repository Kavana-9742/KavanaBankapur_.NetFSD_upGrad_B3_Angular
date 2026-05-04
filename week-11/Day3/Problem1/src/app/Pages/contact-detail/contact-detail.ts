import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'contact-detail',
  imports: [CommonModule],
  templateUrl: './contact-detail.html'
})
export class ContactDetail implements OnInit {

  contact: any;

  constructor(private route: ActivatedRoute, private service: ContactService) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.service.getContactById(id).subscribe(data => {
      this.contact = data;
    });
  }
}