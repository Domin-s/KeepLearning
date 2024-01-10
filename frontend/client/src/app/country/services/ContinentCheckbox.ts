import { Continent } from "../models/Continent";
import { Checkbox } from "../../common/checkbox/model/checkbox";

export class ContinentCheckbox {
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

  setCheckedContinents(checkedContients: string[]) {
    for ( let i = 0; i < this.continentCheckoboxes.length; i++) {
      let shouldBeChecked = this.isInCheckedList(checkedContients, this.continentCheckoboxes[i]);

      if (shouldBeChecked) {
        this.continentCheckoboxes[i].isChecked = true;
      } else {
        this.continentCheckoboxes[i].isChecked = false;
      }
    }
  }

  private isInCheckedList(checkedContients: string[], continent: Checkbox): boolean {
    let foundContient = checkedContients.find(c => c === continent.value);
    
    if (foundContient === undefined) return false;

    return true;
  }

  checkOrUncheckContinents(continents: Checkbox[]) {
    for (let continent of continents) {
      this.checkOrUncheckContinent(continent, continent.isChecked);
    }
  }

  checkOrUncheckContinent(continent: Checkbox, isChecked: boolean) {
    let continentIndex = this.continentCheckoboxes.findIndex( c => c.value === continent.value);
    if (continentIndex === -1) {
      console.log("Not found continent");
    }
    
    this.continentCheckoboxes[continentIndex].isChecked = isChecked;
  }

  getCheckedContinents(): Checkbox[] {
    return this.continentCheckoboxes.filter(c => c.isChecked);
  }
}