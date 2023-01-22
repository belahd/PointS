import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TasksComponent } from './views/private/Tasks.Component';
import { TaskCreateEditComponent } from './views/private/Task.Create.Edit.Component';

@NgModule({
  declarations: [AppComponent, TasksComponent, TaskCreateEditComponent],
  imports: [BrowserModule, FormsModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
