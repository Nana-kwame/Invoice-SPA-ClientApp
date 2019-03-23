export class LoginModel {
  username: string
  password: string
  remember: boolean

  constructor(username: string, password: string, remember: boolean) {
    this.username = username;
    this.password = password;
    this.remember = remember;
  }
}

export class RegisterModel {
  firstname: string
  lastname: string
  username: string
  password: string
  phonenumber: string

  constructor(firstname: string, lastname: string, username: string, password: string, phonenumber: string) {
    this.firstname = firstname;
    this.lastname = lastname;
    this.password = password;
    this.phonenumber = phonenumber;
    this.username = username;
  }
}

export class ValidateUserModel {
  lastname: string
  phonenumber: string

  constructor(lastname: string, phonenumber: string) {
    this.lastname = lastname;
    this.phonenumber = phonenumber;
  }
}

export class ResetPasswordModel {
  password: string
  username: string

  constructor(password: string, username: string) {
    this.password = password;
    this.username = username;
  }
}

export interface IUiUser {
  username: string
}
