import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, throwError } from "rxjs";
import { Observable } from "rxjs/internal/Observable";
import { LocalStorageService } from "../localstorage.service";

@Injectable()

export class AuthInterceptor implements HttpInterceptor{
    constructor(private localStorageService: LocalStorageService){}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req = req.clone({
            setHeaders:{
                Authorization: `Bearer ${this.localStorageService.accessToken}`
            }
        });
        return next.handle(req).pipe(catchError(err=>{
            if(err.staus === 401){
                this.localStorageService.ClearLocalStorage();
                alert("Session Expired !!");
                document.location.href = "http://localhost:4200/login";
            }
            return throwError(err);
        }))
    }
}