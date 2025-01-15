import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {WeatherData} from './WeatherDataModel';

const apiUrl: string = 'https://localhost:7196';

@Injectable({
  providedIn: 'root'
})
export class TargetApiService {

  private http: HttpClient;

  constructor(http: HttpClient) {
    this.http = http;
  }

  getWeather(): Observable<WeatherData[]>{
    return this.http.get<WeatherData[]>(apiUrl + '/WeatherForecast');
  }

  login(username:string, password:string): Observable<any>{
    return this.http.post(apiUrl + '/User/login', { username: username, password: password });
  }

  register(username:string, password:string): Observable<any>{
    return this.http.post(apiUrl + '/User/register', { username: username, password: password });
  }

  getPersonAll(): Observable<any>{
    return this.http.get(apiUrl + '/Person');
  }

  getVehiclesAll(): Observable<any>{
    return this.http.get(apiUrl + '/Vehicle');
  }

  getVehiclesByPersonId(taxNumber: string): Observable<any>{
    return this.http.get(apiUrl + '/Vehicle/' + taxNumber);
  }
}
