import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { AppConstants } from '../common/app.constants';
import { LoginData } from '../models/loginData';
import { RegisterData } from '../models/registerData';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    private cookie: CookieService,
    private constants: AppConstants
    ) { }

  url = `${this.constants.backendUrl}/auth`;

  registrujSe(registerData : RegisterData): Observable<any> {
    return this.http.post(`${this.url}/register`, registerData, {responseType: 'text'});
  }

  login(loginData : LoginData): Observable<any> {
    return this.http.post(`${this.url}/login`, loginData, {responseType: 'text'});
  }

  isAuthenticated() {
    if(this.cookie.get("token")){
      return true;
  }

    return false;
  }
}
