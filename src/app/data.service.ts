import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable, of, switchMap, take } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') base: string) 
  { 
    this.baseUrl = base + 'api';
  }

  getAllClasses(): Observable<any[]> 
  {
    return this.http.get<any[]>(`${this.baseUrl}/classes-page`);
  }

}
