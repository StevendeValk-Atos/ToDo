import { Component, OnInit, inject } from '@angular/core';
import { WorkItem } from "../../models/WorkItem";
import { WorkItemDisplayComponent } from "../components/work-item-display/work-item-display.component"
import { WorkItemService} from "../work-item.service"

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  public workItemService = inject(WorkItemService)

  public workItems: WorkItem[] = [];
  public workItemDescription: string = "";
  
  ngOnInit() {
    this.workItemService.workItems$.subscribe((workItems) => {
      this.workItems = workItems;
    })
  }
}
