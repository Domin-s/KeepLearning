import { Continent } from "./Continent";

export interface Country {
  name: string;
  abbreviation: string;
  capitalCity: string;
  continentDto: Continent;
}
