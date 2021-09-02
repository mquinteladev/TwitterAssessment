import { HttpClient, HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { InsightReportComponent } from './components/insight-report/insight-report.component';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SignalRService } from './services/signal-r.service';
import { SignalrReportComponent } from './components/signalr-report/signalr-report.component';

@NgModule({
  declarations: [
    AppComponent,
    SignalrReportComponent,
    InsightReportComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule
  ],
  providers: [SignalRService],
  bootstrap: [AppComponent]
})
export class AppModule { }
