import * as signalR from "@microsoft/signalr"

import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { StreamDataResponse } from '../model/stream-data-response';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SignalRService {
  public data: StreamDataResponse[] = [];
  private hubConnection: signalR.HubConnection = new signalR.HubConnectionBuilder()
    .withUrl(`${environment.apiUrl}/chart`)
    .build();

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`${environment.apiUrl}/chart`)
      .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err))
  }

  public transferChartDataListenerFromSignalR(): Observable<StreamDataResponse> {
    return new Observable<StreamDataResponse>(observer => {
      this.hubConnection.on('transferchartdata', (data) => {
        this.data = data;
        return observer.next(data);
      });
    }
    );
  }

}
