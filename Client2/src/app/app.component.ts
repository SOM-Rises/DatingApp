import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { response } from 'express';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'Dating App';
  users : any;

  constructor( private Https : HttpClient) {}
  ngOnInit(): void {
    
    this.Https.get('https://localhost:5001/api/users').subscribe({
      next : response => this.users = response,
      error : error => console.log(error),
      complete : () => console.log("Resquest Has Complete")
    })

  }

  
}
