import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ang_klk2';

  constructor(
      public authService: AuthService,
      private router: Router,
      private cookie: CookieService
    ) { }

    navigateToHomePage() {
      this.router.navigate(['pocetna']);
    }

    navigateToLoginPage() {
      this.router.navigate(['login']);
    }

    navigateToRegisterPage() {
      this.router.navigate(['register']);
    }

    navigateToProfilePage() {
      this.router.navigate(['profile']);
    }

    odjava() {
      // 1# Kako nas sajt zna koji je korisnik prijavljen? _____________ => Token!!
      // 2# Autorizacija vs Autentikacija?
      // Autentikacija => Koji je to korisnik?
      // 3# Autorizacija => Kakav je to korisnik? (USER, ADMIN, POVLASCENI)
      this.cookie.delete("token");
      this.router.navigate(['login']);
    }
}
