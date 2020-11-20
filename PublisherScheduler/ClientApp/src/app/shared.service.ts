import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44379/api";
  readonly PhotoUrl = "https://localhost:44379/photos"; 
  constructor(private http:HttpClient) { }

  getCapacityList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl+'/Capacities');
  }

  addCapacity(val:any) {
    return this.http.post(this.APIUrl +'/Capacities', val);
  }

  updateCapacity(val:any) {
    return this.http.put(this.APIUrl + '/Capacities/'+val.Id, val);
  }

  deleteCapacity(val:any) {
    return this.http.delete(this.APIUrl + '/Capacities/'+val);
  }

  getPersonList(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Persons');
  }

  addPerson(val: any) {
    return this.http.post(this.APIUrl + '/Persons', val);
  }

  updatePerson(val: any) {
    return this.http.put(this.APIUrl + '/Persons', val);
  }

  deletePerson(val: any) {
    return this.http.delete(this.APIUrl + '/Persons/' + val);
  }

  UploadPhoto(val: any) {
    return this.http.post(this.APIUrl+'/Persons/SaveFile',val);
  }

  getAllCapacityNames(): Observable<any[]> {
    return this.http.get<any[]>(this.APIUrl + '/Persons/GetAllCapacityNames');
  }
}
