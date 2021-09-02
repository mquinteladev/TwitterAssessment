import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsightReportComponent } from './insight-report.component';

describe('InsightReportComponent', () => {
  let component: InsightReportComponent;
  let fixture: ComponentFixture<InsightReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsightReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsightReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
