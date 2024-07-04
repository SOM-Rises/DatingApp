import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { response } from 'express';
import { AccountService } from './_services/account.service';
import { User } from './_models/User';
import { json } from 'stream/consumers';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'Dating App';

  constructor( private Https : HttpClient, private accountService : AccountService) {}
  ngOnInit(): void {
      this.setCurrentUser();
      //console.log("ngOnInit in appcomponent");
  }

  setCurrentUser(){
    const UserStirng = localStorage.getItem('user');
    if(!UserStirng) return;
    const user : User = JSON.parse(UserStirng);
    this.accountService.setCurrentUser(user);
    console.log("setCurrentUser");
  }

  
}
