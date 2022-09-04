import { Component } from '@angular/core';
import {MenuItem} from 'primeng/api';
import { UserService } from './user.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent { 
    items: MenuItem[] = [];

    constructor(private userService: UserService) {}

    ngOnInit() {
      this.items = [
        {
            label: 'File',
            items: [{
                    label: 'New', 
                    icon: 'pi pi-fw pi-plus',
                    items: [
                        {label: 'Project'},
                        {label: 'Other'},
                    ]
                },
                {label: 'Open'},
                {label: 'Quit'}
            ]
        },
        {
            label: 'Edit',
            icon: 'pi pi-fw pi-pencil',
            items: [
                {label: 'Delete', icon: 'pi pi-fw pi-trash'},
                {label: 'Refresh', icon: 'pi pi-fw pi-refresh'}
            ]
        }
    ];
    }  
    
    callRequest(){
        this.userService.getCsvFile().subscribe({
            next: (res: any) => {
                if(res){
                    this.downloadFile(res);
                }
            },
            error: (err: any) => {
                console.error(err);
            }
        });
    }

    downloadFile(res: any){
        var type = "text/csv;charset=utf-8";
        var blob = new Blob([res], { type: type });
        var downloadUrl = window.URL.createObjectURL(blob);
        var a = document.createElement('a');
        a.href = downloadUrl;
        a.download = "csvFile.csv"
        a.click();
    }

    authenticate() {
        this.userService.login().subscribe({
            next: (res: any) => {
                if(res){
                    console.log(res.token);
                    localStorage.setItem("token", res.token);
                }
            },
            error: (err: any) => {
                console.error(err);
            }
        });
    }
}
