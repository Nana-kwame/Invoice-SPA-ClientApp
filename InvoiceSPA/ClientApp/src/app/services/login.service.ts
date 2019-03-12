import { Component, Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { LoginModel } from '../models/models';

@Injectable()

export class LoginService {

  baseUrl : string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public login(loginModel: LoginModel) {
    return this.httpClient.post<boolean>(this.baseUrl + 'api/account/login', loginModel); 
  }
}

