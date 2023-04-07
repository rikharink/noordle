import {Component} from '@angular/core';
import {FormControl} from "@angular/forms";
import {NavigationExtras, Router} from "@angular/router";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  constructor(private router: Router) {
  }

  boardNumberControl = new FormControl(1);
  wordLengthControl = new FormControl(5);

  play() {
    const navigationExtras: NavigationExtras = {
      state: {
        'boardNumber': this.boardNumberControl.value,
        'wordLength': this.wordLengthControl.value
      }
    };
    this.router.navigate(['play'], navigationExtras);
  }
}
