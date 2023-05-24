import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment.development';
import { Observable } from 'rxjs';
import { Response } from '../Interfaces/response';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  private url: string = environment.endpoint + 'Category';

  constructor(private http: HttpClient) {}

  GetList(): Observable<Response> {
    return this.http.get<Response>(this.url);
  }
}
