import { Component, OnInit } from '@angular/core';
import { TodoService } from '../../../../services/todo.service';
import { Todo } from '../../../../models/Todo';

@Component({
  selector: 'app-todos',
  templateUrl: './todos.component.html',
  styleUrls: ['./todos.component.scss']
})
export class TodosComponent implements OnInit {
  todos: Todo[];

  constructor(private todoService: TodoService) {
  }

  ngOnInit(): void {
    this.todoService.getTodos().subscribe(todos => {
      this.todos = todos;
    });
  }

  async deleteTodo(todo: Todo): Promise<void> {
    // Remove from Server
    await this.todoService.deleteTodo(todo).subscribe(todoId => {
      this.todos = this.todos.filter(t => t.id !== todoId);
    }, e => {
      alert(e.error);
      this.todos = this.todos.filter(t => t.id !== todo.id);
    });
  }

  addTodo(todo: Todo): void {
    // tslint:disable-next-line:no-shadowed-variable
    this.todoService.addTodo(todo).subscribe(todo => {
      this.todos.push(todo);
    });
  }
}
