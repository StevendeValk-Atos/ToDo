import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"

import { WorkItem } from "../models/WorkItem"
import { BehaviorSubject } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class WorkItemService {
  public workItems: WorkItem[] = [];

  private workItemsSubject : BehaviorSubject<WorkItem[]> = new BehaviorSubject<WorkItem[]>([]);
  public workItems$ = this.workItemsSubject.asObservable();
  constructor(private http: HttpClient) {
    this.getWorkItems();
  }

  private _route: string = "/workitem";

  private getWorkItems() {
    this.http.get<WorkItem[]>(this._route).subscribe(
      (result) => { this.workItems = result });
  }

  public deleteWorkItem(workItemId: number) {
    this.http.delete(this._route + "/" + workItemId).subscribe();
    this.getWorkItems();
  }

  public updateWorkItem(workItem: WorkItem) {
    this.http.put<WorkItem>(this._route + "/" + workItem.id, workItem).subscribe();
  }
}
