import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GenreListComponent } from './components/genre-list/genre-list.component';
import { GenreDetailsComponent } from './components/genre-details/genre-details.component';
import {MatCardModule} from '@angular/material/card';
import {MatDialogModule} from '@angular/material/dialog';
import {MatFormFieldModule} from '@angular/material/form-field';
import { GenreFormComponent } from './components/genre-form/genre-form.component';
import { FormsModule } from '@angular/forms';
import {MatButtonModule} from '@angular/material/button';
import {MatCommonModule} from '@angular/material/core';
import {MatInputModule} from '@angular/material/input';
import {MatIconModule} from '@angular/material/icon';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    GenreListComponent,
    GenreDetailsComponent,
    GenreFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatCardModule,
    MatDialogModule,
    MatFormFieldModule,
    MatCommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule
  ],
  exports: [
    GenreListComponent,
    GenreFormComponent
  ]
})
export class GenresModule { }
