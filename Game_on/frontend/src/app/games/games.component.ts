import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LibraryService } from '../library-service/library.service';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css']
})
export class GamesComponent implements OnInit {

  games?: any;
  constructor(private library: LibraryService, private router: Router) { }

  ngOnInit(): void {
    this.library.getGames().subscribe(games =>{
      console.log(games);
      this.games = games;
    })
  }
  selectGame(game: any) {
    console.log("KLIKNUO" + game._id)
    this.router.navigate(['/games/game/', game._id]);
  }

}
