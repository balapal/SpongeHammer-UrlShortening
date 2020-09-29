import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ShortenedUrl } from '../shortened-url';

import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { HttpErrorHandler, HandleError } from '../http-error-handler.service';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler
  ) {
    this.handleError = httpErrorHandler.createHandleError('HomeComponent');
  }

  model = new ShortenedUrl('', '', '');
  submitted = false;
  shortenedUrl = new ShortenedUrl('', '', '');

  onSubmit(form: NgForm) {
    console.log('Your form data : ', form.value);
    this.submitted = true;

    this.http.post<ShortenedUrl>('api/ShortenedUrl', form.value, httpOptions)
      .pipe(
        catchError(this.handleError('ShortenedUrl onSubmit', form.value))
      )
      .subscribe(shortUrl => this.shortenedUrl = shortUrl);
  }
}
