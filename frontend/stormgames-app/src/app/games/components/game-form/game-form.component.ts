import { Component, OnInit, Inject } from '@angular/core';
import {
    FormBuilder,
    FormGroup,
    FormControl,
    Validators,
} from '@angular/forms';
import { IGenre } from 'src/app/genres/models/genre.model';
import { GenreService } from 'src/app/genres/services/genre.service';
import { IGame } from '../../models/game.model';
import { GameService } from '../../services/game.service';
import { MatDialogRef } from '@angular/material/dialog';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
    selector: 'app-game-form',
    templateUrl: './game-form.component.html',
    styleUrls: ['./game-form.component.scss'],
})
export class GameFormComponent implements OnInit {
    public gameForm!: FormGroup;
    public genres: IGenre[] = [];
    public selectedGenres: IGenre[] = [];
    public selectedDate: string = '';

    constructor(
        private formBuilder: FormBuilder,
        private genreService: GenreService,
        private gameService: GameService,
        private dialogRef: MatDialogRef<GameFormComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any
    ) {}

    ngOnInit(): void {
        this.gameForm = this.formBuilder.group({
            title: new FormControl('', [Validators.required]),
            description: new FormControl('', [Validators.required]),
            releaseDate: new FormControl('', [Validators.required]),
            developer: new FormControl('', [Validators.required]),
            publisher: new FormControl('', [Validators.required]),
            genres: new FormControl('', [Validators.required]),
        });
        this.getAllGenres();
        if (this.data.action === 'update') {
            this.gameForm.patchValue({
                title: this.data.title,
                description: this.data.description,
                releaseDate: this.data.releaseDate,
                developer: this.data.developer,
                publisher: this.data.publisher,
                genres: this.data.genres,
            });
        }
    }

    getAllGenres() {
        this.genreService.getAllGenres().subscribe((genres: IGenre[]) => {
            this.genres = genres;
        });
    }

    insertGame() {
        const gf = this.gameForm.value;
        if(this.data === null){
            let game: IGame = {
                title: gf.title,
                description: gf.description,
                releaseDate: gf.releaseDate,
                developer: gf.developer,
                publisher: gf.publisher,
                genreIds: this.selectedGenres.map(({ id }) => id) as Array<number>,
            };
            this.gameService.insertGame(game).subscribe();
        }else {
            let updateGame: IGame = {
                id: this.data.id,
                title: gf.title,
                description: gf.description,
                releaseDate: gf.releaseDate,
                developer: gf.developer,
                publisher: gf.publisher,
                genreIds: this.selectedGenres.map(({ id }) => id) as Array<number>
            }
            this.gameService.updateGame(updateGame).subscribe();
        }
        
        
    }

    closeDialog(): void {
        this.dialogRef.close();
    }
}
