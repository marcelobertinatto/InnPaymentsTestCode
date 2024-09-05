import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlServicesService {

url: string = "https://localhost:7097/api/";

  constructor() { }

  getHeaders(): HttpHeaders {
    return new HttpHeaders({
      'Content-Type': 'application/json'
  });
}

  getUrl(): string {
    return this.url;
  }

}
