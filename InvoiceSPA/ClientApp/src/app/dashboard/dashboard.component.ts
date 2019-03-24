import { Component, OnInit } from '@angular/core';
import { InvoiceService } from '../services/invoice.service';
import { IUserInvoices } from '../models/models';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  public userInvoices : IUserInvoices; 

  constructor(private invoiceService : InvoiceService) { }

  ngOnInit() {
    this.getUserInvoices();
  }

  private getUserInvoices() {
    this.invoiceService.getUserInvoices().subscribe(result => {
      this.userInvoices = result; 
    }, error => {
      //redirect to error page/error message
    });
  }
}
