import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { HttpClientService } from '../shared/services/httpClient.Services';
import { LocalStorageService } from '../shared/services/localstorage.service';

@Component({
  selector: 'app-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
    username: string = '';
    password: string = '';

    constructor(private httpClientService: HttpClientService, private localStorageService: LocalStorageService) { }

    loginUser(form: NgForm){
        var loginRequest = {
            userName : form.value.username,
            password: form.value.password
        }
        this.httpClientService.postPatch('http://localhost:5199/api/Auth/login', loginRequest, '', 'post').subscribe({
            next: (response: any) => {
                if(response && response.token){
                    this.localStorageService.SaveTokens(response.token);
                    document.location.href = "http://localhost:4200/product";
                }
                else{
                    alert("Invalid credentails, please try again !!");    
                }
            },
            error: (err) => {
                alert("Invalid credentails, please try again !!");
            }
        })
    }
}