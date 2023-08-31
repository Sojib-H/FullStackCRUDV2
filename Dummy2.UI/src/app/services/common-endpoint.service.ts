import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from './app-config.service';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CommonEndpointService {

  get baseUrl() { return this.configurations.apiBaseUrl; }
  constructor(private http: HttpClient, private configurations: AppConfigService) { }

  getByIdEndpoint<T>(apiUrl?: string): Observable<T> {
    const endpointUrl = `${this.baseUrl}` + apiUrl;
    return this.http.get<T>(endpointUrl).pipe<T>(
      catchError(error => {
        console.log(error)
        return this.handleError(error, () => this.getByIdEndpoint(apiUrl));
      }));
  }

  getAllEndpoint<T>(apiUrl: string): Observable<T> {
    const endpointUrl = `${this.baseUrl}` + apiUrl;
    return this.http.get<T>(endpointUrl, this.requestHeaders).pipe<T>(
      catchError(error => {
        console.log(error)
        return this.handleError(error, () => this.getAllEndpoint(apiUrl));
      }));
  }

  PostNewEndpoint<T>(tObject: any, apiUrl?: string): Observable<T> {
    const endpointUrl = `${this.baseUrl}` + apiUrl;
    return this.http.post<T>(endpointUrl, JSON.stringify(tObject), this.requestHeaders)
      .pipe<T>(
        catchError(error => {
          console.log(error)
          return this.handleError(error, () => this.PostNewEndpoint(tObject, apiUrl));
        }));
  }

  handleError(error: { status: number; }, continuation: () => Observable<any>) {
    //if (error.status == 401) {
      return throwError('session expired');
    //}
  }

  protected get requestHeaders(): { headers: HttpHeaders | { [header: string]: string | string[]; } } {
    const headers = new HttpHeaders({
      //Authorization: 'Bearer ' + this.authService.accessToken,
      'Content-Type': 'application/json',
      Accept: 'application/json, text/plain, */*'
    });

    return { headers };
  }
}
