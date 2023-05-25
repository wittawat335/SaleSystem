import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment.development';
import { ResponseApi } from '../Interfaces/responseApi';

@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  private url: string = environment.endpoint + 'Dashboard';

  constructor(private http: HttpClient) {}

  Summary(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(this.url + '/Summary');
  }
}
