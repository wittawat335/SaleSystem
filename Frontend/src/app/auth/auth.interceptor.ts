import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { UtilityService } from '../services/utility.service';
import Swal from 'sweetalert2';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private router: Router, private utService: UtilityService) {}
  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = localStorage.getItem(environment.keyLocalAuth);
    if (token != null) {
      const clonedReq = req.clone({
        headers: req.headers.set('Authorization', 'Bearer  ' + token),
      });
      console.log(clonedReq);
      return next.handle(clonedReq).pipe(
        tap(
          (succ) => {},
          (err) => {
            if (err.status == 401) {
              Swal.fire({
                icon: 'error',
                title: 'สิทธื์ไม่ถึงตามที่กำหนด',
                text: 'คุณไม่สามารใช้งานหน้านี้ได้',
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'ตกลง',
              }).then((result) => {
                if (result.isConfirmed) {
                  localStorage.removeItem('token');
                  this.router.navigateByUrl('/login');
                }
              });
            }
          }
        )
      );
    } else {
      return next.handle(req.clone());
    }
  }
}
