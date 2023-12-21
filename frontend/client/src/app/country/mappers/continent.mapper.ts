import { Injectable } from "@angular/core";
import { Continent } from "../../country/models/Continent";
import { Checkbox } from "../../common/checkbox/model/checkbox";

@Injectable({
  providedIn: "root",
})
export class ContinentMapper {
  mapToCheckbox(continents: Continent[], continentsFromPath: string[] = []): Checkbox[] {
    var checkboxes: Checkbox[] = [];

    for (let i = 0; i < continents.length; i++) {
      const continent = continents[i];
      
      let isChecked = this.checkIfContinentShouldBeChecked(continent, continentsFromPath);
      console.log(continentsFromPath)
      console.log(continent)
      console.log(isChecked)

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

  checkIfContinentShouldBeChecked(continentToCheck: Continent, continentsFromPath: string[]): boolean {
    if (continentsFromPath.length <= 0) {
      return true;
    }

    for (let i = 0; i < continentsFromPath.length; i++) {
      if (continentToCheck.name === continentsFromPath[i]) {
        return true;
      }
    }

    return false;
  }
}
