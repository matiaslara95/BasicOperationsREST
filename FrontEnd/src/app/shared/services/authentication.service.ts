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
export class AuthenticationService {

  constructor(private http: HttpClient) { }
  
  //Register user
  public registerUser = (body: UserForRegistration) => {
    return this.http.post<RegistrationResponse> (`${environment.apiUrl}/accounts/registration`, body);
  }

  //TFA
  public getTfaSetup = (email: string) => {
    return this.http.get<TfaSetupDto>(`${environment.apiUrl}/accounts/tfa-setup?email=${email}`);
  }
  public postTfaSetup = (body: TfaSetupDto) => {
    return this.http.post<TfaSetupDto> (`${environment.apiUrl}/accounts/tfa-setup`, body);
  }
  public disableTfa = (email: string) => {
    return this.http.delete<TfaSetupDto> (`${environment.apiUrl}/accounts/tfa-setup?email=${email}`);
  }

  public loginUser = (body: UserForAuthentication) => {
    console.log(`${environment.apiUrl}/accounts/login`)
    return this.http.post<AuthResponse>(`${environment.apiUrl}/accounts/login`, body);
  }

  public loginUserTfa = (body: TfaDto) => {
    return this.http.post<AuthResponse>(`${environment.apiUrl}/accounts/login-tfa`, body);
  }
}
