import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bubble',
  templateUrl: './bubble.component.html',
  styleUrls: ['./bubble.component.css']
})
export class BubbleComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  openBubble(id: string) {
    this.router.navigateByUrl(`/bubble/${id}`);
  }
}
