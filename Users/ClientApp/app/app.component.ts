import { Component, OnInit } from '@angular/core';
import { DataService } from './data.service';
import { User } from './users';

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    providers: [DataService]
})
export class AppComponent implements OnInit {
    users: User[];
    total: number = 0;
    active: number = 0;
    user: User = new User();

    constructor(private dataService: DataService) { }

    ngOnInit() {
        this.loadUsers();
        
    }

    setUsers() {
        this.total = this.users.length;
        this.getActiveUsers();
    }

    getActiveUsers() {
        this.active = 0;
        for (let el of this.users) {
            if (el.active) {
                this.active++;
            }
        }
    }

    loadUsers() {
        this.dataService.getUsers()
            .subscribe((data: User[]) => this.users = data);
    }

    save() {
        this.dataService.updateUser(this.user)
            .subscribe(data => this.loadUsers());
        this.user = new User();
    }

    changeStatus(u: User) {
        this.user = u;
        this.user.active = !this.user.active;
        this.save();
    } 

    
}