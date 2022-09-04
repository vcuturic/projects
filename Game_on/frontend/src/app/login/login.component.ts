import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  hidePassword = true;

  loginForm = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required])
  });

  constructor(
    private cookie: CookieService,
    private router: Router,
    private authService: AuthService
    ) { }

  ngOnInit(): void {
  }

  login()
  {
    this.authService.login(this.loginForm.value).subscribe(token=>{
      this.cookie.set("token", token);
      this.router.navigate(['/games'])
    })
  }
}
