import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameComponent } from './game/game.component';
import { GamesComponent } from './games/games.component';
import { HomeComponent } from './home/home.component';
import { AuthGuardService } from './library-service/auth-guard.service';
import { NoAuthGuardService } from './library-service/no-auth-guard.service';
import { LoginComponent } from './login/login.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { UsersComponent } from './users/users.component';

const routes: Routes = [
  { path: 'games', component: HomeComponent,
    canActivate: [AuthGuardService], 
    // children: [
    //   {
    //     path: 'game/:id',
    //     component: GameComponent
        
    //   }
    // ]
  },
  {path: 'games/game/:id', component: GameComponent, canActivate: [AuthGuardService],},
  { path: 'users', component: UsersComponent,canActivate: [AuthGuardService],},
  { path: 'login', component: LoginComponent, canActivate: [NoAuthGuardService],},
  { path: '', redirectTo: '/games', pathMatch: 'full'},
  { path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
