import { Component, input } from '@angular/core';
import { WorkItem } from '../../../models/WorkItem';

@Component({
  selector: 'app-work-item-display',
  templateUrl: './work-item-display.component.html',
  styleUrl: './work-item-display.component.css'
})
export class WorkItemDisplayComponent {
  workItem = input<WorkItem>();
}
