import { HttpClient } from '@angular/common/http';
import { Route } from '@angular/compiler/src/core';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators'
import { AUTH_API_URL } from '../app-injection-token';
import { Token } from '../models/token';

export const ACCESS_TOKEN_KEY = 'masters_access_token'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private http: HttpClient,
    @Inject(AUTH_API_URL) private apiUrl: string,
    private JwtHelper: JwtHelperService,
    private router: Router
  ) { }

  login(emailAddress:string, password:string): Observable<Token>{
    return this.http.post<Token>(`${this.apiUrl}/auth/login`, {
    emailAddress,password
    }).pipe(
      tap(token => {
      localStorage.setItem(ACCESS_TOKEN_KEY,token.access_token);
    })
    )
  }
    
  isAuthenticated():boolean {
    var token = localStorage.getItem(ACCESS_TOKEN_KEY);
    return token && !this.JwtHelper.isTokenExpired(token);
  }
  logout():void{
    localStorage.removeItem(ACCESS_TOKEN_KEY);
    this.router.navigate([' ']);
  }
}
