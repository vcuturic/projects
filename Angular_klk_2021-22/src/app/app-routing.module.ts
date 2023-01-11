import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PocetnaComponent } from './pocetna/pocetna.component';
import { ProfileComponent } from './profile/profile.component';
import { RegistracijaComponent } from './registracija/registracija.component';
import { AuthGuard } from './services/auth.guard';
import { NoAuthGuard } from './services/no-auth.guard';

const routes: Routes = [
  { path: '', redirectTo: '/pocetna', pathMatch: 'full'},
  { path: 'pocetna', component: PocetnaComponent,},
  { path: 'login', component: LoginComponent, canActivate: [NoAuthGuard],},
  { path: 'register', component: RegistracijaComponent, canActivate: [NoAuthGuard],},
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard],},
  { path: '**', component: PageNotFoundComponent,}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
