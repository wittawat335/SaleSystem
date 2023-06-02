import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Role } from 'src/app/Interfaces/role';
import { User } from 'src/app/Interfaces/user';
import { RoleService } from 'src/app/services/role.service';
import { UserService } from 'src/app/services/user.service';
import { UtilityService } from 'src/app/services/utility.service';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.css'],
})
export class UserDialogComponent implements OnInit {
  fgUser: FormGroup;
  checkPassword: boolean = true;
  titleAction: string = 'เพิ่ม';
  buttonAction: string = 'บันทึก';
  listRole: Role[] = [];

  constructor(
    private dialog: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public userData: User, //Inject หลัง Implement ต้องให้เป็นสีเขียว ถ้าเป็นาีเหลืองจะ error
    private fb: FormBuilder,
    private roleService: RoleService,
    private userService: UserService,
    private utService: UtilityService
  ) {
    this.fgUser = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', Validators.email],
      idRole: ['', Validators.required],
      password: ['', Validators.required],
      isActive: ['1', Validators.required],
    });

    if (this.userData != null) {
      this.titleAction = 'แก้ไข';
      this.buttonAction = 'อัพเดท';
    }

    this.roleService.GetList().subscribe({
      next: (data) => {
        if (data.status) this.listRole = data.value;
      },
      error: (e) => {},
    });
  }

  ngOnInit(): void {
    this.bindData();
  }

  bindData() {
    if (this.userData != null) {
      this.fgUser.patchValue({
        fullName: this.userData.fullName,
        email: this.userData.email,
        idRole: this.userData.roleId,
        password: this.userData.password,
        isActive: this.userData.isActive.toString(),
      });
    }
  }

  submitData() {
    const data: User = {
      userId:
        this.userData == null
          ? '00000000-0000-0000-0000-000000000000'
          : this.userData.userId,
      fullName: this.fgUser.value.fullName,
      email: this.fgUser.value.email,
      roleId: this.fgUser.value.idRole,
      password: this.fgUser.value.password,
      isActive: parseInt(this.fgUser.value.isActive),
    };

    if (this.userData == null) {
      this.userService.Register(data).subscribe({
        next: (data) => {
          if (data.status) {
            this.utService.showMessage(data.message, 'success');
            this.dialog.close('true');
          } else {
            this.utService.showMessage(data.message, 'error');
          }
        },
        error: (e) => {},
      });
    } else {
      this.userService.Update(data).subscribe({
        next: (data) => {
          if (data.status) {
            this.utService.showMessage(data.message, 'success');
            this.dialog.close('true');
          } else {
            this.utService.showMessage(data.message, 'error');
          }
        },
        error: (e) => {},
      });
    }
  }
}
