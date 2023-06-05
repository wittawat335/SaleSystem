import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Sale } from 'src/app/Interfaces/sale';
import { SalesDetail } from 'src/app/Interfaces/sale-detail';

@Component({
  selector: 'app-sale-detail-dialog',
  templateUrl: './sale-detail-dialog.component.html',
  styleUrls: ['./sale-detail-dialog.component.css'],
})
export class SaleDetailDialogComponent implements OnInit {
  createDate: string = '';
  documentNumber: string = '';
  paymentType: string = '';
  total: string = '';
  saleDetail: SalesDetail[] = [];
  displayedColumns: string[] = ['product', 'quantity', 'price', 'total'];

  constructor(@Inject(MAT_DIALOG_DATA) public sale: Sale) {
    this.createDate = sale.createDate!;
    this.documentNumber = sale.documentNumber!;
    this.paymentType = sale.paymentType;
    this.total = sale.totalText;
    this.saleDetail = sale.saleDetails;
  }

  ngOnInit(): void {}
}
