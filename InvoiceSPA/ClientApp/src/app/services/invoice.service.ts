import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CreateInvoice, IApiResponse, UpdateInvoice, DeleteInvoice, ApproveInvoice, IInvoice, IUserInvoices } from '../models/models';

@Injectable()

export class InvoiceService {

  baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  public create(createInvoice: CreateInvoice) {
    return this.httpClient.post<IApiResponse>(this.baseUrl + 'api/invoice/create', createInvoice);
  }

  public update(updateInvoice: UpdateInvoice) {
    return this.httpClient.post<IApiResponse>(this.baseUrl + 'api/invoice/update', updateInvoice);
  }

  public delete(deleteInvoice: DeleteInvoice) {
    return this.httpClient.post<IApiResponse>(this.baseUrl + 'api/invoice/delete', deleteInvoice);
  }

  public get() {
    return this.httpClient.get<IInvoice>(this.baseUrl + 'api/invoice/get');
  }

  public getUserInvoices() {
    return this.httpClient.get<IUserInvoices>(this.baseUrl + 'api/invoice/getuserinvoices');
  }

  public approveInvoice(approveInvoice: ApproveInvoice) {
    return this.httpClient.post<IApiResponse>(this.baseUrl + 'api/invoice/approveinvoice', approveInvoice );
  }

}
