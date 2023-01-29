import { Component, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import {
    FormBuilder,
    FormGroup,
    FormControl,
    Validators,
} from '@angular/forms';
import { GenreService } from '../../services/genre.service';
import { IGenre } from '../../models/genre.model';

@Component({
    selector: 'app-genre-form',
    templateUrl: './genre-form.component.html',
    styleUrls: ['./genre-form.component.scss'],
    encapsulation: ViewEncapsulation.None,
})
export class GenreFormComponent implements OnInit {
    genreForm!: FormGroup;
    public id: number = 0;
    public name: string = '';

    constructor(
        public dialogRef: MatDialogRef<GenreFormComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private genreService: GenreService,
        private formBuilder: FormBuilder
    ) {}

    ngOnInit(): void {
        this.genreForm = this.formBuilder.group({
            name: new FormControl('', [Validators.required]),
        });
    }

    clearNameInput() {
        this.genreForm.get('name')?.reset();
    }

    insertGenre() {
        const gf = this.genreForm.value;

        if (this.data === null) {
            let genre: IGenre = {
                name: gf.name,
            };
            this.genreService
                .insertGenre(genre).subscribe(result => console.log('Registro efetuado com sucesso!'));
        } else {
            let genreUpdate: IGenre = {
                id: this.data.id,
                name: gf.name,
            };
            this.genreService.updateGenre(genreUpdate).subscribe(result => console.log('Result' + result));
        }
    }

    onCancel(): void {
        this.dialogRef.close();
    }
}
