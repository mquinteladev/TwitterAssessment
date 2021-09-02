import * as moment from 'moment';

import { ChangeDetectorRef, Component, OnInit } from '@angular/core';

import { SignalRService } from '../../services/signal-r.service';
import { StreamDataResponse } from 'src/app/model/stream-data-response';

@Component({
  selector: 'app-signalr-report',
  templateUrl: './signalr-report.component.html',
  styleUrls: ['./signalr-report.component.css']
})
export class SignalrReportComponent implements OnInit {

  public model: StreamDataResponse[] = [];
  public tweetsPerMinutesReport: string = "";
  public tweetsPerSecondsReport: string = "";
  constructor(private readonly _signalRService: SignalRService) { }

  ngOnInit(): void {
    const beforeNow = moment();
    this._signalRService.transferChartDataListenerFromSignalR().subscribe(data =>{
      this.model.push(data);
      console.warn(data);
      this.tweetsPerMinutesReport = this.generateTweetsPerMinutesReport(beforeNow);
      this.tweetsPerSecondsReport = this.generateTweetsPerSecondsReport(beforeNow);
    });
  }

  generateTweetsPerMinutesReport(initDate: moment.Moment):string {
    var duration = moment.duration(moment().diff(initDate));
    var minutes = duration.asMinutes();
    return `${Math.trunc(this.model.length/minutes)}`;
  }

  generateTweetsPerSecondsReport(initDate: moment.Moment):string {
    var duration = moment.duration(moment().diff(initDate));
    var seconds = duration.asSeconds();
    return `${Math.trunc(this.model.length/seconds)}`;
  }

}
