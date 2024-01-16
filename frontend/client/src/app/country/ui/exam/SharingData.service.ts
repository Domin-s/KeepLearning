import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class SharingDataService {
  constructor() {}

  setData(data: any, storageName: string) {
    localStorage.setItem(storageName, JSON.stringify(data));
  }

  getData(storageName: string) {
    let data = localStorage.getItem(storageName);
    if (data !== null) {
      return JSON.parse(data);
    }
  }
}