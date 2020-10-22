import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  canActivate(): boolean
  {
    if(!this.as.isAuthenticated()){
      this.router.navigate([''])
    }
    return true;
  }
  
  constructor(private as: AuthService,private router:Router){}

}
