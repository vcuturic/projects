import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  url: string = "https://localhost:7161/api/Users";
  user: User = { username: "test1", password: "password1" };

  constructor(private http: HttpClient) { }

  getCsvFile(): Observable<any>{
    const httpOptions = {
      // 'responseType'  : 'arraybuffer' as 'json'
       'responseType'  : 'blob' as 'json'        //This also worked
    };

    return this.http.get<any>(this.url, httpOptions);
  }

  login(): Observable<any>{
    return this.http.post(this.url, this.user);
  }
}
