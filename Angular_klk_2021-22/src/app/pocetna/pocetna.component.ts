import { Component, OnInit } from '@angular/core';
import { Actor } from '../models/actor';
import { Movie } from '../models/movie';
import { UserRating } from '../models/userRating';
import { AuthService } from '../services/auth.service';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-pocetna',
  templateUrl: './pocetna.component.html',
  styleUrls: ['./pocetna.component.css']
})
export class PocetnaComponent implements OnInit {
  movies?: Movie[];
  actors?: Actor[];
  movieRatings: number[] = [];

  constructor(
    private movieService: MoviesService,
    public authService: AuthService
  ) {}

  getMovies() {
    this.movieService.getMovies().subscribe({
      next: (res) => {
        if(res) {
          this.movies = res;
        }
      },
      error: (err) => {
        console.error(err);
      }
    })
  }

  selectMovie(movie: Movie) {
    this.actors = movie.actors;
  }

  rateMovie(movie: Movie, index: number) {
    if(this.movieRatings[index]) {
      const userRating: UserRating = {rating: this.movieRatings[index]};
      this.movieService.rateMovie(movie, userRating).subscribe({
        next: (res) => {
          if(res) {
            console.log("Uspesno ocenjen film!");
          }
        },
        error: (err) => {
          console.error(err);
        }
      })
    }
  }

  ngOnInit() {
    this.getMovies();
  }
}
