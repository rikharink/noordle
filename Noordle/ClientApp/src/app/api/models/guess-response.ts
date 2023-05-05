/* tslint:disable */
/* eslint-disable */
import { WordMatch } from './word-match';
export interface GuessResponse {
  isValid?: boolean;
  matches?: null | Array<WordMatch>;
}
