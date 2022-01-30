import { Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';

@Component({
  selector: 'app-menu-general',
  templateUrl: './menu-general.component.html',
  styleUrls: ['./menu-general.component.css']
})
export class MenuGeneralComponent implements OnInit {

  showLogo = true;

  @ViewChild('searchInput', { static: false })
  searchInput: ElementRef; // Access this via this.searchInput.nativeElement.value

  // Event to which we want to broardcast when a search happens
  @Output()
  onSearchLaunched: EventEmitter<string> = new EventEmitter<string>();

  constructor() { }

  ngOnInit() {
  }

  search() {
    const searchText = this.searchInput.nativeElement.value;

    this.onSearchLaunched.emit(searchText);
  }

}
