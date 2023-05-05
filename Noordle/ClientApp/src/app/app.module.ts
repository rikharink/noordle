import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ApiModule} from "./api/api.module";
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PlayComponent } from './play/play.component';
import { BoardComponent } from './board/board.component';
import { KeyboardComponent } from './keyboard/keyboard.component';
import {getBaseUrl} from "../main";

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PlayComponent,
    BoardComponent,
    KeyboardComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    ApiModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'play', component: PlayComponent, pathMatch: 'full'}
    ]),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
