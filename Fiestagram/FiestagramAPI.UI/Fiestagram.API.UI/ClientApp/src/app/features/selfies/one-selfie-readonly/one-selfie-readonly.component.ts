import { Component, Input, OnInit } from '@angular/core';
import { Selfie } from 'src/app/models/selfie';

@Component({
  selector: 'app-one-selfie-readonly',
  templateUrl: './one-selfie-readonly.component.html',
  styleUrls: ['./one-selfie-readonly.component.css']
})
export class OneSelfieReadonlyComponent implements OnInit {
@Input()
public selfie: Selfie = null;

  constructor() { }

  ngOnInit() {
  }

}
