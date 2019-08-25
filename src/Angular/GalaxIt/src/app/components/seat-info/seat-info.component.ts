import { Component, OnInit } from '@angular/core';
import { SeatsService, UsersService } from '../../services/api';
import { AuthService } from '../../services/auth.service';
import { ErrorHandlerService } from '../../services/errorHandler.service';
import { Seat } from '../../model/seat';

@Component({
  selector: 'app-seat-info',
  templateUrl: './seat-info.component.html',
  styleUrls: ['./seat-info.component.css']
})
export class SeatInfoComponent implements OnInit {
  seat: Seat;
  
  start: Date;
  end: Date;
  constructor(private userService: UsersService,
              private auth: AuthService,
              private seatService: SeatsService,
              private errorService: ErrorHandlerService) { }

  ngOnInit() {
    this.userService.getUser(this.auth.userID).subscribe(res => this.seatService.getSeat(res.seat.id).subscribe(res => this.seat = res));
  }
  book() {
    
  }

}
