import { Component, OnInit } from '@angular/core';

import { Todo } from './todo';
import { TodoService } from './todo.service';

@Component({
    selector: 'todo',
    template: require('./todo.component.html')
})
export class TodoComponent implements OnInit{
    public todos: Todo[] = [];
    public newTodoTitle: string = '';

    constructor(private todoService: TodoService) { }

    ngOnInit(): void {
        this.getTodos();
    }

    public addTodo(): void {
        this.newTodoTitle = this.newTodoTitle.trim();
        if (this.newTodoTitle.length) {
            this.todoService.create(this.newTodoTitle)
                .then(() => this.getTodos());
        }

        this.newTodoTitle = '';
    }

    public toggleCompleted(todo: Todo): void {
        todo.isCompleted = !todo.isCompleted;
        this.todoService.update(todo);
    }

    public editTodo(todo: Todo): void {
        todo.isEditing = true;
    }

    public stopEditingTodo(todo: Todo, value: string): void {
        todo.isEditing = false;
        if (value == todo.title)
            return;

        todo.title = value;
        this.todoService.update(todo)
            .then(() => this.getTodos());
    }

    public cancelEditingTodo(todo: Todo): void {
        todo.isEditing = false;
    }

    public delete(todo: Todo): void {
        this.todoService.delete(todo.todoItemId)
            .then(() => this.getTodos());
    }

    private getTodos(): void {
        this.todoService.getTodos()
            .then(result => this.todos = result)
            .catch(error => console.log(error));
    }
}