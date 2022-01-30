import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-child',
  template: `
    <p>{{name}}</p>
    
    <button (click)="fireEventToParent()">Send Event to Parent</button>
  `,
  styleUrls: ['./child.component.css']
})
export class ChildComponent implements OnInit {

  @Input('parentData') public name;

  @Output() public childEvent = new EventEmitter();

  fireEventToParent(){
    this.childEvent.emit("Hi!");
  }
  
  constructor() { }

  ngOnInit() {
  }

}
