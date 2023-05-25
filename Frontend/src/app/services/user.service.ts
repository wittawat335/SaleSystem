import { ResponseApi } from '../Interfaces/responseApi';
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

  GetList(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.urlApi);
  }

  Login(req: Login): Observable<ResponseApi> {
    return this.http.post<ResponseApi>(`${this.urlApi}/Login`, req);
  }

  Register(req: Login): Observable<ResponseApi> {
    return this.http.post<ResponseApi>(`${this.urlApi}/Register`, req);
  }

  Update(req: Login): Observable<ResponseApi> {
    return this.http.put<ResponseApi>(`${this.urlApi}/Update`, req);
  }

  Delete(id: string): Observable<ResponseApi> {
    return this.http.delete<ResponseApi>(`${this.urlApi}/${id}`);
  }
}
