import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
import { ToastrService } from 'ngx-toastr';
import { ErrorHandlerService } from 'src/app/services/errorHandler.service';
import { AuthService } from 'src/app/services/auth.service';
import { UsersService } from 'src/app/services/api';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm = this.fb.group({
    login: [ '', Validators.required],
    password: [ '', Validators.required ]
  });

  constructor(private router: Router, 
              private fb: FormBuilder, 
              private loginService: LoginService, 
              private toastService: ToastrService,
              private errorService: ErrorHandlerService,
              private authService: AuthService, 
              private userService: UsersService) { }

  ngOnInit() { 
  }

  onLoginSubmit() {
    this.loginService.login({email: this.loginForm.value.login, password: this.loginForm.value.password}).subscribe(
      res => {
        this.authService.userID = res;
        this.authService.isLoggedIn = true;
        this.router.navigateByUrl("/bubble");
      },
      error => {
        this.toastService.error("Wrong email and/or password!");
        this.errorService.handleError(error);
        this.router.navigateByUrl("/login");
      }
    )
  }

  getUser(){
    this.userService.getUser(this.authService.userID).subscribe(res => {
      if(res.seat != null) this.router.navigateByUrl("/unbook")})
  }

  onRegisterSubmit() {
    this.router.navigateByUrl("/register");
  }
}
