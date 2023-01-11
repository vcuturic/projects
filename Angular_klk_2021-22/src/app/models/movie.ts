import { Actor } from "./actor";
import { UserRating } from "./userRating";

export interface Movie {
  _id: string,
  title: string,
  genres: string[],
  ratings: UserRating[],
  actors: Actor[]
}
