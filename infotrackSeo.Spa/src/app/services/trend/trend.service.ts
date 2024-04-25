import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment.developement';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TrendService {

  constructor(private http: HttpClient) { }

  getTrends() : Observable<any> {

    // const httpOptions = {
    //   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    // }

    return this.http.get(`${environment.apiUrl}/trends/all`).pipe();

  }
}
