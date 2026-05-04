import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ContactService } from '../../services/contact.service';
import { CommonModule } from '@angular/common';

@Component({
  standalone: true,
  selector: 'contact-form',
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './contact-form.html'
})
export class ContactForm implements OnInit {

  isEdit = false;
  id: number = 0;
  message = '';

  constructor(
    private fb: FormBuilder,
    private service: ContactService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  form = this.fb.group({
    contactId: [0],
    name: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    phone: ['', [Validators.required, Validators.minLength(10)]],
    isActive: [true]
  });

  get f() {
    return this.form.controls;
  }

  ngOnInit() {
    this.id = Number(this.route.snapshot.paramMap.get('id'));

    if (this.id) {
      this.isEdit = true;
      this.service.getContactById(this.id).subscribe(data => {
        this.form.patchValue(data);
      });
    }
  }

  submit() {
    if (this.form.invalid) return;

    if (this.isEdit) {
      this.service.updateContact(this.form.value as any).subscribe(() => {
        this.message = 'Updated successfully';
        this.router.navigate(['/contacts']);
      });
    } else {
      this.service.addContact(this.form.value as any).subscribe(() => {
        this.message = 'Added successfully';
        this.router.navigate(['/contacts']);
      });
    }
  }
}