import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-selection',
  templateUrl: './selection.component.html',
  styleUrls: ['./selection.component.css']
})
export class SelectionComponent implements OnInit {
  public id: string;

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private httpClient: HttpClient) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getTableFromBubble(this.id);
  }
  // tslint:disable-next-line:ban-types
  getTableFromBubble(id: string) {
    this.httpClient.get('https://galaxit.azurewebsites.net/api/tables/FromBubble/' + id).subscribe(
      (result) => {
        console.log(result);
      }
    );
  }
}
