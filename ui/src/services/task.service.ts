import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Task } from 'src/models/task';
import { TaskStatus } from 'src/models/task.status.enum';

@Injectable({
  providedIn: 'root',
})
export class TaskService {
  constructor(private http: HttpClient) {}

  getAll(): Observable<Object> {
    return this.http.get('api/task/all');
  }

  getById(id: number): Observable<Object> {
    return this.http.get(`api/task/one?id=${id}`);
  }

  create(task: Task): Observable<Object> {
    return this.http.post('api/task/create', task);
  }

  edit(task: Task): Observable<Object> {
    return this.http.put(`api/task/edit`, task);
  }

  editStatus(id: number, status: TaskStatus): Observable<Object> {
    return this.http.patch(
      `api/task/edit/status?id=${id}&status=${status}`,
      ''
    );
  }

  delete(id: number): Observable<Object> {
    return this.http.delete(`api/task/delete?id=${id}`);
  }
}
