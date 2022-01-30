import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Fiestagram';
  subtitle = 'La barbe quel site !';
  searchedText = '';

  searchSelfie(searchedText: string){
    console.log('AppComponent', searchedText);
    this.searchedText = searchedText;
  }
}
