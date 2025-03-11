import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"

import { WorkItem } from "../models/WorkItem"

@Injectable({
  providedIn: "root"
})
export class WorkItemService {
  public workItems: WorkItem[] = [];

  constructor(private http: HttpClient) { }

  public getWorkItems() {
    this.http.get<WorkItem[]>("/workitem").subscribe(
      (result) => { this.workItems = result });
  }
}
