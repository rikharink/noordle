import {Component} from '@angular/core';
import {FormControl} from "@angular/forms";
import {NavigationExtras, Router} from "@angular/router";
import {GameService} from "../api/services/game.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private router: Router, private gameService: GameService ) {
  }

  boardNumberControl = new FormControl(1);
  wordLengthControl = new FormControl(5);

  play() {

    this.gameService.gamePost$Json$Response({
      body: {
        boardCount: this.boardNumberControl.value ?? undefined,
        wordLength: this.wordLengthControl.value ?? undefined,
      }
    }).subscribe( response => {
      if(!response.ok){
        console.error(response);
      }

      console.log('start game with id', response.body.gameId);
      const navigationExtras: NavigationExtras = {
        state: {
          'gameId': response.body.gameId,
          'boardNumber': this.boardNumberControl.value,
          'wordLength': this.wordLengthControl.value
        }
      };
      this.router.navigate(['play'], navigationExtras);
    });

  }
}
