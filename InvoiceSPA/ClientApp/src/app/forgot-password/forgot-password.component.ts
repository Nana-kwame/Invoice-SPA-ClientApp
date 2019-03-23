import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { ValidateUserModel, ResetPasswordModel } from '../models/models';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  private resetPasswordForm: FormGroup;
  private validateUserForm: FormGroup;
  public validUser: boolean;
  public valid: boolean;
  private username: string;
  public step: number = 1;
  public errors: Array<string> = []; 

  constructor(private authService : AuthenticationService) { }

  ngOnInit() {
    this.createValidateUserForm();
    this.createResetPasswordForm();
  }

  private createValidateUserForm() {
    this.validateUserForm = new FormGroup({
      lastName: new FormControl('', [Validators.required]),
      phoneNumber: new FormControl('', [Validators.required])
    });
  }

  private createResetPasswordForm() {
    this.resetPasswordForm = new FormGroup({
      password: new FormControl('', [Validators.required]),
      confirmPassword: new FormControl('', [Validators.required])
    });
  }

  public validateUser() {

    this.errors = [];

    this.validateFirstStep();

    if (this.errors.length > 0) {
      return;
    }

    let lastname = this.getLastName();
    let phonenumber = this.getPhoneNumber();

    var validateUserModel = new ValidateUserModel(lastname, phonenumber);

    this.authService.validateUser(validateUserModel).subscribe(result => {
      this.username = result.username;
      if (this.username == null) {
        this.errors.push("No user found the credentials provided")
        return;
      }
      else {
        this.step++;
      }
    }, error => {
      this.errors.push("An error occured, please re-enter your credentials");
    });
  }

  public resetPassword() {

    this.errors = [];

    this.validateSecondStep();

    if (this.errors.length > 0) {
      return;
    }

    let username = this.username;
    let password = this.getPassword();

    var resetPasswordModel = new ResetPasswordModel(password, username);

    this.authService.resetPassword(resetPasswordModel).subscribe(result => {
      this.valid = result;
      if (this.valid) {
        console.log('working');
      }
    }, error => {
      console.log('error');
    }); 
  }

  public validateFirstStep() {
    let lastName = this.getLastName();

    if (lastName.length == 0) {
      this.errors.push("Please provide a Last Name");
    }

    let phoneNumber = this.getPhoneNumber();

    if (phoneNumber.length == 0) {
      this.errors.push("Please provide a Phone Number");
    }
  }

  public validateSecondStep() {
    let password = this.getPassword();
    let confirmPassword = this.getConfirmPassword();

    if (password.length == 0) {
      this.errors.push("Please enter a password");
    }
    if (confirmPassword.length == 0) {
      this.errors.push("Please repeat the password");
    }

    if (password !== '' && confirmPassword !== '' && password !== confirmPassword) {
      this.errors.push("Password need to match")
    }
  }

  public getLastName() {
    return this.validateUserForm.get("lastName").value;
  }

  public getPhoneNumber() {
    return this.validateUserForm.get("phoneNumber").value;
  }

  public getPassword() {
    return this.resetPasswordForm.get('password').value;
  }

  public getConfirmPassword() {
    return this.resetPasswordForm.get("confirmPassword").value;
  }
}
