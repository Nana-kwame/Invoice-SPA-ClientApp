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

export class CreateInvoice {
  recipientNumber: string
  address: string
  name: string
  title: string
  createdBy: string
  lastUpdated: string
  invoiceItems: Array<InvoiceItem>
  authorities: Array<Authority>

  constructor(recipientNumber: string,
    address: string,
    name: string,
    title: string,
    createdBy: string,
    lastUpdated: string,
    invoiceItems: Array<InvoiceItem>,
    authorities: Array<Authority>) { 

    this.recipientNumber = recipientNumber;
    this.address = address;
    this.name = name;
    this.title = title;
    this.createdBy = createdBy;
    this.lastUpdated = lastUpdated;
    this.invoiceItems = invoiceItems;
    this.authorities = authorities;
  }
}

export class UpdateInvoice {
  address: string
  name: string
  title: string
  invoiceNo: string
  invoiceItems: Array<InvoiceItem>
  authorities: Array<Authority>

  constructor(
    address: string,
    name: string,
    title: string,
    invoiceNo: string,
    invoiceItems: Array<InvoiceItem>,
    authorities: Array<Authority>) {

    this.address = address;
    this.name = name;
    this.title = title;
    this.invoiceNo = invoiceNo;
    this.invoiceItems = invoiceItems;
    this.authorities = authorities;
  }
}

export class DeleteInvoice {
  invoiceIds: Array<string>

  constructor(invoiceIds: Array<string>) {
    this.invoiceIds = invoiceIds;
  }
}

export class ApproveInvoice {
  approve: boolean
  invoiceId: string
  authority: string

  constructor(approve: boolean, invoiceId: string, authority: string) {
    this.approve = approve;
    this.invoiceId = invoiceId;
    this.authority = authority;
  }
}

export class InvoiceItem {
  name: string
  description: string
  amount: string

  constructor(name: string, description: string, amount: string) {
    this.name = name;
    this.description = description;
    this.amount = amount
  }
}

export class Authority {
  name: string
  department: string

  constructor(name: string, department: string) {
    this.name = name;
    this.department = department;
  }
}

export interface IApiResponse {
  isSuccessful: boolean;
  message: string;
}

export interface IInvoice {
  invoiceNo: string;
  title: string;
  createdby: string;
  updatedBy: string;
  createdOn: string;
  lastUpdated: string;
  approved: boolean;
  status: boolean;
  recipient: IRecipient;
  invoiceItems: Array<InvoiceItem>
  authorities: Array<Authority>
}

export interface IUserInvoices {
  invoicesCreatedByUser: IInvoice;
  invoicesApprovedByUser: IInvoice;
}

export interface IRecipient {
  recipientNumber: string;
  address: string;
  name: string;
  invoices: any;
}
