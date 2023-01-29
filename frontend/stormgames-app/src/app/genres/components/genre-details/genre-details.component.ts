import { Component, Input } from '@angular/core';
import { IGenre } from '../../models/genre.model';
import { MatDialog } from '@angular/material/dialog';
import { GenreFormComponent } from '../genre-form/genre-form.component';
import { GenreService } from '../../services/genre.service';

@Component({
    selector: 'app-genre-details',
    templateUrl: './genre-details.component.html',
    styleUrls: ['./genre-details.component.scss'],
})
export class GenreDetailsComponent {
    @Input() genres: IGenre[] = [];
    genre = {} as IGenre;

    constructor(public dialog: MatDialog, public genreService: GenreService) {}

    openDialog(genre: IGenre): void {
        this.dialog.open(GenreFormComponent, {
            data: { id: genre.id, name: genre.name },
        });
    }

    deleteGenre(genre: IGenre) {
        if (genre.id) {
            this.genreService.deleteGenre(genre.id).subscribe((result) => {
                console.log('Registro removido com sucesso!');
                this.reloadCurrentPage();
            });
        }
    }

    reloadCurrentPage() {
        window.location.reload();
    }
}
