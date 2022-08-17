import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GamesService } from '../services/games.service';
import { GameSharedService } from '../services/shared/game-shared.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {

  games?: any;
  gameCovers?: any;

  constructor(
    private router: Router,
    public gamesService: GamesService,
    private gameSharedService: GameSharedService) { }

  ngOnInit(): void {

    // this.getGames();
  }

  getGames() {
    this.gamesService.getGames().subscribe({
      next: (res: any) => {
        if(res){
          this.games = res;
          this.getGameCovers();
        }
      },
      error: (err: any) => {
        console.error(err);
      }
    })
  }

  selectGame(game: any) {
    this.router.navigate(['/games/game/', game.id]);
  }

  getGameCovers(){
    if(this.games){
      this.gamesService.getCoversForGames(this.games).subscribe({
        next: (res: any) => {
          if(res){
            this.gameCovers = res;
            this.gameSharedService.updateGameCovers(this.gameCovers);
          }
        },
        error: (err: any) => {
          console.error(err);
        }
      })
    }
  }
}
