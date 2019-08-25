import { Injectable, EventEmitter } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpTransportType } from '@aspnet/signalr';
import { SignalrMethods, SignalrMethod } from './signalr.abstract.service';
import { SignalRCoreService } from './signalr.core.service';

interface MonitoringMethods extends SignalrMethods {
  UpdateSeats: SignalrMethod;
}

@Injectable({
  providedIn: 'root'
})
export class GalaxitHubService extends SignalRCoreService<MonitoringMethods> {

  // tslint:disable-next-line:variable-name
  private _updateSeats = new EventEmitter<boolean[]>();
  public updateSeats = this._updateSeats.asObservable();

  protected url = '/GalaxitHub';
  protected transport = HttpTransportType.LongPolling;
  protected connectionTryDelay = 10000;

  protected methods: MonitoringMethods = {
    UpdateSeats: (table) => {
      this._updateSeats.emit(table);
      console.log(table);
    },
  };

  constructor() {
    super();
  }

  public run(): Observable<any> {
    this.baseUrl = 'https://localhost:44310';
    return this.start();
  }

  public stopService(): boolean {
    this.stop();
    return true;
  }
}
