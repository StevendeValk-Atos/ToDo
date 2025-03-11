import { Component, Input } from '@angular/core';
import { WorkItem } from '../../../models/WorkItem';
import { HttpClient } from "@angular/common/http"

@Component({
  selector: 'app-work-item-display',
  templateUrl: './work-item-display.component.html',
  styleUrl: './work-item-display.component.css'
})
export class WorkItemDisplayComponent {
  constructor(private http: HttpClient) { }

  @Input() workItem!: WorkItem;

  deleteWorkItem() {
    this.http.delete("/workitem/" + this.workItem.id).subscribe();
  }

  onCheckBoxInput() {
    console.log(this.workItem.isDone);
  }
}
