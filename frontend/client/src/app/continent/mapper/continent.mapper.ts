import { Injectable, inject } from "@angular/core";
import { Continent } from "../../country/models/Continent";
import { Checkbox } from "../../common/checkbox.components/model/checkbox";

@Injectable({
  providedIn: "root",
})
export class ContinentMapper {
  mapToCheckbox(continents: Continent[]): Checkbox[] {
    var checkboxes: Checkbox[] = [];

    for (let i = 0; i < continents.length; i++) {
      const continent = continents[i];

      let checkbox: Checkbox  = new Checkbox(
        continent.name,
        "Continent",
        continent.name,
        true
      );
      
      checkboxes.push(checkbox);
    }

    return checkboxes;
  }
}
