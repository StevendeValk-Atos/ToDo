import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { WorkItem } from "../../models/WorkItem";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public workItems: WorkItem[] = [];
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getWorkItems();
  }

  getWorkItems() {
    this.http.get<WorkItem[]>("/workitem").subscribe(
      (result) => { this.workItems = result; console.log(this.workItems) }
    )
  }

}
