import { Component, EventEmitter, Output } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClientService } from '../shared/services/httpClient.Services';

@Component({
    selector: 'add-product',
    templateUrl: './add-product.component.html',
    styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
    productName: string = '';
    categoryId: string = '';
    price: number | undefined;
    @Output() onSavSuccessfully = new EventEmitter<any>();

    constructor(private httpClientService: HttpClientService) { }

    saveProduct(form: NgForm) {
        var addProductRequest = {
            productName: form.value.productName,
            categoryId: form.value.categoryId,
            price: form.value.price
        }
        //We can store the api base uri in environment file
        this.httpClientService.postPatch('http://localhost:5199/api/Product/AddProduct', addProductRequest, '', 'post').subscribe({
            next: () => {
                this.notifySaveSuccessFully(true);
                alert("Product Added Successfully");
            },
            error: (err) => {
                alert("Error while adding product, please try again !!");
            }
        })
    }

    public notifySaveSuccessFully(saved: boolean): void {
        this.onSavSuccessfully.emit(saved);
    }
}
