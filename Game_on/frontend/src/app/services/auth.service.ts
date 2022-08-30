import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

const jwtHelper = new JwtHelperService();

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  url = `${environment.backEndUrl}/auth`;

  constructor(
    private http: HttpClient,
    private cookie: CookieService,
    private router: Router
  ) { }

  login(loginInfo: any): Observable<any> {
    return this.http.post<any>(`${this.url}/login`, loginInfo);
  }

  register(registerInfo: any): Observable<any> {
    return this.http.post<any>(`${this.url}/register`, registerInfo);
  }

  isAuthenticated(): boolean
  {
    if (this.cookie.check('token'))
    {
      var token = this.cookie.get('token');
      return !jwtHelper.isTokenExpired(token);
    }
    return false;
  }

  logout() {
    this.cookie.delete('token');
    this.router.navigate(['login']);
  }
}
