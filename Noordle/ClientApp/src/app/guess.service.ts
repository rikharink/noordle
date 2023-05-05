import {HostListener, Injectable} from '@angular/core';
import {debounceTime, fromEvent, map, Observable, Observer, Subject} from "rxjs";
import {GuessResponse} from "./api/models/guess-response";
import {GameService} from "./api/services/game.service";

@Injectable({
  providedIn: 'root'
})
export class GuessService {
  private currentLetter = 0;
  private word = "";
  private guess: Subject<string> = new Subject<string>();
  public currentWord: Observable<string> = this.guess.asObservable();
  private submission: Subject<GuessResponse> = new Subject<GuessResponse>();
  public guessResponse: Observable<GuessResponse> = this.submission.asObservable();

  public gameId: string = "";
  public wordLength: number = -1;

  constructor(private gameService: GameService) {
    fromEvent<KeyboardEvent>(document, 'keydown').pipe(map(e => e.key)).subscribe(
      key => {
        if (key === "Enter") {
          if(this.currentLetter !== this.wordLength) {
            this.resetWord();
          }
          this.submit(this.word);
        } else if (key === "Backspace" && this.currentLetter > 0) {
          this.currentLetter--;
          this.word = this.word.substring(0, this.currentLetter);
          this.guess.next(this.word.padEnd(this.wordLength));
        } else if (this.isLetter(key) && this.currentLetter < this.wordLength) {
          this.word += key;
          this.currentLetter++;
          this.guess.next(this.word.padEnd(this.wordLength));
        }
      }
    );
  }

  resetWord() {
    this.currentLetter = 0;
    this.word = "";
  }

  submit(word: string) {
    this.gameService.gamePut$Json$Response({
      gameId: this.gameId,
      guess: word
    }).subscribe(response => {
      this.resetWord();
      if (response.ok && response.body.isValid) {
          this.submission.next(response.body);
      } else {
        this.guess.next(this.word.padEnd(this.wordLength));
      }
    })
  }

  isLetter(str: string) {
    return str.length === 1 && str.match(/[a-z]/i);
  }
}
