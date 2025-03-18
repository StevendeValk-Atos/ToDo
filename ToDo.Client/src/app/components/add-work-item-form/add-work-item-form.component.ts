import { Component, inject } from '@angular/core';
import { WorkItemService } from '../../work-item.service';

@Component({
  selector: 'app-add-work-item-form',
  templateUrl: './add-work-item-form.component.html',
  styleUrls: ['./add-work-item-form.component.css']
})
export class AddWorkItemFormComponent {
  private workItemService = inject(WorkItemService);

  public workItemDescription: string = "";

  public addWorkItem() {
    this.workItemService.addWorkItem(this.workItemDescription);
    this.workItemDescription = "";
  }

}
