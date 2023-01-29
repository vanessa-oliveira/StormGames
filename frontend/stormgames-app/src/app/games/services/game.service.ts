import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IGame } from '../models/game.model';

@Injectable({
    providedIn: 'root',
})
export class GameService {
    public url: string = 'https://localhost:44300/api/Game';

    constructor(private http: HttpClient) {}

    getAllGames(): Observable<IGame[]> {
        return this.http.get<IGame[]>(this.url + '/ListAllGames');
    }
    getGameById(id: number): Observable<IGame> {
        return this.http.get<IGame>(this.url + '/GetById/' +id);
    }

    insertGame(game: IGame): Observable<IGame> {
        return this.http.post<IGame>(this.url + '/InsertGame', game);
    }
    deleteGame(id: number): Observable<IGame> {
        return this.http.delete<IGame>(this.url + '/DeleteGame/' + id);
    }

    updateGame(game: IGame): Observable<IGame> {
        return this.http.put<IGame>(this.url + '/UpdateGame', game);
    }
}
