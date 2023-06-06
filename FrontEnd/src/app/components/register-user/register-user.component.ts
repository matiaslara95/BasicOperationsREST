import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UserForRegistration } from 'src/app/interfaces/user/UserForRegistration';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.css']
})
export class RegisterUserComponent implements OnInit {

  registerForm: FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    confirm: new FormControl('')
  });

  constructor(
    private authService: AuthenticationService,
    private router: Router
  ) { }

  ngOnInit(): void { }

  public validateControl = (controlName: string) => {
    return this.registerForm.get(controlName)?.invalid && this.registerForm.get(controlName)?.touched
  }

  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.get(controlName)?.hasError(errorName)
  }

  public registerUser = (registerFormValue: any) => {
    const formValues = { ...registerFormValue };
    const user: UserForRegistration = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };
    this.authService.registerUser(user)
      .subscribe({
        next: (_) => {
          console.log("Successful registration");
          this.router.navigate(['/home']);
        },
        error: (err: HttpErrorResponse) => console.log(err.error.errors)
      })
  }
}
