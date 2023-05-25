import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ResponseApi } from '../Interfaces/responseApi';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  private urlApi: string = environment.endpoint + 'Role';

  constructor(private http: HttpClient) {}

  GetList(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.urlApi);
  }
}
