import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-parent',
  template: `
    <h2>{{"[Child to Parent] " + childMessage}}</h2>
    <app-child (childEvent)="childMessage=$event" [parentData]="name"></app-child>
  `,
  styleUrls: ['./parent.component.css']
})
export class ParentComponent implements OnInit {

  public name = "[Parent to Child] Amine";

  public childMessage = "";

  constructor() { }

  ngOnInit() {
  }

}
