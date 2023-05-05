/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpContext } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { GuessResponse } from '../models/guess-response';
import { StartGameDto } from '../models/start-game-dto';
import { StartGameResponse } from '../models/start-game-response';

@Injectable({
  providedIn: 'root',
})
export class GameService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation gamePost
   */
  static readonly GamePostPath = '/api/Game';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `gamePost$Plain()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  gamePost$Plain$Response(params?: {
    body?: StartGameDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<StartGameResponse>> {

    const rb = new RequestBuilder(this.rootUrl, GameService.GamePostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<StartGameResponse>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `gamePost$Plain$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  gamePost$Plain(params?: {
    body?: StartGameDto
  },
  context?: HttpContext

): Observable<StartGameResponse> {

    return this.gamePost$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<StartGameResponse>) => r.body as StartGameResponse)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `gamePost$Json()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  gamePost$Json$Response(params?: {
    body?: StartGameDto
  },
  context?: HttpContext

): Observable<StrictHttpResponse<StartGameResponse>> {

    const rb = new RequestBuilder(this.rootUrl, GameService.GamePostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<StartGameResponse>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `gamePost$Json$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  gamePost$Json(params?: {
    body?: StartGameDto
  },
  context?: HttpContext

): Observable<StartGameResponse> {

    return this.gamePost$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<StartGameResponse>) => r.body as StartGameResponse)
    );
  }

  /**
   * Path part for operation gamePut
   */
  static readonly GamePutPath = '/api/Game/{gameId}/{guess}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `gamePut$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  gamePut$Plain$Response(params: {
    gameId: string;
    guess: string;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<GuessResponse>> {

    const rb = new RequestBuilder(this.rootUrl, GameService.GamePutPath, 'put');
    if (params) {
      rb.path('gameId', params.gameId, {});
      rb.path('guess', params.guess, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GuessResponse>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `gamePut$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  gamePut$Plain(params: {
    gameId: string;
    guess: string;
  },
  context?: HttpContext

): Observable<GuessResponse> {

    return this.gamePut$Plain$Response(params,context).pipe(
      map((r: StrictHttpResponse<GuessResponse>) => r.body as GuessResponse)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `gamePut$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  gamePut$Json$Response(params: {
    gameId: string;
    guess: string;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<GuessResponse>> {

    const rb = new RequestBuilder(this.rootUrl, GameService.GamePutPath, 'put');
    if (params) {
      rb.path('gameId', params.gameId, {});
      rb.path('guess', params.guess, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GuessResponse>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `gamePut$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  gamePut$Json(params: {
    gameId: string;
    guess: string;
  },
  context?: HttpContext

): Observable<GuessResponse> {

    return this.gamePut$Json$Response(params,context).pipe(
      map((r: StrictHttpResponse<GuessResponse>) => r.body as GuessResponse)
    );
  }

  /**
   * Path part for operation gameDelete
   */
  static readonly GameDeletePath = '/api/Game/{gameId}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `gameDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  gameDelete$Response(params: {
    gameId: string;
  },
  context?: HttpContext

): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, GameService.GameDeletePath, 'delete');
    if (params) {
      rb.path('gameId', params.gameId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access only to the response body.
   * To access the full response (for headers, for example), `gameDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  gameDelete(params: {
    gameId: string;
  },
  context?: HttpContext

): Observable<void> {

    return this.gameDelete$Response(params,context).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
