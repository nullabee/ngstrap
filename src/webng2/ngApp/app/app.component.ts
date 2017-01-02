import { Component } from "@angular/core";
import { Globals } from './globals';


@Component({
    selector: "app",
    templateUrl: "app.component.html"
})

export class AppComponent {

    private baseApiUrl = Globals.BASE_API_URL;

}