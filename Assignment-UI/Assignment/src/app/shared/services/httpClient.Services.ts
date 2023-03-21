import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";



@Injectable({
    providedIn: 'root'
})
export class HttpClientService{
    constructor(private http: HttpClient){

    }


    get<returnType>(
        uri: string,
        id: string | undefined
    ): Observable<returnType>{
        return this.http.get(`${uri}${id ? '/' + id : ''}`) as Observable<returnType>;
    }

    
    postPatch<returnType>(
        uri: string,
        data: any,
        id: string,
        method: 'post' | 'patch' = 'post'
    ): Observable<returnType>{
        return this.http[method](`${uri}${id ? '/' + id : ''}`, data) as Observable<returnType>;
    }
}