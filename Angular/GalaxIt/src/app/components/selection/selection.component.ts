import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Bubble } from 'src/app/model/bubble';
import { GalaxitHubService } from 'src/app/hub/galaxit-hub';

@Component({
  selector: 'app-selection',
  templateUrl: './selection.component.html',
  styleUrls: ['./selection.component.css']
})
export class SelectionComponent implements OnInit {
  public id: string;
  public bubble: Bubble;
  occupied = [];
  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private httpClient: HttpClient) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.getTableFromBubble(this.id);

  }
  // tslint:disable-next-line:ban-types
  private getTableFromBubble(id: string) {
    this.httpClient.get('https://galaxit.azurewebsites.net/api/tables/FromBubble/' + id).subscribe(
      async (result: Bubble) => {
        this.bubble = result;
        let i = 0;
        for (const table of this.bubble.tables) {
          i = 0;
          for ( const seat of table.seats) {
            this.occupied[i] = seat.occupied;
            i++;
          }
        }
        await this.delay(2000);
        console.log('realoading');
        this.getTableFromBubble(id);
      }
    );
  }
  private delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
}

}
