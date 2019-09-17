import { Component, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-game-component',
  templateUrl: './game-info.component.html',
  styleUrls: ['./game-info.component.css']
})
export class GameInfoComponent {
  public game: Game;
  public gameId: string

  constructor(private route: ActivatedRoute, private domSanitizer: DomSanitizer, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.gameId = this.route.snapshot.params.gameId;

    const params = new HttpParams()
      .set('gameId', this.gameId);

    http.get<Game>(baseUrl + 'api/Game/GetGameById', { params: params }).subscribe(result => {
      this.game = result;
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
