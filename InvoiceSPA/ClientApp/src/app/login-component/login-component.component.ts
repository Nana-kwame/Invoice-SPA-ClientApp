import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginModel } from '../models/models';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup;
  public valid: boolean;
  public errors: Array<string> = [];

  constructor(private authService: AuthenticationService) { }

  ngOnInit() {
    this.createForm();
  }

  private createForm() {
    this.loginForm = new FormGroup({
      username : new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      remember: new FormControl()
    });
  }

  public login() {

    this.errors = [];

    this.validateForm();

    if (this.errors.length > 0) {
      return;
    }

    let username = this.getUsername();
    let password = this.getPassword();
    let remember = this.getRemeber();

    var loginModel = new LoginModel(username, password, remember);

    this.authService.login(loginModel).subscribe(result => {
      this.valid = result;
      if (this.valid === false) {
        this.errors.push("Log in failed, please provide a valid username or password");
        return;
      } else {
        //redirect user to dashboard
      }
    }, error => {
        this.errors.push("Failed to log in");
    }); 
  }

  private validateForm() {
    let username = this.getUsername();

    if (username.length == 0) {
      this.errors.push("Please provide a username")
    }

    let password = this.getPassword();

    if (password.length == 0) {
      this.errors.push("Please provide a password")
    }
  }

  private getUsername() {
    return this.loginForm.get('username').value;
  }

  private getPassword() {
    return this.loginForm.get('password').value;
  }

  private getRemeber() {
    return this.loginForm.get("remember").value;
  }
}
