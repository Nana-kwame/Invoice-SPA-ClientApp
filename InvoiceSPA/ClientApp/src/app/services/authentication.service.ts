import { Component, Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { LoginModel, RegisterModel, ValidateUserModel, ResetPasswordModel, IUiUser } from '../models/models';

@Injectable()

export class AuthenticationService {

  baseUrl : string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public login(loginModel: LoginModel) {
    return this.httpClient.post<boolean>(this.baseUrl + 'api/account/login', loginModel); 
  }

  public register(registerModel: RegisterModel) {
    return this.httpClient.post<boolean>(this.baseUrl + 'api/account/register', registerModel); 
  }

  public validateUser(validateUserModel: ValidateUserModel) {
    return this.httpClient.post<IUiUser>(this.baseUrl + 'api/account/validateuser', validateUserModel); 
  }

  public resetPassword(resetPasswordModel: ResetPasswordModel) {
    return this.httpClient.post<boolean>(this.baseUrl + 'api/account/changepassword', resetPasswordModel); 
  }

  public isAuthenticated() {
    return this.httpClient.get<boolean>(this.baseUrl + 'api/account/isauthenticated'); 
  }

  public logOut() {
    return this.httpClient.post(this.baseUrl + 'api/account/logout', {});
  }
}

