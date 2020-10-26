import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { Inject, Injectable } from '@angular/core';
import { AUTH_API_URL } from './app-injection-token';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private authService:AuthService) {
    
  }
  isLoggedIn():Boolean{
    return this.authService.isAuthenticated();
  }
}
