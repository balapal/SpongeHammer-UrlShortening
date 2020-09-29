import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ShortenedUrl } from '../shortened-url';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  model = new ShortenedUrl('', '');
  submitted = false;

  onSubmit(form: NgForm) {
    console.log('Your form data : ', form.value);
    this.submitted = true;
  }
}
