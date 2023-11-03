import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/app/enviroments/environment';
import { AuthResponse } from 'src/app/interfaces/response/AuthResponse';
import { RegistrationResponse } from 'src/app/interfaces/response/RegistrationResponse';
import { UserForAuthentication } from 'src/app/interfaces/user/UserForAuthentication';
import { UserForRegistration } from 'src/app/interfaces/user/UserForRegistration';
import { TfaDto } from 'src/app/models/tfa-dto';
import { TfaSetupDto } from 'src/app/models/tfa-setup-dto';

@Injectable({
  providedIn: 'root'
})
export class OperationService {

  constructor(private http: HttpClient) { }
  
  //Addition
  public addition = (body: Operations) => {
    return this.http.post<number> (`${environment.apiUrl}/operations/addition`, body);
  }
}

export interface Operations{
    numberOne: number,
    numberTwo: number
}
