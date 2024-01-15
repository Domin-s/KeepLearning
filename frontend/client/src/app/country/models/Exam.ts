import { Category } from "./Category";
import { Question } from "./Question";

export interface Exam {
    name: string;
    category: Category;
    continents: string[];
    questions: Question[];
  } 