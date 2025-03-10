import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { WorkItem } from "../../models/WorkItem";
import { WorkItemDisplayComponent } from "../components/work-item-display/work-item-display.component"

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  public workItems: WorkItem[] = [];
  public workItemDescription: string = "";
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getWorkItems();
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
