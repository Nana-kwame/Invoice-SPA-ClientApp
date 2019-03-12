import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginModel } from '../models/models';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public valid : boolean;

  constructor(private loginService : LoginService) { }

  ngOnInit() {
    this.createForm();
  }

  private createForm() {
    this.loginForm = new FormGroup({
      username : new FormControl('', [Validators.required]),
      password : new FormControl('', [Validators.required])
    });
  }

  public login() {

    if (!this.loginForm.valid) {
      this.valid = false;
      return;
    }
    
    let username = this.getUsername();
    let password = this.getPassword();

    var loginModel = new LoginModel(username, password);

    this.loginService.login(loginModel).subscribe(result => {
      this.valid = result;
      if (this.valid) {
        console.log('working');
      }
    }, error => {
      console.log('error');
    }); 
  }

  public getUsername() {
    return this.loginForm.get('username').value;
  }

  public getPassword() {
    return this.loginForm.get('password').value;
  }
}
