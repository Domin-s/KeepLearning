import { Injectable } from "@angular/core";
import { Continent } from "../../country/models/Continent";
import { Checkbox } from "../../common/checkbox.components/model/checkbox";

@Injectable({
  providedIn: "root",
})
export class ContinentMapper {
  mapToCheckbox(continents: Continent[], continentsChecked: string[] = []): Checkbox[] {
    var checkboxes: Checkbox[] = [];

    for (let i = 0; i < continents.length; i++) {
      const continent = continents[i];

      let isChecked = this.checkIfContinentIsChecked(continent, continentsChecked);

      let checkbox: Checkbox  = new Checkbox(
        continent.name,
        "Continent",
        continent.name,
        isChecked
      );
      
      checkboxes.push(checkbox);
    }

    return checkboxes;
  }

  checkIfContinentIsChecked(continentToCheck: Continent, continentsChecked: string[]): boolean {

    if (continentsChecked.length <= 0) {
      return false;
    }

    for (let i = 0; i < continentsChecked.length; i++) {
      const continent = continentsChecked[i];

      if (continentToCheck.name === continent) {
        return true;
      }
    }

    return false;
  }
}
