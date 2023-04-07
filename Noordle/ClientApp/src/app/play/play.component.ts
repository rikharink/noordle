import {ChangeDetectorRef, Component, HostListener, OnInit} from '@angular/core';
import {Router, NavigationStart} from "@angular/router";
import {filter} from "rxjs";
import {BoardComponent} from "../board/board.component";
import {GuessService} from "../guess.service";

@Component({
  selector: 'app-play',
  templateUrl: './play.component.html',
  styleUrls: ['./play.component.css']
})
export class PlayComponent implements OnInit {
  wordLength: number;
  boardNumber: number;


  constructor(private router: Router) {
    this.wordLength = router.getCurrentNavigation()?.extras?.state?.wordLength ?? 5;
    this.boardNumber = router.getCurrentNavigation()?.extras?.state?.boardNumber ?? 1;
  }

  ngOnInit(): void {
  }
}
