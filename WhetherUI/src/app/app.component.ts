import { Component } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Observable } from 'rxjs';
import { TemperatureType } from './enums/temperature-type';
import { WeatherForecast } from './models/weather-forecast';
import { WeatherConverterService } from './services/weather-converter.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'WhetherUI';

  type = new FormControl(TemperatureType.Celsius);
  tempValue = new FormControl(0);
  weather$: Observable<WeatherForecast>;

  constructor(private weatherConverterService: WeatherConverterService) {
  }

  convert() {
    this.weather$ = this.weatherConverterService
      .getWeatherForcast(this.type.value as TemperatureType, this.tempValue.value);
  }
}
