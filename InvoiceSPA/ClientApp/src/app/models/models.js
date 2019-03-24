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
var CreateInvoice = /** @class */ (function () {
    function CreateInvoice(recipientNumber, address, name, title, createdBy, lastUpdated, invoiceItems, authorities) {
        this.recipientNumber = recipientNumber;
        this.address = address;
        this.name = name;
        this.title = title;
        this.createdBy = createdBy;
        this.lastUpdated = lastUpdated;
        this.invoiceItems = invoiceItems;
        this.authorities = authorities;
    }
    return CreateInvoice;
}());
exports.CreateInvoice = CreateInvoice;
var UpdateInvoice = /** @class */ (function () {
    function UpdateInvoice(address, name, title, invoiceNo, invoiceItems, authorities) {
        this.address = address;
        this.name = name;
        this.title = title;
        this.invoiceNo = invoiceNo;
        this.invoiceItems = invoiceItems;
        this.authorities = authorities;
    }
    return UpdateInvoice;
}());
exports.UpdateInvoice = UpdateInvoice;
var DeleteInvoice = /** @class */ (function () {
    function DeleteInvoice(invoiceIds) {
        this.invoiceIds = invoiceIds;
    }
    return DeleteInvoice;
}());
exports.DeleteInvoice = DeleteInvoice;
var ApproveInvoice = /** @class */ (function () {
    function ApproveInvoice(approve, invoiceId, authority) {
        this.approve = approve;
        this.invoiceId = invoiceId;
        this.authority = authority;
    }
    return ApproveInvoice;
}());
exports.ApproveInvoice = ApproveInvoice;
var InvoiceItem = /** @class */ (function () {
    function InvoiceItem(name, description, amount) {
        this.name = name;
        this.description = description;
        this.amount = amount;
    }
    return InvoiceItem;
}());
exports.InvoiceItem = InvoiceItem;
var Authority = /** @class */ (function () {
    function Authority(name, department) {
        this.name = name;
        this.department = department;
    }
    return Authority;
}());
exports.Authority = Authority;
//# sourceMappingURL=models.js.map