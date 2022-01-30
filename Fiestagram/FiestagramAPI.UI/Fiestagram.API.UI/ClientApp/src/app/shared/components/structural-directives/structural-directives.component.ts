import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-structural-directives',
  template: `
    <!-- 1 ngIf: Show this or elseBlock -->
    <h2 *ngIf="displayCondition1; else elseBlock1">
      ngIf Condition1: TRUE
    </h2>
    <ng-template #elseBlock1> <h2>ngIf Condition 1: ELSE</h2> </ng-template>

    <!-- 2 ngIf: Show thenBlock or elseBlock -->
    <div *ngIf="displayCondition2; then thenBlock2 else elseBlock2"></div>
    <ng-template #thenBlock2> <h2>ngIf Condition 2: THEN</h2> </ng-template>
    <ng-template #elseBlock2> <h2>ngIf Condition 2: ELSE</h2> </ng-template>

    <!-- 3 ngSwitch: Switch case attribute value -->
    <div [ngSwitch]="pickedUpColor">
      <div *ngSwitchCase="'red'">You picked up the RED color</div>
      <div *ngSwitchCase="'blue'">You picked up the BLUE color</div>
      <div *ngSwitchCase="'green'">You picked up the GREEN color</div>
      <div *ngSwitchDefault>Unknown color</div>
    </div>

    <!-- 4 ngFor: Show colors in a list + index + isFirstElement? + isLastElement? + odd? -->
    <ul>
    <li *ngFor="let color of colors; index as i; first as f; last as l; odd as o">
                        {{i}}: {{color}} -> [FIRST? {{f}}] [LAST? {{l}}] [ODD? {{o}}]
    </li>
    </ul>

  `,
  styleUrls: ['./structural-directives.component.css']
})
export class StructuralDirectivesComponent implements OnInit {

  // 1 ngIf: Show this or elseBlock
  public displayCondition1 = true;

  // 2 ngIf: Show thenBlock or elseBlock
  public displayCondition2 = true;

  // 3 ngSwitch: Switch case attribute value
  public pickedUpColor = "green";

  // 4 ngFor: Show colors in a list
  public colors = ["red", "blue", "green", "yellow"];

  constructor() { }

  ngOnInit() {
  }

}
