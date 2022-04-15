import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { LibraryService } from '../library-service/library.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  username?: string;
  password?: string;
  constructor(private library: LibraryService, private cookie: CookieService, private router: Router) { }

  ngOnInit(): void {
  }

  login()
  {
    this.library.login(this.username, this.password).subscribe(token=>{
      console.log(token)
      this.cookie.set("token", token);
      
      this.router.navigate(['/games'])
    })
  }

}
