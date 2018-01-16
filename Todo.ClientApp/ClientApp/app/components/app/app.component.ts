import { Component } from '@angular/core';
import { Http } from '@angular/http'

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private _httpService: Http) { }
}
