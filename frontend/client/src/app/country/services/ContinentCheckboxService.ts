import { Injectable } from "@angular/core";
import { Continent } from "../models/Continent";
import { Checkbox } from "../../common/checkbox/model/checkbox";

@Injectable({
  providedIn: 'root'
})
export class ContinentCheckboxService {
  continents: Continent[] = [
    {name: 'Africa'}, 
    {name: 'Asia'}, 
    {name: 'Australia'}, 
    {name: 'Europe'}, 
    {name: 'North America'}, 
    {name: 'South America'}
  ];

  continentCheckoboxes: Checkbox[] = [];

  constructor(){
    this.continentCheckoboxes = this.createContinentCheckboxes(this.continents);
  }

  createContinentCheckboxes(continents: Continent[]): Checkbox[] {
    let continentChecboxes: Checkbox[] = [];

    for (let continent of continents) {
      let continentCheckbox = this.createContinentCheckbox(continent, true);
      continentChecboxes.push(continentCheckbox);
    }

    return continentChecboxes;
  }

  createContinentCheckbox(continent: Continent, isChecked: boolean): Checkbox {
    return new Checkbox(
      'Continent', 
      'Continent', 
      continent.name, 
      isChecked
    );
  }

  checkOrUncheckContinent(continent: Continent, isChecked: boolean) {
    let continentIndex = this.continentCheckoboxes.findIndex( c => c.value === continent.name);
    if (continentIndex === -1) {
      console.log("Not found continent");
    }

    this.continentCheckoboxes[continentIndex].isChecked = isChecked;
  }
}