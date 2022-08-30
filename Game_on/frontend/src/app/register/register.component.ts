import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  hidePassword = true;

  registerForm = new FormGroup({
    name: new FormControl('', [Validators.required]),
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

  register() {
    this.authService.register(this.registerForm.value).subscribe(
    {
      next: (res: any) => {
        if(res) {
          this.login();
        }
      },
      error: (err: any) => {
        console.error(err);
      }
    });
  }

  login()
  {
    const loginInfo = {email: this.registerForm.value['email'], password: this.registerForm.value['password']};
    this.authService.login(loginInfo).subscribe(token=>{
      this.cookie.set("token", token);
      this.router.navigate(['/games'])
    })
  }
}
