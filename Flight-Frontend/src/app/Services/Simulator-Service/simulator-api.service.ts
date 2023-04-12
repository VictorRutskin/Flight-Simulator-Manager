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

  // Get Flights
  public getFlights(): Observable<any[]> {
    return this.http.get<any[]>(environment.apiUrl + this.FlightsAPI);
  }

  // Create Flight
  public createFlight(flight: any): Observable<any> {
    return this.http.post<any>(environment.apiUrl + this.FlightsAPI, flight);
  }

  // Update Flight
  public updateFlight(flightNumber: string, flight: any): Observable<any> {
    return this.http.put<any>(
      environment.apiUrl + this.FlightsAPI + `/${flightNumber}`,
      flight
    );
  }

  // Get Flights by Type
  public getFlightsByType(type: string): Observable<any[]> {
    return this.http.get<any[]>(
      environment.apiUrl + this.FlightsAPI + `/${type}`
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
}
