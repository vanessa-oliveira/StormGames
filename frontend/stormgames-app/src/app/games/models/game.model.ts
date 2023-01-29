import { IGenre } from "src/app/genres/models/genre.model";

export interface IGame {
    id?: number;
    title: string;
    description: string;
    releaseDate: string;
    developer: string;
    publisher: string;
    genres?: IGenre[];
    genreIds?: Array<number>;
}
