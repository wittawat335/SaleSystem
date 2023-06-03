import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { User } from 'src/app/Interfaces/user';
import { UserService } from 'src/app/services/user.service';
import { UtilityService } from 'src/app/services/utility.service';
import { UserDialogComponent } from '../../dialogs/user-dialog/user-dialog.component';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = [
    'FullName',
    'Email',
    'RoleName',
    'isActive',
    'Actions',
  ];
  dataSource = new MatTableDataSource<User>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private dialog: MatDialog,
    private userService: UserService,
    private utService: UtilityService
  ) {}

  ngOnInit(): void {
    this.BindDataTable();
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  BindDataTable() {
    this.userService.GetList().subscribe({
      next: (data) => {
        if (data.status) {
          this.dataSource.data = data.value;
        } else {
          this.utService.showMessage(data.message, 'Oop!');
        }
      },
    });
  }

  Filter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  Add() {
    this.dialog
      .open(UserDialogComponent, {
        disableClose: true,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') this.BindDataTable();
      });
  }

  Update(obj: User) {
    this.dialog
      .open(UserDialogComponent, {
        disableClose: true,
        data: obj,
      })
      .afterClosed()
      .subscribe((result) => {
        if (result === 'true') this.BindDataTable();
      });
  }

  Delete(obj: User) {
    Swal.fire({
      title: 'คุณต้องการลบ' + ' ' + obj.fullName + ' ' + 'ใช่หรือไม่',
      //text: obj.fullName,
      icon: 'warning',
      confirmButtonColor: '#3085d6',
      confirmButtonText: 'ใช่',
      showCancelButton: true,
      cancelButtonColor: '#d33',
      cancelButtonText: 'ไม่ใช่',
    }).then((result) => {
      if (result.isConfirmed) {
        this.userService.Delete(obj.userId).subscribe({
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
