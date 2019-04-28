import { Component, OnInit } from '@angular/core';
import { SeatsService, UsersService } from 'src/app/services/api';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { Seat } from 'src/app';

@Component({
  selector: 'app-unbook',
  templateUrl: './unbook.component.html',
  styleUrls: ['./unbook.component.css']
})
export class UnbookComponent implements OnInit {
  seat: Seat;

  constructor(private seatService: SeatsService, 
              private router: Router,
              private auth: AuthService,
              private userService: UsersService) { }

  ngOnInit() {
    this.userService.getUser(this.auth.userID).subscribe(res => this.seat = res.seat);
  }


  onUnbookSubmit() {
    this.seatService.putSeat(this.seat.id, {occupied: false, start: null, end: null, table: this.seat.table , number: this.seat.number}).subscribe(
      res => this.router.navigateByUrl("/bubble"));
  }
}
