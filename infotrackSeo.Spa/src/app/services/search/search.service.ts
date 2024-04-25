import { Injectable, inject, ErrorHandler, } from '@angular/core';
import { environment } from '../../../environments/environment.developement';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { SearchRequest } from '../../models/search-request';

@Injectable({
  providedIn: 'root'
})
export class SearchService {

  errorHandler = inject(ErrorHandler);
  constructor(private http: HttpClient) { }

  getSearch(searchRequest:SearchRequest) : Observable<any> {

    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    }
    return this.http.post(`${environment.apiUrl}/search/count`, searchRequest, httpOptions).pipe();

  }
}

      // catchError(
      //   (err:HttpErrorResponse) =>  {
      //     return this.errorHandler.handleError(err);
      //   }
      // )
