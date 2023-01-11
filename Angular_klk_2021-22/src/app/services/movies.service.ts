import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConstants } from '../common/app.constants';
import { Movie } from '../models/movie';
import { UserRating } from '../models/userRating';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor(
      private http: HttpClient,
      private constants: AppConstants
    ) { }

  url = `${this.constants.backendUrl}/movies`

  getMovies(): Observable<Movie[]> {
    return this.http.get<Movie[]>(this.url);
  }

  rateMovie(movie: Movie, rating: UserRating): Observable<any> {
    return this.http.post(`${this.url}/rate/${movie._id}`, rating);
  }

  getMoviesRatedByMe(): Observable<Movie[]> {
    return this.http.get<Movie[]>(`${this.constants.backendUrl}/rated`);
  }
}
