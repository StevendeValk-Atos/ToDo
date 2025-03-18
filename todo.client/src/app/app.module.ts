import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';

import { AddWorkItemFormComponent } from './components/add-work-item-form/add-work-item-form.component';
import { WorkItemDisplayComponent } from './components/work-item-display/work-item-display.component';
import { WorkItemListComponent } from "./components/work-item-list/work-item-list.component"
@NgModule({
  declarations: [
    AppComponent,
    AddWorkItemFormComponent,
    WorkItemDisplayComponent,
    WorkItemListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
