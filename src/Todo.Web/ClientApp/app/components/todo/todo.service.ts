import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Todo } from './todo';

@Injectable()
export class TodoService {
    private headers = new Headers({ 'Content-Type': 'application/json' });
    private todosUrl = 'api/Todos';  // URL to web api

    constructor(private http: Http) { }

    getTodos(): Promise<Todo[]> {
        return this.http.get(this.todosUrl)
            .toPromise()
            .then(response => response.json() as Todo[])
            .catch(this.handleError);
    }


    getTodo(id: number): Promise<Todo> {
        const url = `${this.todosUrl}/${id}`;
        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as Todo)
            .catch(this.handleError);
    }

    delete(id: number): Promise<void> {
        const url = `${this.todosUrl}/${id}`;
        return this.http.delete(url, { headers: this.headers })
            .toPromise()
            .then(() => null)
            .catch(this.handleError);
    }

    create(title: string): Promise<Todo> {
        return this.http
            .post(this.todosUrl, JSON.stringify({ title: title }), { headers: this.headers })
            .toPromise()
            .then(res => res.json())
            .catch(this.handleError);
    }

    update(Todo: Todo): Promise<Todo> {
        const url = `${this.todosUrl}/${Todo.todoItemId}`;
        return this.http
            .put(url, JSON.stringify(Todo), { headers: this.headers })
            .toPromise()
            .then(() => Todo)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
    }
}