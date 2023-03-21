import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from '../model/product.model';
import { HttpClientService } from '../shared/services/httpClient.Services';
import {MatPaginator} from '@angular/material/paginator';

@Component({
  selector: 'product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  title = 'Assignment';
  display = "none";
  productRecords: Product[] = [];
  columnsToDisplay = ["productName", "categoryName", "image", "price", "rating"]
  dataSource = new MatTableDataSource<Product>(this.productRecords);
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  constructor(private httpClientService: HttpClientService, public dialog: MatDialog) {
    
   }

  ngOnInit(): void {

  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.getProducts();
  }

  getProducts() {
    this.httpClientService.get<Product[]>("http://localhost:5199/api/Product/GetProducts", '').subscribe({
      next: (productList: Product[]) => {
        this.dataSource.data = [];
        this.dataSource.data = productList;
      },
      error: (err) => {
        alert("An error occured, please try again !!");
      }
    })
  }

  openModal() {
    this.display = "block";
  }

  onCloseHandled() {
    this.display = "none";
  }

  refreshTable(event: any) {
    if (event) {
      this.getProducts();
      this.onCloseHandled();
    }
  }
}
