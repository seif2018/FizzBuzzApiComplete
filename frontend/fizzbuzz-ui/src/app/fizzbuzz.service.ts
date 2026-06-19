import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from './environment';

export interface FizzBuzzFormValue {
  int1: number;
  int2: number;
  limit: number;
  str1: string;
  str2: string;
}

@Injectable({ providedIn: 'root' })
export class FizzBuzzService {
  constructor(private readonly http: HttpClient) {}

  generate(value: FizzBuzzFormValue): Observable<string[]> {
    const params = new HttpParams()
      .set('int1', value.int1)
      .set('int2', value.int2)
      .set('limit', value.limit)
      .set('str1', value.str1)
      .set('str2', value.str2);

    return this.http.get<string[]>(`${environment.apiBaseUrl}/api/fizzbuzz`, { params });
  }
}
