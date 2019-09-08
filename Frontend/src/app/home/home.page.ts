import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
})
export class HomePage implements OnInit{
  public menuSegment: string = "home";

  constructor(private router: Router) {}
  ngOnInit() {
    this.changeSegment(this.menuSegment);
  }
  
  changeSegment(segment: string) {
    this.menuSegment = segment;
  }

  navigate(route: string) {
    this.changeSegment(route);
    this.router.navigateByUrl('/'+ route);
  }

  sair() {
    localStorage.removeItem('sgq.token');
    this.router.navigateByUrl('/login');
  }
}

