import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/Interfaces/product';
import { ProductService } from 'src/app/services/product.service';
import { UtilityService } from 'src/app/services/utility.service';
import Swal from 'sweetalert2';
import { ProductDialogComponent } from '../../dialogs/product-dialog/product-dialog.component';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'Name',
    'Category',
    'Stock',
    'Price',
    'isActive',
    'Actions',
  ];
  dataSource = new MatTableDataSource<Product>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  constructor(
    private dialog: MatDialog,
    private productService: ProductService,
    private utService: UtilityService
  ) {}

  ngOnInit(): void {
    this.BindDataTable();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  BindDataTable() {
    this.productService.GetList().subscribe({
      next: (data) => {
        if (data.status) {
          this.dataSource.data = data.value;
        } else {
          this.utService.showMessage(data.message, 'Oops!');
        }
      },
      error: (e) => {},
    });
  }

  Filter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  newProduct() {
    this.dialog
      .open(ProductDialogComponent, {
        disableClose: true,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') {
          this.BindDataTable();
        }
      });
  }

  updateProduct(data: Product) {
    this.dialog
      .open(ProductDialogComponent, {
        disableClose: true,
        data: data,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') {
          this.BindDataTable();
        }
      });
  }

  deleteProduct(obj: Product) {
    Swal.fire({
      title: 'คุณต้องการลบ' + ' ' + obj.name + ' ' + 'ใช่หรือไม่',
      //text: data.name,
      icon: 'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'ใช่',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'ไม่ใช่',
    }).then((result) => {
      if (result.isConfirmed) {
        this.productService.Delete(obj.productId).subscribe({
          next: (data) => {
            if (data.status) {
              this.utService.showMessage(data.message, 'success');
              this.BindDataTable();
            } else {
              this.utService.showMessage(data.message, 'Error');
            }
          },
          error: (e) => {},
        });
      }
    });
  }
}
