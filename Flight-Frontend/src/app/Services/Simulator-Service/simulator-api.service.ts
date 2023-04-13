import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { environment } from 'src/app/Environments/Environment';

@Injectable({
  providedIn: 'root',
})
export class SimulatorApiService {
  private readonly FlightsAPI = 'api/Flights';

  constructor(private http: HttpClient) {}

  // Random Action
  public RandomAction(): Observable<string> {
    return this.http.post<string>(
      environment.apiUrl + this.FlightsAPI + '/RandomAction',
      null
    );
  }

  // Get Amount of Parked Planes
  public getAmountOfParked(): Observable<number> {
    return this.http.get<number>(
      environment.apiUrl + this.FlightsAPI + '/Parking'
    );
  }

  // Delete All Planes
  public deleteAllPlanes(): Observable<string> {
    return this.http.delete<string>(
      environment.apiUrl + this.FlightsAPI + '/DeleteAllPlanes'
    );
  }

  
  // Get All Planes
  public getAllPlanes(): Observable<string> {
    return this.http.get<string>(
      environment.apiUrl + this.FlightsAPI + '/GetAllPlanes'
    );
  }
}
