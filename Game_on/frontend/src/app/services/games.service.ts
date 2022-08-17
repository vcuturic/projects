import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GamesService {

  url = `${environment.backEndUrl}/games`

  constructor(private http: HttpClient) { }

  getGames(): Observable<any> {
    return this.http.get<any>(this.url);
  }

  getCoversForGames(games: any): Observable<any>{
    return this.http.post<any>(`${this.url}/covers`, games);
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

  getGameCoverByIdFromList(coverId: number, gameCovers: any): string{
    var cover = gameCovers.filter((gc:any) => gc.id == coverId)[0];
    return cover.url.replace('t_thumb', "t_cover_big");
  }
}
