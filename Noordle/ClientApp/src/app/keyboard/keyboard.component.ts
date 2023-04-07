import {Component, Input, OnInit} from '@angular/core';
import {GuessLetterStatus} from "../board/board.component";
@Component({
  selector: 'app-keyboard',
  templateUrl: './keyboard.component.html',
  styleUrls: ['./keyboard.component.css']
})
export class KeyboardComponent implements OnInit {
  @Input() boardNumber: number = 0;
  hints: Map<string, GuessLetterStatus>[] = [];

  keys = [...'qwertyuiopasdfghjkl⏎zxcvbnm⌫'];
  constructor() {}

  ngOnInit(): void {
    let m = new Map<string, GuessLetterStatus>();
    for(let key of this.keys.filter(k => k !== '⏎' && k !== '⌫')){
      m.set(key, 'none');
    }
    for(let i = 0; i < this.boardNumber; i++){
      this.hints.push(new Map(m.entries()));
    }
  }

}
