import { Response } from './../Interfaces/response';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Login } from '../Interfaces/login';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private urlApi: string = environment.endpoint + 'User';

  constructor(private http: HttpClient) {}

  GetList(): Observable<Response> {
    return this.http.get<Response>(this.urlApi);
  }

  Login(req: Login): Observable<Response> {
    return this.http.post<Response>(`${this.urlApi}/Login`, req);
  }

  Register(req: Login): Observable<Response> {
    return this.http.post<Response>(`${this.urlApi}/Register`, req);
  }

  Update(req: Login): Observable<Response> {
    return this.http.put<Response>(`${this.urlApi}/Update`, req);
  }

  Delete(id: string): Observable<Response> {
    return this.http.delete<Response>(`${this.urlApi}/${id}`);
  }
}
