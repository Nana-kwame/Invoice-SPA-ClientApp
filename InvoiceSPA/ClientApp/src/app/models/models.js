"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LoginModel = /** @class */ (function () {
    function LoginModel(username, password, remember) {
        this.username = username;
        this.password = password;
        this.remember = remember;
    }
    return LoginModel;
}());
exports.LoginModel = LoginModel;
var RegisterModel = /** @class */ (function () {
    function RegisterModel(firstname, lastname, username, password, phonenumber) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.password = password;
        this.phonenumber = phonenumber;
        this.username = username;
    }
    return RegisterModel;
}());
exports.RegisterModel = RegisterModel;
var ValidateUserModel = /** @class */ (function () {
    function ValidateUserModel(lastname, phonenumber) {
        this.lastname = lastname;
        this.phonenumber = phonenumber;
    }
    return ValidateUserModel;
}());
exports.ValidateUserModel = ValidateUserModel;
var ResetPasswordModel = /** @class */ (function () {
    function ResetPasswordModel(password, username) {
        this.password = password;
        this.username = username;
    }
    return ResetPasswordModel;
}());
exports.ResetPasswordModel = ResetPasswordModel;
//# sourceMappingURL=models.js.map