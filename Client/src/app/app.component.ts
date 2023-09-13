import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Client';
  products: any[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.http.get('http://localhost:5002/api/products?pageSize=50').subscribe({
      next: (response: any) => this.products = response.data,
      error: error => console.log(error),
      complete: () => console.log('complete')
    })
  }
}
