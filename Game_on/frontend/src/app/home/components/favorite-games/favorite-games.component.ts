import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { GamesService } from 'src/app/services/games.service';

@Component({
  selector: 'app-favorite-games',
  templateUrl: './favorite-games.component.html',
  styleUrls: ['./favorite-games.component.scss']
})
export class FavoriteGamesComponent implements OnInit {

  displayedColumns: string[] = ['gameId', 'userId', 'deleteButton'];
  favoriteGames: any = [];

  constructor(
    private gamesService: GamesService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.getFavoriteGames();
  }

  getFavoriteGames() {
    this.gamesService.getFavoriteGamesByUserId().subscribe({
      next: (res: any) => {
        if(res) {
          this.favoriteGames = res;
        }
      },
      error: (err: any) => {
        console.error(err);
      }
    })
  }

  selectGame(gameId: number) {
    this.router.navigate(['/games/game/', gameId]);
  }

  deleteGame(gameId: number) {
    this.gamesService.deleteGameFromFavorites(gameId).subscribe({
      next: (res: any) => {
        if(res){
          console.log("Successfully deleted game from favorites.");
        }
      },
      error: (err: any) => {
        console.error(err);
      },
      complete: () => {
        this.getFavoriteGames();
      }
    })
  }
}
