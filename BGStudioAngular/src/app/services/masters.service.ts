import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AUTH_API_URL } from '../app-injection-token';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class MastersService {

  GetMasters():Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/masters`);
  }
  constructor(
    private http: HttpClient,
    @Inject(AUTH_API_URL) private apiUrl: string,
    private router: Router
  ) { }
}
