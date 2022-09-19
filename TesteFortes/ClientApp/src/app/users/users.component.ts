import { Component, OnInit } from '@angular/core';
import { error, log } from 'console';
import { UserDataService } from '../_data-services/user.data-service';

@Component({
    selector: 'app-users',
    templateUrl: './users.component.html',
    styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

    users: any[] = [];
    user: any = {};
    showlist: Boolean = true;

    constructor(private userDataService: UserDataService) { }

    ngOnInit() {
        this.get();
    }

    get() {
        this.userDataService.get().subscribe((data: any[]) => {
            this.users = data;
            this.showlist = true;
        }, error => {
            console.log(error);
            alert('erro interno do sistema');
        });
    }

    save(){
        console.log(this.user);
        if(this.user.userId){
            this.put();
        }
        else{
            this.post();
        }
    }

    post() {
        this.userDataService.post(this.user).subscribe(data => {
            if (data) {
                alert('Usuário cadastrado com sucesso');
                this.get();
                this.user = {};
            } else {
                alert('Erro ao cadastrar usuário');
            }

        }, error => {
            console.log(error);
            alert('erro interno do sistema');
        });
    }

    put() {
        this.userDataService.put(this.user).subscribe(data => {
            if (data) {
                alert('Usuário atualizado com sucesso');
                this.get();
                this.user = {};
            } else {
                alert('Erro ao atualizar usuário');
            }

        }, error => {
            console.log(error);
            alert('erro interno do sistema');
        });
    }

    openDetails(user) {
        console.log(user);
        this.showlist = false;
        this.user = user;
    }
}
