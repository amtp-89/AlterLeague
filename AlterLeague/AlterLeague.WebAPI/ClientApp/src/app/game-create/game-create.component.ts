import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-game-component',
  templateUrl: './game-create.component.html',
  styleUrls: ['./game-create.component.css', '../app.component.css']
})

export class GameCreateComponent {
  public players: Player[]; 

  constructor(private route: ActivatedRoute, private domSanitizer: DomSanitizer, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Player[]>(baseUrl + 'api/Player/GetAllPlayers').subscribe(result => {
      this.players = result;

      for (let entry of result) {
        let imagePath = this.domSanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,'
          + entry.photo);

        entry.photo = imagePath;
      }
    }, error => console.error(error));
  }
}

interface Player {
  playerId: number;
  name: string;
  age: number;
  photo: any;
  wins: number;
  ties: number;
  losses: number;
  total: number;
}
