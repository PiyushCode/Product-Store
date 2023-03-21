import { Injectable } from "@angular/core";


@Injectable({
    providedIn: 'root'
})

export class LocalStorageService{
    public accessToken: string = '';
    constructor(){}

    public SaveTokens(accessToken: string): void{
        localStorage.setItem("access_token", accessToken);
        this.accessToken = accessToken;
    }

    public CheckTokensExists(): boolean{
        let accessToken = localStorage.getItem("access_token");
        if(!accessToken){
            return false;
        }
        this.accessToken = accessToken;
        return true;
    }

    public GetAccessToken(): string{
        return this.accessToken;
    }

    public ClearLocalStorage(){
        localStorage.clear();
    }
}

