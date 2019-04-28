import { Injectable } from '@angular/core';
import { EventEmitter } from 'events';
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
  private _updateSeats = new EventEmitter<any>();
  public updateSeats = this.updateSeats.asObservable();

  protected url = '/GalaxitHub';
  protected transport = HttpTransportType.LongPolling;
  protected connectionTryDelay = 10000;

  protected methods: MonitoringMethods = {
    UpdateSeats: (table) => this._updateSeats.emit({table}),
  };

  constructor() {
    super();
    localStorage.setItem('endpoint', 'https://galaxit.azurewebsites.net/api');
  }

  public joinGroup(groupName: string): Observable<any> {
    if (localStorage.getItem('endpoint')) {
      this.baseUrl = localStorage.getItem('endpoint').replace('/api', '');
    }
    return this.send('JoinGroupAsync', groupName);
  }

  public leaveGroup(groupName: string): Observable<any> {
    if (localStorage.getItem('endpoint')) {
      this.baseUrl = localStorage.getItem('endpoint').replace('/api', '');
    }
    return this.send('LeaveGroupAsync', groupName);
  }

  public run(): Observable<any> {
    if (localStorage.getItem('endpoint')) {
      this.baseUrl = localStorage.getItem('endpoint').replace('/api', '');
    }
    return this.start();
  }

  public stopService() {
    this.stop();
    return true;
  }
}
