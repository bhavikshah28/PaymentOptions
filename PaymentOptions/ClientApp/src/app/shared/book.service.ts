import { Injectable } from '@angular/core';
import { Book } from './book.model';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class BookService {

  formData: Book = new Book();
  readonly baseURL = "https://localhost:44349/api/Book";
  list: Book[];
  token: string;


  constructor(private http: HttpClient) { }

  refreshList() {
    this.http.get(this.baseURL).toPromise().then(res => this.list = res as Book[]);

  }

  getToken() {
    this.http.get(`${this.baseURL}/token`).toPromise().then(res => this.token = res as string);
  }
}
