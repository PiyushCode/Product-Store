import { Component } from '@angular/core';
import { LocalStorageService } from './shared/services/localstorage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Assignment';

  constructor(private localStorageService: LocalStorageService){}

  logout(){
    this.localStorageService.ClearLocalStorage();
    document.location.href = "http://localhost:4200/login";
  }
}
