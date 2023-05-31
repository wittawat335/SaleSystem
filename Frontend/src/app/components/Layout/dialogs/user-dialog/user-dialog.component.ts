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
  userFg: FormGroup;
  checkPassword: boolean = true;
  titleAction: string = 'New';
  buttonAction: string = 'Save';
  listRole: Role[] = [];

  constructor(
    private dialog: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public userData: User, //Inject หลัง Implement ต้องให้เป็นสีเขียว ถ้าเป็นาีเหลืองจะ error
    private fb: FormBuilder,
    private roleService: RoleService,
    private userService: UserService,
    private utService: UtilityService
  ) {
    this.userFg = this.fb.group({
      fullName: ['', Validators.required],
      email: ['', Validators.email],
      idRole: ['', Validators.required],
      password: ['', Validators.required],
      isActive: ['', Validators.required],
    });

    if (this.userData != null) {
      this.titleAction = 'edit';
      this.buttonAction = 'Update';
    }

    this.userService.GetList().subscribe({
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
      this.userFg.patchValue({
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
      fullName: this.userFg.value.fullName,
      email: this.userFg.value.email,
      roleId: this.userFg.value.idRole,
      password: this.userFg.value.password,
      isActive: parseInt(this.userFg.value.isActive),
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
