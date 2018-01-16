import { Component, Inject } from '@angular/core';
import { OnInit, Input } from '@angular/core';
import { Http } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TodoItem } from './todoitem';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';

@Component({
    selector: 'todo',
    templateUrl: './todo.component.html'
})
export class TodoComponent implements OnInit {
    private api: string;

    public todos: Observable<TodoItem[]>;    
    public todoForm: FormGroup;
    
    constructor(
        private fb: FormBuilder,
        private http: Http,
        @Inject('API_URL') private baseUrl: string)
    {
        this.api = this.baseUrl + 'api/todo/';

        this.createForm();
    } 

    ngOnInit() {
        this.http.get(this.api).subscribe(result => {
            this.todos = of(result.json() as TodoItem[]);
        }, error => console.error(error));
    }    

    public addTodo() {
        const formModel = this.todoForm.value;

        const todo = {
            name: formModel.name,
            description: formModel.description,
            isComplete: formModel.isComplete
        } as TodoItem;

        this.http.post(this.api, todo).subscribe(result => {
            //this.todos.
            //this.todos(result.json() as TodoItem);
        }, error => console.error(error));
    }  

    public updateTodo(todo: TodoItem) {

        this.http.put(this.api + todo.id, todo).subscribe(result => {
            
        }, error => console.error(error));
    }

    private createForm() {
        this.todoForm = this.fb.group({
            name: ['', Validators.required],
            description: '',
            isComplete: false
        });
    }
}