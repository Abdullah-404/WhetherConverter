import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { TemperatureType } from "../enums/temperature-type";
import { WeatherForecast } from '../models/weather-forecast';
import { AppSettings } from '../config/app-settings';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherConverterService {

  constructor(private httpClient: HttpClient) { }

  getWeatherForcast(type: TemperatureType, value: number) {
    const url = AppSettings.API_ENDPOINT + '/WeatherForecast?type=' + 
      type + '&value=' + value;
    return this.httpClient.get<WeatherForecast>(url);
  }
}
