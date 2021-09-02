import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignalrReportComponent } from './signalr-report.component';

describe('SignalrReportComponent', () => {
  let component: SignalrReportComponent;
  let fixture: ComponentFixture<SignalrReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignalrReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignalrReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
