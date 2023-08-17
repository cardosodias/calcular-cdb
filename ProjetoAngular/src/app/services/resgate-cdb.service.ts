import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from "rxjs";
import { CdbResgateResponse } from '../models/cdb-resgate-response.model';
import { CdbResgateRequest } from '../models/cdb-resgate-request.model';

@Injectable({
  providedIn: 'root'
})
export class ResgateCdbService {
  
  private apiUrl = 'https://localhost:7297/api/v1/cdb/resgatar'
  
  constructor(private http: HttpClient) { }

  resgatar():Observable<CdbResgateResponse>{
    return this.http.get<CdbResgateResponse>(this.apiUrl);
  }

  resgatarDois(CdbResgateRequest: any){
    
    return this.http.post(this.apiUrl, CdbResgateRequest);
  }
}
