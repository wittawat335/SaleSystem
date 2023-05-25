import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Sale } from '../Interfaces/sale';
import { Observable } from 'rxjs';
import { ResponseApi } from '../Interfaces/responseApi';

@Injectable({
  providedIn: 'root',
})
export class SaleService {
  private urlApi: string = environment.endpoint + 'Sale';

  constructor(private http: HttpClient) {}

  Register(req: Sale): Observable<ResponseApi> {
    return this.http.post<ResponseApi>(`${this.urlApi}/Register`, req);
  }

  Record(
    search: string,
    saleNumber: string,
    startDate: string,
    endDate: string
  ): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(
      `${this.urlApi}/Record?search=${search}&saleNumber=${saleNumber}&startDate=${startDate}&endDate=${endDate}`
    );
  }

  Report(startDate: string, endDate: string): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(
      `${this.urlApi}/Report?startDate=${startDate}&endDate=${endDate}`
    );
  }
}
