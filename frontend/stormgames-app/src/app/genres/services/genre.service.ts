import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IGenre } from '../models/genre.model';

@Injectable({
  providedIn: 'root'
})
export class GenreService {
  protected url: string = 'https://localhost:44300/api/Genre';

  constructor(private http: HttpClient) { }

  getAllGenres(): Observable<IGenre[]> {
    return this.http.get<IGenre[]>(this.url + '/ListAllGenres');
  }

  insertGenre(genre: IGenre): Observable<IGenre> {
    return this.http.post<IGenre>(this.url + '/CreateGenre', genre);
  }

  updateGenre(genre: IGenre): Observable<IGenre> {
    return this.http.put<IGenre>(this.url + '/UpdateGenre', genre);
  }

  deleteGenre(id: number): Observable<number> {
    return this.http.delete<number>(this.url + '/DeleteGenre/' + id);
  }
}
