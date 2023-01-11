import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { RegisterData } from '../models/registerData';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-registracija',
  templateUrl: './registracija.component.html',
  styleUrls: ['./registracija.component.css']
})
export class RegistracijaComponent {
  name?: string; // nullable - moze da bude null vrednost
  email?: string;
  password?: string;

  constructor(
    private authService: AuthService,
    private cookie: CookieService,
    private router: Router) {}

  registrujSe() {
    const registerData: RegisterData = {name: this.name!, email: this.email!, password: this.password!};

    this.authService.registrujSe(registerData).subscribe({
      next: (res) => {
        if(res){
          console.log(res);
          this.cookie.set("token", res);
          this.router.navigate(['profile']);
        }
      },
      error: (err) => {
        console.error(err);
      }
    })
  }
}
