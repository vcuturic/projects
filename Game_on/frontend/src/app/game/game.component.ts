import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LibraryService } from '../library-service/library.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {

  game: any;
  constructor(private liblary: LibraryService, private route: ActivatedRoute) { } 

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      console.log('PARAMS' + ' ' + params);
      console.log(params['id']);
      this.liblary.getGame(params['id']).subscribe(game => {
        console.log(game);
        this.game = game;
      })
    })
  }

}
