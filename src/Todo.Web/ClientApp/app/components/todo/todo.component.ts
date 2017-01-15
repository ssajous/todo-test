import { Component, OnInit } from '@angular/core';

import { Todo } from './todo';
import { TodoService } from './todo.service';

@Component({
    selector: 'todo',
    template: require('./todo.component.html')
})
export class TodoComponent implements OnInit{
    public todos: Todo[] = [];

    constructor(private todoService: TodoService) { }

    ngOnInit(): void {
        this.todoService.getTodos()
            .then(result => this.todos = result)
            .catch(error => console.log(error));
    }

    public toggleCompleted(todo: Todo) {
        todo.isCompleted = !todo.isCompleted;
        this.todoService.update(todo);
    }
}