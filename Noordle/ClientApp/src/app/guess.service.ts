import {HostListener, Injectable} from '@angular/core';
import {debounceTime, fromEvent, map, Observable, Observer, Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class GuessService {
  private currentLetter = 0;
  private word = "";
  private guess: Subject<string> = new Subject<string>();
  private submission: Subject<any> = new Subject<any>();
  public currentWord: Observable<string> = this.guess.asObservable();
  public nextWord: Observable<any> = this.submission.asObservable();

  public wordLength: number = -1;

  constructor() {
    fromEvent<KeyboardEvent>(document, 'keydown').pipe(map(e => e.key)).subscribe(
      key => {
        if (key === "Enter" && this.currentLetter == this.wordLength) {
          this.currentLetter = 0;
          this.word = "";
          this.submission.next(1);
        } else if (key === "Backspace" && this.currentLetter > 0) {
          this.currentLetter--;
          this.word = this.word.substring(0, this.currentLetter);
          this.guess.next(this.word.padEnd(this.wordLength));
        } else if ( this.isLetter(key) && this.currentLetter < this.wordLength) {
          this.word += key;
          this.currentLetter++;
          this.guess.next(this.word.padEnd(this.wordLength));
        }
      }
    );
  }

   isLetter(str: string) {
    return str.length === 1 && str.match(/[a-z]/i);
  }
}
