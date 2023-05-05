import {Component, HostListener, Input, OnInit} from '@angular/core';
import {GuessService} from "../guess.service";
import {GuessResponse} from "../api/models/guess-response";
import {LetterStatus} from "../api/models/letter-status";


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

    guessService.guessResponse.subscribe(response => {
      const matches= response.matches;
      if(matches && matches.length > 0) {
        const myMatches = matches[this.boardIndex];
        //TODO: handle
        if(!myMatches.letters) return;

        const currentGuess = this.guesses[this.currentAttempt];
        myMatches.letters.forEach((status, i) => {
          switch(status) {
            case LetterStatus.Correct:
              currentGuess[i].status = "green";
              break;
            case LetterStatus.IncorrectLocation:
              currentGuess[i].status = "yellow";
              break;
            case LetterStatus.Incorrect:
              currentGuess[i].status = "red";
              break;
          }
        });
        this.currentAttempt++;
      }

    });
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
