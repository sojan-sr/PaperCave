import { Component } from '@angular/core';
import { BookModel } from '../models/bookModel';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-book-search',
  templateUrl: './book-search.component.html',
  styleUrls: ['./book-search.component.css']
})
export class BookSearchComponent {
  book: BookModel;
  constructor(private httpClient: HttpClient) {
    this.book = {
      title: 'The Great Gatsby',
      authorName: 'F. Scott Fitzgerald',
      pageCount: 218,
      genre: 'Fiction'
    };
  }

  searchBookByName(name:string) {
    // Code to search for a book
    var result = this.httpClient.get<BookModel[]>('https://localhost:7241/api/Book/GetBookByName?name=' + name).subscribe(result => {this.book = result[0];});
  }
}
