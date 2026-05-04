import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Contact } from '../models/contact.model';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ContactService {

  private apiUrl = 'https://localhost:7143/api/contacts'; // 🔁 change if needed

  constructor(private http: HttpClient) {}

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>(this.apiUrl)
      .pipe(catchError(this.handleError));
  }

  getContactById(id: number): Observable<Contact> {
    return this.http.get<Contact>(`${this.apiUrl}/${id}`)
      .pipe(catchError(this.handleError));
  }

  addContact(contact: Contact): Observable<Contact> {
    return this.http.post<Contact>(this.apiUrl, contact)
      .pipe(catchError(this.handleError));
  }

  updateContact(contact: Contact): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${contact.contactId}`, contact)
      .pipe(catchError(this.handleError));
  }

  deleteContact(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`)
      .pipe(catchError(this.handleError));
  }

  private handleError(error: any) {
    console.error('API Error:', error);
    return throwError(() => error);
  }
}