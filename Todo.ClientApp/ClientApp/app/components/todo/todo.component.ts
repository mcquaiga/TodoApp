import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'todo',
    templateUrl: './todo.component.html'
})
export class TodoComponent {
    public todos: TodoItem[];
    private http: Http;
    private baseUrl: string;

    constructor(http: Http, @Inject('API_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;

        this.http.get(baseUrl + 'api/todo/').subscribe(result => {
            this.todos = result.json() as TodoItem[];
        }, error => console.error(error));
    } 
    //name: string, isComplete: boolean
    public addTodo() {
        var todo: TodoItem;
        todo = { name: 'Todo from client', isComplete: false } as TodoItem;
        this.http.post(this.baseUrl + 'api/todo/', todo).subscribe(result => {
            this.todos.push(result.json() as TodoItem);
        }, error => console.error(error));
    }
}

interface TodoItem {
    id: string;
    name: string;
    isComplete: boolean;
}
