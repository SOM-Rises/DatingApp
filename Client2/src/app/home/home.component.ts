import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

    users : any;
    registerMode = false;
    constructor(private Https : HttpClient){  

    }
    ngOnInit(): void {  
        this.getUser();
    }

    getUser(){
      this.Https.get('https://localhost:5001/api/users').subscribe({
        next : response => this.users = response,
        error : error => console.log(error),
        complete : () => console.log("Resquest Has Complete")
      })
      //console.log("getUser");
    }

    registerToggle(){
      this.registerMode = !this.registerMode
    }

    cancelRegisterMode(event : boolean){
      this.registerMode = event;
    }
}
