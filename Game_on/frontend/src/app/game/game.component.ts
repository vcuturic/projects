import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GamesService } from '../services/games.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  game: any;
  gameScreenshots: any;
  gameScreenshotsUrls: string[] = [];
  gameCoverUrl?: string;

  constructor(
    private route: ActivatedRoute,
    public gamesService: GamesService,
    ) { }

  ngOnInit(): void {
    var gameId = this.route.snapshot.params['id'];

    // this.getGameById(gameId);
    // this.getGameScreenshotsByGameId(gameId);
    // this.getCoverByGameId(gameId);
  }

  getGameById(gameId: number){
    this.gamesService.getGameById(gameId).subscribe({
      next: (res: any) => {
        if(res){
          this.game = res;
        }
      },
      error: (err: any) => {
        console.error(err);
      }
    });
  }

  getGameScreenshotsByGameId(gameId: number){
    this.gamesService.getGameScreenshotsByGameId(gameId).subscribe({
      next: (res: any) => {
        if(res) {
          this.gameScreenshots = res;

          this.gameScreenshots.forEach((ss: any) => {
            this.gameScreenshotsUrls.push(ss.url);
          });
        }
      },
      error: (err: any) => {
        console.error(err);
      }
    })
  }

  getCoverByGameId(gameId: number) {
    this.gamesService.getCoverByGameId(gameId).subscribe({
      next: (res: any) => {
        this.gameCoverUrl = res.url;
      },
      error: (err: any) => {
        console.error(err);
      }
    })
  }

  getBanerImage(): string {
    return this.gameScreenshotsUrls[3].replace('t_thumb', 't_screenshot_big');
  }

  getCover(): string {
    return this.gameCoverUrl?.replace('t_thumb', 't_cover_big')!;
  }
}
