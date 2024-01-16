import { BehaviorSubject } from "rxjs";
import { Exam } from "../../models/Exam";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root",
})
export class ExamDataService {
  private data = new BehaviorSubject<Exam | undefined>(undefined);
  currentData = this.data.asObservable();

  constructor() {}

  setData(data: Exam | undefined) {
    if (data !== undefined){
      this.data.next(data);
    } 
  }
}