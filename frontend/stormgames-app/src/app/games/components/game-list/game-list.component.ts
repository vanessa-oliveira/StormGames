import { Component, OnInit } from '@angular/core';
import { IGame } from '../../models/game.model';
import { GameService } from '../../services/game.service';
import { MatDialog } from '@angular/material/dialog';
import { GameFormComponent } from '../game-form/game-form.component';

@Component({
    selector: 'app-game-list',
    templateUrl: './game-list.component.html',
    styleUrls: ['./game-list.component.scss'],
})
export class GameListComponent implements OnInit {
    public games: IGame[] = [];
    public action: string = 'insert';

    constructor(private gameService: GameService, private dialog: MatDialog) {}

    ngOnInit(): void {
        this.listAllGames();
    }

    listAllGames() {
        this.gameService.getAllGames().subscribe((games: IGame[]) => {
            this.games = games;
        });
    }

    openIsertForm(): void {
        this.dialog.open(GameFormComponent, {
            data: {
                action: this.action
            }
        });
    }
}
