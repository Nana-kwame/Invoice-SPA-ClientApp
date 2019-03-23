import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RegisterModel } from '../models/models';
import { AuthenticationService } from '../services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  private registerForm : FormGroup; 
  public valid: boolean;
  public errors: Array<string> = [];

  constructor(private authService : AuthenticationService) { }

  ngOnInit() {
    this.createForm();
  }

  private createForm() {
    this.registerForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required]),
      username: new FormControl('', [Validators.required])
    });
  }

  public register() {

    this.errors = [];

    this.validateForm();

    if (this.errors.length > 0) {
      return;
    }

    let firstname = this.getFirstName();
    let lastname = this.getLastName();
    let username = this.getUsername();
    let password = this.getPassword();
    let phonenumber = this.getPhoneNumber();

    var registerModel = new RegisterModel(firstname, lastname, username, password, phonenumber);

    this.authService.register(registerModel).subscribe(result => {
      this.valid = result;
      if (this.valid === false) {
        this.errors.push("Failed to register")
        return;
      }
    }, error => {
      this.errors.push("An error occured");
    }); 
  }

  private validateForm() {
    let firstname = this.getFirstName();
    let lastname = this.getLastName();
    let username = this.getUsername();
    let password = this.getPassword();
    let phonenumber = this.getPhoneNumber();
    let confirmPassword = this.getConfirmPassword();

    if (firstname.length == 0) {
      this.errors.push("Please provide a First Name");
    }
    if (lastname.length == 0) {
      this.errors.push("Please provide a Last Name");
    }
    if (phonenumber.length == 0) {
      this.errors.push("Please provide a Phone Number");
    }
    if (username.length == 0) {
      this.errors.push("Please provide a Username")
    }
    if (password.length == 0) {
      this.errors.push("Please enter a Password");
    }
    if (confirmPassword.length == 0) {
      this.errors.push("Please repeat the Password");
    }

    if (password !== '' && confirmPassword !== '' && password !== confirmPassword) {
      this.errors.push("Password need to match")
    }    
  }

  public getUsername() {
    return this.registerForm.get('username').value;
  }

  public getPassword() {
    return this.registerForm.get('password').value;
  }

  public getFirstName() {
    return this.registerForm.get("firstName").value;
  }

  public getLastName() {
    return this.registerForm.get("lastName").value;
  }

  public getConfirmPassword() {
    return this.registerForm.get("confirmPassword").value;
  }

  public getPhoneNumber() {
    return this.registerForm.get("phoneNumber").value;
  }
}
