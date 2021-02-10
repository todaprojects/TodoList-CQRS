import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Todo } from '../models/Todo';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  todosUrl = 'https://localhost:5001/api/todo/';

  constructor(private http: HttpClient) {
  }

  // Get Todos
  getTodos(): Observable<Todo[]> {
    return this.http.get<Todo[]>(`${this.todosUrl}`);
  }

  // Toggle Completed
  toggleCompleted(todo: Todo): Observable<any> {
    return this.http.put(`${this.todosUrl}${todo.id}`, todo, httpOptions);
  }

  // Delete Todo
  deleteTodo(todo: Todo): Observable<any> {
    return this.http.delete<Todo>(`${this.todosUrl}${todo.id}`, httpOptions);
  }

  // Add Todo
  addTodo(todo: Todo): Observable<Todo> {
    return this.http.post<Todo>(this.todosUrl, todo, httpOptions);
  }
}
