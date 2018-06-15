import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'people',
    templateUrl: './people.component.html'
})
export class PeopleComponent {
    public people: People[];
    public search: String;

    performSearch() : any {
        let search = (this.search ? this.search : "");

        this.http.get("http://localhost:64913/api/People?search=" + search)
            .subscribe(result => {
            this.people = result.json() as People[];
        }, error => {
            console.error(error);
        });
    }

    constructor(public http: Http, @Inject('API_URL') baseUrl: string) {
        this.performSearch();
    }
}

interface People {
    name: string;
    gender: string;
    height: string;
    skinColor: string;
}
