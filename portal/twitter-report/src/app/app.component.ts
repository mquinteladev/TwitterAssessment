import { Component } from '@angular/core';
import { HttpClient } from '@microsoft/signalr';
import { SignalRService } from './services/signal-r.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'twitter-report';
  constructor(public signalRService: SignalRService) { }
  ngOnInit() {
    this.signalRService.startConnection();
  }
}
