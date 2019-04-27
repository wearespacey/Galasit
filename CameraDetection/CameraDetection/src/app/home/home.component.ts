import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @ViewChild('video')
  public video;

  @ViewChild('canvas')
  public canvas;
  public constructor(
    private httpClient: HttpClient,
    ) {
  }

  public ngOnInit() { }

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
      console.log(result);
    });
    await this.delay(5000);
    this.capture();
  }
  private delay(ms: number) {
    return new Promise( resolve => setTimeout(resolve, ms) );
}
}
