import {Component, HostListener, Input, OnInit} from '@angular/core';
import {GuessService} from "../guess.service";


export type GuessLetterStatus = 'yellow' | 'red' | 'green' | 'none';

class GuessLetter {
  public constructor(private guessService: GuessService, character: string = '', status: GuessLetterStatus = 'none') {
    this.character = character;
    this.status = status;
  }

  public character: string;
  public status: GuessLetterStatus;
}

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {
  @Input() wordLength: number = -1;
  @Input() attempts: number = -1;
  @Input() currentAttempt: number = -1;

  guesses: GuessLetter[][] = [];

  constructor() {
  }

  ngOnInit(): void {
    for (let i = 0; i < this.attempts; i++) {
      let guess = new Array<GuessLetter>();
      for (let j = 0; j < this.wordLength; j++) {
        guess.push(new GuessLetter());
      }
      this.guesses.push(guess);
    }
  }
}
