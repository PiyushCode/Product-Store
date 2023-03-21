import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientService } from './shared/services/httpClient.Services';
import { ProductComponent } from './product/product.component';
import { AddProductComponent } from './add-product/add-product.component';
import { FormsModule } from '@angular/forms';
import { MatPaginatorModule } from '@angular/material/paginator';
import { LoginComponent } from './login/login.component';
import { LocalStorageService } from './shared/services/localstorage.service';
import { AuthGuard } from './shared/services/auth/auth.guard';
import { AuthInterceptor } from './shared/services/auth/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    ProductComponent,
    AddProductComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatTableModule,
    MatSortModule,
    MatDialogModule,
    FormsModule,
    MatPaginatorModule
  ],
  providers: [HttpClientService, LocalStorageService, AuthGuard, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
