import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GamesService {

  url = `${environment.backEndUrl}/games`

  constructor(private http: HttpClient) { }

  getGames(offset: number, limit: number, searchValue?: string): Observable<any> {
    var params = new HttpParams()
    .set("offset", offset)
    .set("limit", limit);

    if(searchValue){
      params = params.set("search", searchValue);
    }

    return this.http.get<any>(this.url, {params});
  }

  getCoversForGames(games: any): Observable<any>{
    var params = new HttpParams()
    .set("limit", games.length);
    return this.http.post<any>(`${this.url}/covers`, games, {params});
  }

  getGameById(id: number): Observable<any> {
    return this.http.get<any>(`${this.url}/game/${id}`);
  }

  getGameScreenshotsByGameId(gameId: number): Observable<any> {
    return this.http.get<any>(`${this.url}/game/${gameId}/screenshots`);
  }

  getCoverByGameId(gameId: number): Observable<any> {
    return this.http.get<any>(`${this.url}/game/${gameId}/cover`);
  }

  getGameGenres(genres: any): Observable<any> {
    return this.http.post<any>(`${this.url}/genres`, genres);
  }

  getGamePlatforms(platforms: any): Observable<any> {
    return this.http.post<any>(`${this.url}/platforms`, platforms);
  }

  getGameCoverByIdFromList(coverId: number, gameCovers: any): string{
    var cover = gameCovers.filter((gc:any) => gc.id == coverId)[0];
    return cover.url.replace('t_thumb', "t_cover_big");
  }

  getFavoriteGamesByUserId(): Observable<any> {
    return this.http.get<any>(`${this.url}/favorites`);
  }

  addFavoriteGame(gameId: number): Observable<any> {
    var params = new HttpParams()
    .set("gameId", gameId);
    return this.http.post<any>(`${this.url}/favorites`, null, {params});
  }

  deleteGameFromFavorites(gameId: number): Observable<any> {
    var params = new HttpParams()
    .set("gameId", gameId);
    return this.http.delete<any>(`${this.url}/favorites`, {params});
  }
}
