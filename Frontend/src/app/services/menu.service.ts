import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ResponseApi } from '../Interfaces/responseApi';

@Injectable({
  providedIn: 'root',
})
export class MenuService {
  private urlApi: string = environment.endpoint + 'Menu';

  constructor(private http: HttpClient) {}

  GetList(userId: number): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(`${this.urlApi}/${userId}`);
  }
}
