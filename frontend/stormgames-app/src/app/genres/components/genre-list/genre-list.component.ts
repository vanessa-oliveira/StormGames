import { Component, OnInit, Inject } from '@angular/core';
import { IGenre } from '../../models/genre.model';
import { GenreService } from '../../services/genre.service';
import { MatDialog } from '@angular/material/dialog';
import { GenreFormComponent } from '../genre-form/genre-form.component';

@Component({
    selector: 'app-genre-list',
    templateUrl: './genre-list.component.html',
    styleUrls: ['./genre-list.component.scss'],
})
export class GenreListComponent implements OnInit {
    public genres: IGenre[] = [];

    constructor(private genreService: GenreService, public dialog: MatDialog) {}

    ngOnInit(): void {
        this.getAllGenres();
    }

    getAllGenres() {
        this.genreService.getAllGenres().subscribe((genres: IGenre[]) => {
            this.genres = genres;
        });
        console.log(this.genres);
    }

    openDialog(): void {
        this.dialog.open(GenreFormComponent);
    }
}
