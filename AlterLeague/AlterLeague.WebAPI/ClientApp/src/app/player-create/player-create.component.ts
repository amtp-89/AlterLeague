import { Component, OnInit, Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-player-component',
  templateUrl: './player-create.component.html',
  styleUrls: ['./player-create.component.css', '../app.component.css']
})
export class PlayerCreateComponent {

  public http: HttpClient;
  public baseUrl: string

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  onClickSubmit(data) {

    const params = new HttpParams()
      .set('name', data.name)
      .set('birth', data.birthdate)
      .set('photo', data.photo)
      .set('wins', '0')
      .set('ties', '0')
      .set('losses', '0');

    this.http.post(this.baseUrl + 'api/Player/InsertPlayer', { params: params });
  }

} 

class Player {
  name: string;
  birth: Date;
  photo: any;
  wins: number;
  ties: number;
  losses: number;
}
