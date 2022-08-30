import { Component, OnInit } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
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
  length = 120;
  pageSize = 12;
  pageIndex = 0;
  pageSizeOptions = [8, 12];
  showFirstLastButtons = false;
  loadingGames = false;
  searchValue = '';

  constructor(
      private router: Router,
      public gamesService: GamesService,
      private gameSharedService: GameSharedService
    ) { }

  handlePageEvent(event: PageEvent) {
    this.length = event.length;
    this.pageSize = event.pageSize;
    this.pageIndex = event.pageIndex;

    this.getGames(this.pageIndex * this.pageSize, this.pageSize, this.searchValue);
  }

  cancelSearch() {
    this.searchValue = "";
    this.getGames(this.pageIndex * this.pageSize, this.pageSize, this.searchValue);
  }

  searchGames() {
    this.getGames(this.pageIndex * this.pageSize, this.pageSize, this.searchValue);
  }

  ngOnInit(): void {
    this.getGames(this.pageIndex * this.pageSize, this.pageSize);
  }

  getGames(offset: number, limit: number, searchValue?: string) {
    this.loadingGames = true;
    this.gamesService.getGames(offset, limit, searchValue).subscribe({
      next: (res: any) => {
        if(res){
          this.games = res;
          this.getGameCovers();
        }
      },
      error: (err: any) => {
        console.error(err);
      },
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
          }
        },
        error: (err: any) => {
          console.error(err);
        },
        complete: () => {
          this.loadingGames = false;
        }
      })
    }
  }
}
