import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { UsersService } from 'src/app/services/api';
import { Router } from '@angular/router';
import { ErrorHandlerService } from 'src/app/services/errorHandler.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  public registerForm = this.fb.group({
    email: ['', Validators.required, Validators.email],
    firstname: ['', Validators.required],
    surname: ['', Validators.required],
    password:['', Validators.required]
  });

  constructor(private userService: UsersService,
              private fb: FormBuilder,
              private router: Router,
              private errorHandler: ErrorHandlerService) { }

  ngOnInit() {
  }

  onRegisterSubmit(){
      this.userService.postUser({email: this.registerForm.value.email, firstname:this.registerForm.value.firstname, surname:this.registerForm.value.surname,
         password:this.registerForm.value.password}).subscribe(
           res => this.router.navigateByUrl("/bubble"),
           error => {
            this.errorHandler.handleError(error); 
            this.router.navigateByUrl("/login");
          }
         )
  }
}
