import { Component, OnInit } from '@angular/core';
import { Task } from 'src/models/task';
import { TaskService } from 'src/services/task.service';
import { TaskStatus } from '../../../models/task.status.enum';

declare var window: any;

@Component({
  selector: 'app-tasks',
  templateUrl: './Tasks.Component.html',
  styleUrls: ['./Tasks.Component.scss'],
})
export class TasksComponent implements OnInit {
  public TASK_STATUS = TaskStatus;

  taskPopup: any;
  task: Task = {
    id: 0,
    title: '',
    description: '',
    status: TaskStatus.Doing,
  };

  tasks: Task[] = [];

  constructor(private taskService: TaskService) {}

  loadTasks(): void {
    this.taskService.getAll().subscribe((data: any) => (this.tasks = data));
  }

  ngOnInit(): void {
    this.loadTasks();

    this.taskPopup = new window.bootstrap.Modal(
      document.getElementById('taskPopup')
    );
  }

  onAdd(): void {
    this.task = {
      id: 0,
      title: '',
      description: '',
      status: TaskStatus.Doing,
    };
    this.taskPopup.show();
  }

  onEdit(id: number): void {
    this.taskService.getById(id).subscribe((response: any) => {
      if (response) {
        this.task = response;
        this.taskPopup.show();
      } else {
        // TODO: display an error toast message
        console.log('Cannot get the info of the selected task');
      }
    });
  }

  onDelete(id: number): void {
    this.taskService.delete(id).subscribe((response: any) => {
      if (response) {
        // TODO: display a delete toast success message and refresh the list of tasks
        this.loadTasks();
      } else {
        // TODO: display an error toast message
        console.log('Cannot delete the selected task');
      }
    });
  }

  onToggleStatus(id: number, status: TaskStatus) {
    this.taskService.editStatus(id, status).subscribe((response: any) => {
      if (response) {
        // TODO: display a toast success message and refresh the list of tasks
        this.loadTasks();
      } else {
        // TODO: display an error toast message
        console.log('Cannot change the status of the selected task');
      }
    });
  }

  onSave(task: Task) {
    const request =
      task.id > 0 ? this.taskService.edit(task) : this.taskService.create(task);

    request.subscribe((response) => {
      if (response) {
        // TODO: display a toast success message and refresh the list of tasks
        this.taskPopup.hide();
        this.loadTasks();
      } else {
        // TODO: display an error toast message
        this.taskPopup.hide();
        console.log('Cannot save this task');
      }
    });
  }
}
