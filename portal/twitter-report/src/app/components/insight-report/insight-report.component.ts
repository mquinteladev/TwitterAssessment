import { Component, Input, OnInit } from '@angular/core';

import { DataResponse } from 'src/app/model/data-response';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { StreamDataResponse } from '../../model/stream-data-response';
import { TwitterService } from '../../services/twitter.service';

@Component({
  selector: 'app-insight-report',
  templateUrl: './insight-report.component.html',
  styleUrls: ['./insight-report.component.css']
})
export class InsightReportComponent implements OnInit {

  @Input()
  public model: StreamDataResponse[] = [];
  @Input()
  public tweetsPerMinutesReport: string = "";
  @Input()
  public tweetsPerSecondsReport: string = "";
  public selectedTwitter: DataResponse | undefined;

  constructor(
    private readonly _modalService: NgbModal,
    private readonly _twitterService: TwitterService) { }

  ngOnInit(): void {
  }

  open(content: any, item: StreamDataResponse) {
    this._twitterService.GetTwitter(item.id).subscribe(data => {
      this.selectedTwitter = data;
      this._modalService.open(content, {
        centered: true,
        backdrop: 'static'
      });
    })
  }
}
