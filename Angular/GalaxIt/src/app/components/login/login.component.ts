import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm = this.fb.group({
    login: [ '', Validators.required ],
    password: [ '', Validators.required ]
  });

  constructor(private router: Router, private fb: FormBuilder) { }

  ngOnInit() { 
  }

  onLoginSubmit() {
  }

  onRegisterSubmit() {
    this.router.navigateByUrl("/register");
  }
}
