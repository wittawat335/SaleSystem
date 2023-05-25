import { Session } from './../Interfaces/session';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment.development';

@Injectable({
  providedIn: 'root',
})
export class UtilityService {
  constructor(private snackBar: MatSnackBar) {}

  showMessage(message: string, action: string) {
    this.snackBar.open(message, action, {
      horizontalPosition: 'end',
      verticalPosition: 'top',
      duration: 3000,
    });
  }

  setSessionUser(session: Session) {
    localStorage.setItem(
      environment.keyLocalAuth,
      JSON.stringify(session.token)
    );
    localStorage.setItem('user', JSON.stringify(session));
  }

  getSessionUser() {
    const data = localStorage.getItem('user');
    const user = JSON.parse(data!);
    return user;
  }

  removeSessionUser() {
    localStorage.removeItem('user');
    localStorage.removeItem(environment.keyLocalAuth);
  }
}
