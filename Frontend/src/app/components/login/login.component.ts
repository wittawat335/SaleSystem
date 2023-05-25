import { Login } from './../../Interfaces/login';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { UtilityService } from 'src/app/services/utility.service';
import { environment } from 'src/environments/environment.development';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  formLogin: FormGroup;
  checkPassword: boolean = true;
  showLoading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private userService: UserService,
    private utService: UtilityService
  ) {
    this.formLogin = this.fb.group({
      email: ['', Validators.email],
      password: ['', Validators.required],
    });
  }
  // 
  ngOnInit(): void {
    if (localStorage.getItem(environment.keyLocalAuth) != null)
      this.router.navigateByUrl('/pages');
  }

  LoginUser() {
    this.showLoading = true;

    const req: Login = {
      email: this.formLogin.value.email,
      password: this.formLogin.value.password,
    };

    this.userService.Login(req).subscribe({
      next: (data) => {
        if (data.status) {
          this.utService.setSessionUser(data.value);
          this.router.navigate(['pages']);
        } else {
          this.utService.showMessage(data.message, 'Oop!');
        }
      },
      complete: () => {
        this.showLoading = false;
      },
      error: () => {
        this.utService.showMessage('Error', 'Oops!');
      },
    });
  }
}
