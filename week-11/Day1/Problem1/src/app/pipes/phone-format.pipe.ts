// src/app/pipes/phone-format.pipe.ts

import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phoneFormat',
  standalone: true
})
export class PhoneFormatPipe implements PipeTransform {
  transform(value: string): string {
    return value
      ? value.replace(/(\d{3})(\d{3})(\d{4})/, '$1-$2-$3')
      : '';
  }
}