import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { response } from 'express';
import { error } from 'console';
import { Observable, of } from 'rxjs';
import { User } from '../_models/User';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrl: './nav.component.css'
})
export class NavComponent {

  model : any = {}
  currentUser$ : Observable<User | null> = of(null);

  constructor(public accountService : AccountService){}

  ngOnInit(): void {
      this.currentUser$ = this.accountService.currentUser$;
      console.log(this.currentUser$)
      //console.log("ngOnInit");
  }

  login(){
    this.accountService.login(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: error => console.log(error)
    })
  }

  logout(){
    this.accountService.logout();
    //console.log("logout");
  }
}
