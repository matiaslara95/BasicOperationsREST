import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { tokenGetter } from 'src/app/app.module';
import { AuthResponse } from 'src/app/interfaces/response/AuthResponse';
import { TfaDto } from 'src/app/models/tfa-dto';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { OperationService } from 'src/app/shared/services/operation.service';

@Component({
  selector: 'app-two-step-verification',
  templateUrl: './two-step-verification.component.html',
  styleUrls: ['./two-step-verification.component.css']
})
export class TwoStepVerificationComponent {
  private email: string = "";
  private returnUrl: string = "";

  twoStepForm = new FormGroup({
    twoFactorCode: new FormControl('', [Validators.required]),
  });
  showError: boolean = false;
  errorMessage: string = "";

  constructor(private authService: AuthenticationService,
    private operationService: OperationService,
    private route: ActivatedRoute, 
    private router: Router) { }

  ngOnInit(): void {
      this.email = this.route.snapshot.queryParams['email'];
      this.returnUrl = this.route.snapshot.queryParams['returnUrl'];
      this.email = this.route.snapshot.queryParams['email'];
  }

  validateControl = (controlName: string) => {
    return this.twoStepForm.get(controlName)?.invalid && this.twoStepForm.get(controlName)?.touched
  }
  hasError = (controlName: string, errorName: string) => {
    return this.twoStepForm.get(controlName)?.hasError(errorName)
  }

  loginUser = (twoStepFromValue: any) => {
    this.showError = false;
    
    const formValue = { ...twoStepFromValue };
    let twoFactorDto: TfaDto = {
      email: this.email,
      code: formValue.twoFactorCode
    }
    this.authService.loginUserTfa(twoFactorDto)
    .subscribe({
      next: (res:AuthResponse) => {
        localStorage.setItem("token", res.token);
        localStorage.setItem("email", this.email);
        this.router.navigate([this.returnUrl]);
                
        //JWT TEST
        this.operationService.addition({ numberOne: 1, numberTwo: 2 }).subscribe({
          next: (res: any) => {
            console.log(res)
          }
        })
      },
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      }
    })
  }  
}
