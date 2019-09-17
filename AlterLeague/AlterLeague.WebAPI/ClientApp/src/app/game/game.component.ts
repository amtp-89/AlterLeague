import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-game-component',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css', '../app.component.css']
})
export class GameComponent {
  public games: Game[];

  constructor(private route: ActivatedRoute, private domSanitizer: DomSanitizer, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Game[]>(baseUrl + 'api/Game/GetAllGames').subscribe(result => {
      this.games = result;
    }, error => console.error(error));
  }
}

interface Game {
  gameId: number;
  location: string;
  price: number;
  pricePerPerson: any;
  time: any;
  winner: number;
  loser: number;
  result: string;
  played: boolean;
}
