import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormBuilder, FormArray } from '@angular/forms';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})
export class InvoiceComponent implements OnInit {

  public invoiceForm: FormGroup;
  public invoiceItems: FormArray;
  public authorities: FormArray;

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.createInvoiceForm();
  }

  private createInvoiceForm() {
    this.invoiceForm = this.formBuilder.group({
      recipientName: '',
      recipientAddress: '',
      invoiceTitle: '',
      invoiceNo: '',
      invoiceItems: this.formBuilder.array([this.createInvoiceItem()]),
      total: '',
      authorities: this.formBuilder.array([this.creatAuthority()])
    });
  }

  private createInvoiceItem(): FormGroup {
    return this.formBuilder.group({
      itemName: '',
      itemDescription: '',
      itemAmount: '',
    });
  }

  private creatAuthority(): FormGroup {
    return this.formBuilder.group({
      authorityName: '',
      authorityDepartment: '',
    });
  }

  public addInvoiceItem() {
    this.invoiceItems = this.invoiceForm.get('invoiceItems') as FormArray;
    this.invoiceItems.push(this.createInvoiceItem());
  }

  public removeInvoiceItem(i) {
    this.invoiceItems = this.invoiceForm.get('invoiceItems') as FormArray;
    this.invoiceItems.removeAt(i);
  }

  public addAuthority() {
    this.authorities = this.invoiceForm.get('authorities') as FormArray;
    this.authorities.push(this.creatAuthority());
  }

  public removeAuthority(i) {
    this.authorities = this.invoiceForm.get('authorities') as FormArray;
    this.authorities.removeAt(i);
  }
}
