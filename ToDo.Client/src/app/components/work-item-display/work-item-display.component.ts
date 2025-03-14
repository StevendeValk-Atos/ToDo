import { Component, inject, Input } from '@angular/core';
import { WorkItem } from '../../../models/WorkItem';
import { HttpClient } from "@angular/common/http";

import { WorkItemService } from "../../work-item.service";

@Component({
  selector: 'app-work-item-display',
  templateUrl: './work-item-display.component.html',
  styleUrl: './work-item-display.component.css'
})
export class WorkItemDisplayComponent {
  public workItemService: WorkItemService = inject(WorkItemService)

  constructor(private http: HttpClient) { }

  @Input() workItem!: WorkItem;
  @Input() workItemIndex!: number;

  deleteWorkItem() {
    this.http.delete("/workitem/" + this.workItem.id).subscribe();
  }

  onCheckBoxInput() {
    this.http.put<WorkItem>("/workitem/" + this.workItem.id, this.workItem)
    .subscribe();
  }
}
