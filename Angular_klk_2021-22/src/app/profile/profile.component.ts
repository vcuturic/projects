import { Component, OnInit } from '@angular/core';
import { Movie } from '../models/movie';
import { UserRating } from '../models/userRating';
import { MoviesService } from '../services/movies.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit{

  myRatedMovies?: Movie[];

  constructor(
    private movieService: MoviesService,
  ) {}

  findMeanRating(movie: Movie) {
    let sum = 0;
    let ratingMean = 0;
    const listOfRatings = movie.ratings;

    listOfRatings!.forEach(ratingObj => {
      sum += ratingObj.rating;
    });

    ratingMean = sum / listOfRatings?.length!;

    return ratingMean;
  }

  getMoviesRatedbyMe() {
    this.movieService.getMoviesRatedByMe().subscribe({
      next: (res) => {
        if(res) {
          console.log(res);
          this.myRatedMovies = res;
        }
      },
      error: (err) => {
        console.error(err);
      }
    })
  }

  ngOnInit() {
    this.getMoviesRatedbyMe();
  }
}
