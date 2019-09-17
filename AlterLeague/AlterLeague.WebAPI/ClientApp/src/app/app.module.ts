import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PlayerComponent } from './player/player.component';
import { PlayerProfileComponent } from './player-profile/player-profile.component';
import { PlayerCreateComponent } from './player-create/player-create.component';
import { GameComponent } from './game/game.component';
import { GameInfoComponent } from './game-info/game-info.component';
import { GameCreateComponent } from './game-create/game-create.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PlayerComponent,
    PlayerProfileComponent,
    PlayerCreateComponent,
    GameComponent,
    GameInfoComponent,
    GameCreateComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'player', component: PlayerComponent },
      { path: 'player-profile/:playerId', component: PlayerProfileComponent },
      { path: 'player-create', component: PlayerCreateComponent },
      { path: 'game', component: GameComponent },
      { path: 'game-info/:gameId', component: GameInfoComponent },
      { path: 'game-create', component: GameCreateComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
