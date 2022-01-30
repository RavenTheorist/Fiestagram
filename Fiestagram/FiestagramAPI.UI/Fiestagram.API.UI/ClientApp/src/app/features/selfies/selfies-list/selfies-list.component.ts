import { Component, Input, OnInit } from '@angular/core';
import { Selfie } from 'src/app/models/selfie';

@Component({
  selector: 'app-selfies-list',
  templateUrl: './selfies-list.component.html',
  styleUrls: ['./selfies-list.component.css']
})
export class SelfiesListComponent implements OnInit {

  selfies: Selfie[] = [
    { imageURL: 'https://st2.depositphotos.com/1017986/6014/i/600/depositphotos_60142053-stock-photo-friends-with-smartphone-taking-selfie.jpg', user: { name: 'Mr. X', selfies: []}, title: 'Sacrées têtes, bien heureux' },
    { imageURL: 'https://us.123rf.com/450wm/pressmaster/pressmaster1410/pressmaster141000500/32866773-jeunes-qui-selfie-au-discoth%C3%A8que.jpg?ver=6', user: { name: 'Ms. Y', selfies: []}, title: 'Belles gueules' }
  ];

  // Filter property
  @Input()
  set filter(value: string){
   console.log('SelfiesListComponent', value);
  }
  
  constructor() { }

  ngOnInit() {
  }

}
