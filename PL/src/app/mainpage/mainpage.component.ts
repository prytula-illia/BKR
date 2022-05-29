import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mainpage',
  templateUrl: './mainpage.component.html',
  styles: [
  ]
})
export class MainpageComponent implements OnInit {

  constructor(private router : Router) { }

  ngOnInit(): void {
  }

  learnCoruses() {
    this.router.navigate(['/course-page']);
  }

}
