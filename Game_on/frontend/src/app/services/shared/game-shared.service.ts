import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GameSharedService {

  gameCovers = new Subject<any>();

  $gameCovers = this.gameCovers.asObservable();

  constructor() { }

  updateGameCovers(gameCovers: any){
    this.gameCovers.next(gameCovers);
  }
}
