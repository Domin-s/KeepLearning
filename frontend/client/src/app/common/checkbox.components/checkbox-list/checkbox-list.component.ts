import { Component, Input, OnInit } from '@angular/core';
import { Checkbox } from '../model/checkbox';
import { CheckboxComponent } from '../checkbox/checkbox.component';

@Component({
  standalone: true,
  selector: 'app-checkbox-list',
  templateUrl: './checkbox-list.component.html',
  styleUrl: './checkbox-list.component.css',
  imports: [CheckboxComponent]
})
export class CheckboxListComponent implements OnInit {
  @Input({ required: true}) checkboxes!: Checkbox[];

  constructor() {
    console.log("constructor");
    console.log("CheckboxListComponent");
    console.log(this.checkboxes);
  }

  ngOnInit(): void {
    console.log("ngOnInit");
    console.log("CheckboxListComponent");
    console.log(this.checkboxes);
  }
}
