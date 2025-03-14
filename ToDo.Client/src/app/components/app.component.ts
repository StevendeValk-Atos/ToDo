import { HttpClient } from '@angular/common/http';
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
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.workItemService.workItemsSubject.subscribe((workItems) => {
      this.workItems = workItems;
      console.log(this.workItems);
    })
  }

  getWorkItems() {
    this.http.get<WorkItem[]>("/workitem").subscribe(
      (result) => { this.workItems = result; }
    )
  }

  addWorkItem() {
    let workItem: WorkItem = {
      id: 0,
      description: this.workItemDescription,
      isDone: false
    };

    this.http.post("/workitem", workItem).subscribe();
  }
}
