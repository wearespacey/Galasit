import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  isLoggedIn = false;
  userID: string;


  constructor() { }

  logout() : void{
      this.isLoggedIn = false;
  }




    

 



}
