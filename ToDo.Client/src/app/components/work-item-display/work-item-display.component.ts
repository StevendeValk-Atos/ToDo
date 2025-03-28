import { Component, inject, Input } from '@angular/core';

import { WorkItem } from '../../../models/work-item';
import { WorkItemService } from "../../work-item.service";

@Component({
  selector: 'app-work-item-display',
  templateUrl: './work-item-display.component.html',
  styleUrl: './work-item-display.component.css'
})
export class WorkItemDisplayComponent {
  public workItemService: WorkItemService = inject(WorkItemService)

  @Input() workItem!: WorkItem;
  @Input() workItemIndex!: number;

  deleteWorkItem() {
    this.workItemService.deleteWorkItem(this.workItemIndex);
  }

  updateWorkItem() {
    this.workItemService.updateWorkItem(this.workItemIndex, this.workItem);
  }

}
