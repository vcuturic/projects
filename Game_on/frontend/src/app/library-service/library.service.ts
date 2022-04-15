import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { Book } from './book';
import { Game } from './game'; 

const jwtHelper = new JwtHelperService()

@Injectable({
  providedIn: 'root'
})
export class LibraryService {

  constructor(private http: HttpClient, private cookie: CookieService) { }

  getGames(): Observable<Game[]>
  { 
    return this.http.get<Game[]>('http://localhost:5000/games'); 
  }
  getGame(id: any): Observable<Game>
  {
    return this.http.get<Game>('http://localhost:5000/games/game/'+id);
  }

  login(username: any, password: any): Observable<string>
  {
    return this.http.post<string>('http://localhost:5000/auth/login', {"email": username, "password": password});
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

}
