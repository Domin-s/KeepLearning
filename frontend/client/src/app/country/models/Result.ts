import { Answer } from "./Answer";

export interface Result {
  answerResults: Answer[];
  numberOfGoodAnswers: number;
  numberOfBadAnswers: number
}