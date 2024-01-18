import { Category } from "./Category";
import { Continent } from "./Continent";
import { Question } from "./Question";

export interface Exam {
    name: string;
    category: Category;
    continents: Continent[];
    questions: Question[];
  } 