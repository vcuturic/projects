import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameComponent } from './game/game.component';
import { GamesComponent } from './games/games.component';
import { AuthGuardService } from './services/auth-guard.service';
import { NoAuthGuardService } from './services/no-auth-guard.service';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { UsersComponent } from './users/users.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { FavoriteGamesComponent } from './home/components/favorite-games/favorite-games.component';

const routes: Routes = [
  { path: '',
    component: HomeComponent,
    canActivate: [AuthGuardService],
    children: [
      { path: 'games', component: GamesComponent, canActivate: [AuthGuardService],},
      { path: 'games/game/:id', component: GameComponent, canActivate: [AuthGuardService],},
      { path: 'favorites', component: FavoriteGamesComponent, canActivate: [AuthGuardService],},
    ]
  },
  { path: 'users', component: UsersComponent,canActivate: [AuthGuardService],},
  { path: 'login', component: LoginComponent, canActivate: [NoAuthGuardService],},
  { path: 'register', component: RegisterComponent, canActivate: [NoAuthGuardService],},
  { path: '', redirectTo: '/games', pathMatch: 'full'},
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
