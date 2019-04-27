import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Bubble } from './models/bubble';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  bubbles: Bubble[] = [];
  currentBubble: string;
  table = [false, false, false, false, false, false];
  @ViewChild('video')
  public video;

  @ViewChild('canvas')
  public canvas;
  public constructor(
    private httpClient: HttpClient,
    ) {
  }

  public ngOnInit() {
    this.getBubbles();
   }

  // tslint:disable-next-line:use-life-cycle-interface
  public ngAfterViewInit() {
      if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
          navigator.mediaDevices.getUserMedia({ video: true }).then(stream => {
              this.video.nativeElement.srcObject = stream;
              this.video.nativeElement.play();
          });
          this.capture();
      }
  }

  public capture() {
      const ctx = this.canvas.nativeElement.getContext('2d');
      ctx.drawImage(this.video.nativeElement, 0, 0, this.video.nativeElement.width, this.video.nativeElement.height);
      this.canvas.nativeElement.toBlob((result) => {
        this.detectPeople(result);
      });

  }
  private async detectPeople(blob) {
    const headers = new HttpHeaders({
      'Content-Type': 'application/octet-stream',
      'Prediction-Key' : 'f784be8c5c4e47618d2aebacfa1a196c'
    });
    // tslint:disable-next-line:max-line-length
    this.httpClient.post<any>('https://northeurope.api.cognitive.microsoft.com/customvision/v3.0/Prediction/c51b7c5c-f6f1-4211-9188-349a07efef5e/detect/iterations/Iteration5/image', blob, {headers})
    .subscribe((result) => {
      this.table = [false, false, false, false, false, false];
      for(const res of result.predictions.filter(e => e.probability > 0.30 && e.tagName === 'person')) {
        this.detectPlaceOfUser(res);
      }
    });
    await this.delay(5000);
    this.capture();
  }
  private getBubbles() {
    this.httpClient.get<Bubble[]>('https://galaxit.azurewebsites.net/api/bubbles').subscribe(
      (result) => {
        this.bubbles = result;
      }
    );
  }
  private detectPlaceOfUser(data: any) {
    const centerVert = data.boundingBox.top * 480 + (data.boundingBox.height / 2) * 480;
    const centerHor = data.boundingBox.left * 640 + (data.boundingBox.width / 2) * 640;
    console.log(centerHor + ',' + centerVert);
    if (centerVert < 245) {
      if (centerHor < 185) {
        console.log('place 0');
        this.table[0] = true;
      } else if ( centerHor < 340) {
        console.log('place 1');
        this.table[1] = true;
      } else {
        console.log('place 2');
        this.table[2] = true;
      }
    } else {
      if (centerHor < 185) {
        console.log('place 3');
        this.table[3] = true;
      } else if ( centerHor < 340) {
        console.log('place 4');
        this.table[4] = true;
      } else {
        console.log('place 5');
        this.table[5] = true;
      }
    }
    this.sendNewNumberOfUser();
  }
  private sendNewNumberOfUser() {
    const headers = new HttpHeaders({
      'Access-Control-Allow-Origin': 'http://localhost:4200/welcome',
      'Access-Control-Allow-Methods': 'GET,PUT,POST,DELETE,OPTIONS',
      'Access-Control-Allow-Headers': '*',
    });
    console.log(this.table);
    // tslint:disable-next-line:max-line-length
    this.httpClient.put<Bubble>('https://localhost:44310/api/bubbles/NewNumberUser/' + this.bubbles.filter(b => b.id === this.currentBubble)[0].id , this.table, {headers})
    .subscribe((result) => {
      console.log(result);
    });
  }

  private delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
}
}
