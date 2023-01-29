import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GameListComponent } from './games/components/game-list/game-list.component';
import { GenreListComponent } from './genres/components/genre-list/genre-list.component';

const routes: Routes = [
  {path: '', component: GameListComponent, pathMatch: 'full'},
  {path: 'genres', component: GenreListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
