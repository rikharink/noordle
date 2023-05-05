import {Component, HostListener, Input, OnInit} from '@angular/core';
import {GuessService} from "../guess.service";


export type GuessLetterStatus = 'yellow' | 'red' | 'green' | 'none';

class GuessLetter {
  public constructor(character: string = '', status: GuessLetterStatus = 'none') {
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
  @Input() boardIndex: number = -1;
  @Input() wordLength: number = -1;
  @Input() attempts: number = -1;

  currentAttempt = 0;
  guesses: GuessLetter[][] = [];

  constructor(private guessService: GuessService) {
    guessService.currentWord.subscribe(word => {
      if(this.currentAttempt < this.attempts) {
        this.guesses[this.currentAttempt] = [...word].map(l => new GuessLetter(l));
      }
    });

    guessService.nextWord.subscribe(_ => {
      if(this.currentAttempt < this.attempts){
        this.currentAttempt++;
      }
    })
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
