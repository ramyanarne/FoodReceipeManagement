import { Component, OnInit, Output, EventEmitter, output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit{

  @Output() public sidenavToggle = new EventEmitter();
  constructor() {}
   ngOnInit(): void {
     
   }
  public onToggleSidenav = () => { 
    this.sidenavToggle.emit();
  }
}
