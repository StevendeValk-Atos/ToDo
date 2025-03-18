import { Component, OnInit, inject } from '@angular/core';

import { WorkItem } from '../../../models/work-item';
import { WorkItemDisplayComponent } from '../work-item-display/work-item-display.component';
import { WorkItemService } from '../../work-item.service';

@Component({
  selector: 'app-work-item-list',
  templateUrl: './work-item-list.component.html',
  styleUrls: ['./work-item-list.component.css']
})
export class WorkItemListComponent implements OnInit {
  private workItemService = inject(WorkItemService);

  public workItems: WorkItem[] = [];

  ngOnInit() {
    this.workItemService.workItems$.subscribe((workItems) => {
      this.workItems = workItems;
    });
  }
}
