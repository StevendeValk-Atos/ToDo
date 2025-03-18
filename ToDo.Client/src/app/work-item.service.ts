import { Injectable } from "@angular/core"
import { HttpClient } from "@angular/common/http"

import { WorkItem } from "../models/work-item"
import { BehaviorSubject } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class WorkItemService {
  private workItemsSubject : BehaviorSubject<WorkItem[]> = new BehaviorSubject<WorkItem[]>([]);
  public workItems$ = this.workItemsSubject.asObservable();
  constructor(private http: HttpClient) {
    this.getWorkItems();
  }

  private _route: string = "/workitem";

  private getWorkItems() {
    this.http.get<WorkItem[]>(this._route).subscribe(
      (result) => {
        this.workItemsSubject.next(result);
      }
    );
  }

  public addWorkItem(description: string) {
    let workItem: WorkItem = {
      id: 0,
      description: description,
      isDone: false
    };

    // TODO: Replace http.post request with this.workItems.push statement
    let response$ = this.http.post(this._route, workItem);
    response$.subscribe((response) => {
      this.getWorkItems();
    });
  }

  public deleteWorkItem(workItemIndex: number) {
    let workItems = this.workItemsSubject.getValue();
    let workItem = workItems[workItemIndex];
    this.http.delete(this._route + "/" + workItem.id).subscribe();

    workItems.splice(workItemIndex, 1);
    this.workItemsSubject.next(workItems);
  }

  public updateWorkItem(workItemIndex: number, workItem: WorkItem) {
    this.http.put<WorkItem>(this._route + "/" + workItem.id, workItem).subscribe();

    let workItems = this.workItemsSubject.getValue();
    workItems[workItemIndex] = workItem;
    this.workItemsSubject.next(workItems);
  }
}
