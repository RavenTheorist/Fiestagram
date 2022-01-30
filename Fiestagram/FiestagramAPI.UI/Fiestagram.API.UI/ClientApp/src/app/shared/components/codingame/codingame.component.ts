import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-codingame',
  template: `
  <!-- 1 STYLES -->
  <div class="label" [style.color]="(color)">
  {{"Welcome " + label.toUpperCase()}}
  <p [style.color]="'orange'" [style.text-decoration]="hasError ? 'underline overline' : 'underline'" [style.font-weight]="'1000'">My message</p>
  <h3 [ngStyle]="titleStyles">My dynamic stylized title</h3>
  </div>

  <!-- 2 BOOL BINDING -->
  <input bind-disabled="inputDisabled" type="text" value="name...">

  <!-- 3 CLASS -->
  <div [class.text-danger]="hasError">{{"You are now locatend in:" + siteUrl}}</div>
  <!-- 4 CLASS -->
  <div [ngClass]="messageClasses">Conditional message!</div>

  <!-- 5 EVENTS -->
  <button (click)="onClick($event)">Greet from Method</button>
  <button (click)="greeting='Welcome from my attribute'">Greet from HTML attribute</button><br />
  {{greeting}}

  <!-- 6 TEMPLATE REFERENCE VARIABLES - Send attribute in a method -->
  <input #myInput type="text">
  <button (click)="onClickLogMessage(myInput.value)">Greet from Method</button>
  `,
  styles: [`
  .text-success {
    color: green;
  }
  .text-danger {
    color: red;
  }
  .text-special {
    font-style: italic;
  }
  `]
})
export class CodingameComponent implements OnInit {

  constructor() { }

  // 1 <div STYLES
  @Input()
  public label : string;

  @Input()
  public color : string;

  public titleStyles = {
    color: "blue",
    fontStyle: "italic"
  }

  // 2 <input BOOL BINDING
  public inputDisabled = false;

  // 3 div CLASS
  public siteUrl = window.location.href;

  public hasError = false;
  public isSpecial = true;
  // 4 <div CLASS
  public messageClasses = {
    "text-success": !this.hasError,
    "text-danger": this.hasError,
    "text-special": this.isSpecial
  }

  // 5 <button EVENTS
  public greeting = "";
  onClick(event) {
    //console.log(event);
    this.greeting = "Welcome from my method!";
  }

  // 6 <button Send attribute in a method
  onClickLogMessage(value) {
    console.log(value);
  }
  
  ngOnInit() {
  }

}
