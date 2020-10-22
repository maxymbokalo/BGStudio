import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  ngOnInit(){}
  public get isLoggedIn(): boolean {
    return this.as.isAuthenticated()
  }
  login(email:string,password:string): void{
    this.as.login(email,password)
    .subscribe(res=>{
    }, error => {
      alert("Wrong login or password");
    })
  }
  logout(){
    this.as.logout();
  }

  constructor(
    private as: AuthService,
    ){}
}
