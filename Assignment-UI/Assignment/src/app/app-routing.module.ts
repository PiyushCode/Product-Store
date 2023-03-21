import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductComponent } from './product/product.component';
import { AuthGuard } from './shared/services/auth/auth.guard';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'product'},
  {path: 'product', component: ProductComponent, canActivate: [AuthGuard] },
  {path: 'login', component: LoginComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
