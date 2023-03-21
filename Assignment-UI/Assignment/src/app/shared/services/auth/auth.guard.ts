import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { LocalStorageService } from "../localstorage.service";

@Injectable({
    providedIn: 'root'
})

export class AuthGuard implements CanActivate{
    
    constructor(private router: Router, private localStorageService: LocalStorageService){}

    canActivate(
        next: ActivatedRouteSnapshot,
        state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean{
            let isUserAuthenticated = this.localStorageService.CheckTokensExists();
            if(isUserAuthenticated)
            {
                return true;
            }
            document.location.href = "http://localhost:4200/login";
            return false
        }
}