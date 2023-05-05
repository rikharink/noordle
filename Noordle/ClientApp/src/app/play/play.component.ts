import {Component, OnInit} from '@angular/core';
import {Router} from "@angular/router";
import {GuessService} from "../guess.service";
import {GameService} from "../api/services/game.service";

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {
  public wordLength: number;
  public boardNumber: number;
  private readonly gameId: any;

  constructor(private router: Router, private guessService: GuessService, private gameService: GameService) {
    this.wordLength = router.getCurrentNavigation()?.extras?.state?.wordLength ?? 5;
    this.boardNumber = router.getCurrentNavigation()?.extras?.state?.boardNumber ?? 1;
    this.gameId = router.getCurrentNavigation()?.extras?.state?.gameId ?? "";
    guessService.wordLength = this.wordLength;
    guessService.gameId = this.gameId;
  }

  ngOnInit(): void {
    if (this.gameId === "") {
      this.router.navigate(['/']).catch(e => console.error(e));
    }
  }
}
