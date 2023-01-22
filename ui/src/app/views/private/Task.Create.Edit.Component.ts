import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Task } from 'src/models/task';
import { TaskStatus } from 'src/models/task.status.enum';

@Component({
  selector: 'app-task-create-edit',
  templateUrl: './Task.Create.Edit.Component.html',
  styleUrls: ['./Task.Create.Edit.Component.scss'],
})
/** This component is used for both create and edit tasks
 * In some cases it's better to create to components, one for create the other one for edit.
 */
export class TaskCreateEditComponent implements OnInit {
  @Input() task: Task = {
    id: 0,
    title: '',
    description: '',
    status: TaskStatus.Doing,
  };

  @Output() onSave: EventEmitter<Task> = new EventEmitter();

  ngOnInit(): void {}

  onSaveTask() {
    this.onSave.emit(this.task);
  }
}
