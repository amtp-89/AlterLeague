import { Component, Inject, Input } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: 'app-player-component',
  templateUrl: './player-profile.component.html',
  styleUrls: ['./player-profile.component.css']
})
export class PlayerProfileComponent {
  public player: Player;
  public playerId: string

  constructor(private route: ActivatedRoute, private domSanitizer: DomSanitizer, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.playerId = this.route.snapshot.params.playerId;

    const params = new HttpParams()
      .set('playerId', this.playerId);

    http.get<Player>(baseUrl + 'api/Player/GetPlayerById', { params: params }).subscribe(result => {
      this.player = result;

      let imagePath = this.domSanitizer.bypassSecurityTrustResourceUrl('data:image/jpg;base64,'
        + this.player.photo);

      this.player.photo = imagePath;
    }, error => console.error(error));
  }
}

interface Player {
  playerId: number;
  name: string;
  birth: string;
  age: number;
  photo: any;
  wins: number;
  ties: number;
  losses: number;
}
