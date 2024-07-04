import { Component, Input,EventEmitter, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { response } from 'express';
import { error } from 'console';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit{
  
  
  @Output() calcelRegister = new EventEmitter();
  model : any = {}
  constructor(private account : AccountService) {

  }
   ngOnInit(): void {
     
   }

   register(){
      this.account.register(this.model).subscribe({
        next : () =>{
          this.cancel();
        },
        error : error => console.log(error)
      })
   }

   cancel(){
      this.calcelRegister.emit(false);
   }


}
