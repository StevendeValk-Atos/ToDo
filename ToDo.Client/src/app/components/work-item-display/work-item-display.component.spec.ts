import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkItemDisplayComponent } from './work-item-display.component';

describe('WorkItemDisplayComponent', () => {
  let component: WorkItemDisplayComponent;
  let fixture: ComponentFixture<WorkItemDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WorkItemDisplayComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WorkItemDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
