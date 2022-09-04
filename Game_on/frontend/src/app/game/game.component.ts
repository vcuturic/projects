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
  gameGenres: any;
  gamePlatforms: any;
  gameInFavorites: boolean = false;

  constructor(
    private route: ActivatedRoute,
    public gamesService: GamesService,
    ) { }

  ngOnInit(): void {
    var gameId = this.route.snapshot.params['id'];

    this.getGameById(gameId);
    this.getGameScreenshotsByGameId(gameId);
    this.getCoverByGameId(gameId);
  }

  getGameById(gameId: number){
    this.gamesService.getGameById(gameId).subscribe({
      next: (res: any) => {
        if(res){
          this.game = res;
          this.getGameGenres();
          this.getGamePlatforms();
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

  getGameGenres() {
    this.gamesService.getGameGenres(this.game.genres).subscribe({
      next: (genres: any) => {
        this.gameGenres = genres.filter((g: any) => g.name);
      },
      error: (err: any) => {
        console.error(err);
      }
    })
  }

  getGamePlatforms() {
    this.gamesService.getGamePlatforms(this.game.platforms).subscribe({
      next: (platforms: any) => {
        this.gamePlatforms = platforms.filter((p: any) => p.name);
      },
      error: (err: any) => {
        console.error(err);
      }
    })
  }

  getBanerImage(): string {
    return this.gameScreenshotsUrls[0].replace('t_thumb', 't_screenshot_big');
  }

  getCover(): string {
    return this.gameCoverUrl?.replace('t_thumb', 't_cover_big')!;
  }

  getGenres(): string {
    var mappedArray = this.gameGenres.map((g: any) => g.name);
    return `${mappedArray.toString().replaceAll(',', ', ')}.`;
  }

  getPlatforms(): string {
    var mappedArray = this.gamePlatforms.map((p: any) => p.name);
    return `${mappedArray.toString().replaceAll(',', ', ')}.`;
  }

  ratingValidity(rating: any): number{
    return rating == null ? 1 : (rating == 0 ? 1 : rating);
  }

  ratingCountValidity(ratingCount: any): string {
    return ratingCount == null ? "N/A" : (ratingCount == 0 ? 1 : ratingCount);
  }

  addGameToFavorites(gameId: number) {
    this.gameInFavorites = true;
    this.gamesService.addFavoriteGame(gameId).subscribe({
      next: (res: any) => {
        if(res){
          console.log("Successfully added game to favorites.");
        }
      },
      error: (err: any) => {
        console.error(err);
      }
    })
  }

  removeGameFromFavorites(gameId: number) {
    this.gameInFavorites = false;
  }
}
