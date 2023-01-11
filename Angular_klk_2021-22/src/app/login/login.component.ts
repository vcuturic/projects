import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { LoginData } from '../models/loginData';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email?: string;
  password?: string;

  constructor(private authService: AuthService, private cookie: CookieService, private router: Router) {}

  login() {
    const loginData: LoginData = {email: this.email!, password: this.password!};

    this.authService.login(loginData).subscribe({
      next: (res: any) => {
        if(res){
          console.log(res);
          this.cookie.set("token", res);
          this.router.navigate(['profile']);
        }
      },
      error: (err: any) => {
        console.error(err);
      }
    });
  }
}
