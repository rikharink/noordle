import {HostListener, Injectable} from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GuessService {
  wordLength = 0;
  currentAttempt = 0;
  currentLetter = 0;
  boardNumber = 0;

  constructor() { }

  submit() {
    this.currentAttempt++;
    this.currentLetter = 0;
  }

  @HostListener('document:keypress', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) {
    const key = event.key;
    if (this.currentLetter >= this.wordLength || this.currentAttempt >= 5 + this.boardNumber || key.length > 1 || key < 'A' || key > 'z') return;
    //this.guesses[this.currentAttempt][this.currentLetter].character = key;
    this.currentLetter++;
  }

  @HostListener('document:keydown', ['$event'])
  handleKeydownEvent(event: KeyboardEvent) {
    switch (event.key) {
      case 'Enter':
        if (this.currentLetter === this.wordLength) {
          this.submit();
        }
        break;
      case 'Backspace':
        if (this.currentLetter === 0) return;
        //this.guesses[this.currentAttempt][this.currentLetter - 1] = new GuessLetter();
        this.currentLetter--;
        break;
    }
  }
}
