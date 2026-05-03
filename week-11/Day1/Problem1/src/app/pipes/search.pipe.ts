// src/app/pipes/search-filter.pipe.ts

import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchFilter',
  standalone: true,
  pure: false
})
export class SearchFilterPipe implements PipeTransform {

  transform(contacts: any[], searchText: string): any[] {

    if (!contacts || !searchText) return contacts;

    const term = searchText.toLowerCase();

    return contacts.filter(contact =>
      contact.name.toLowerCase().includes(term) ||
      contact.email.toLowerCase().includes(term)
    );
  }
}