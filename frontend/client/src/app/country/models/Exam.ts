import { Question } from "./Question";

export interface Exam {
    name: string;
    category: string;
    continents: string[];
    questions: Question[];
  } 