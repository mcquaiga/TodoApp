import { Component, Inject } from '@angular/core';
import { OnChanges, Input } from '@angular/core';
import { Http } from '@angular/http';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { TodoItem } from './todoitem';
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'todo-detail',
    templateUrl: './todo-detail.component.html'
})

export class TodoDetailComponent implements OnChanges {
    @Input() todo: TodoItem;

    api: string;
    todoForm: FormGroup;

    constructor(
        private fb: FormBuilder,
        private http: Http,
        @Inject('API_URL') private baseUrl: string) {

        this.api = this.baseUrl + 'api/todo/';

        this.createForm();

        this.watch();        
    }

    public removeTodo() {
        this.http.delete(this.api + this.todo.id).subscribe(result => {
            this.ngOnChanges();
        }, error => console.error(error));
    }

    public updateTodo(todo: TodoItem) {
        this.http.put(this.api + todo.id, todo).subscribe(result => {
            this.ngOnChanges();
        }, error => console.error(error));
    }

    ngOnChanges() {
        this.todoForm.reset({
            name: this.todo.name,
            description: this.todo.description,
            isComplete: this.todo.isComplete
        });
    }

    private watch() {
        //const isCompleteControl = this.todoForm.get('isComplete');

        //if (isCompleteControl !== null) {
        //    isCompleteControl.valueChanges.forEach(
        //        (value: boolean) => this.updateTodo(this.todo)
        //    );
        //}
    }

    private createForm() {
        this.todoForm = this.fb.group({
            name: ['', Validators.required],
            description: '',
            isComplete: false,
            createdDateTime: '',
        });
    }
}