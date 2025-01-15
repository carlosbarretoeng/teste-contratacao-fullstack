import {Component, inject} from '@angular/core';
import {LayoutCenterComponent} from '../../_layouts/layout-center/layout-center.component';
import {MatFormField} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButton} from '@angular/material/button';
import {RouterLink} from '@angular/router';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {TargetApiService} from '../../_services/target-api.service';
import {MatCard, MatCardContent} from '@angular/material/card';
import {MatProgressSpinner} from '@angular/material/progress-spinner';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-page-login',
  imports: [
    CommonModule,
    LayoutCenterComponent,
    MatFormField,
    MatInputModule,
    MatButton,
    RouterLink,
    FormsModule,
    MatCard,
    MatCardContent,
    MatProgressSpinner
  ],
  templateUrl: './page-register.component.html',
  styleUrl: './page-register.component.css'
})
export class PageRegisterComponent {
  private _snackBar = inject(MatSnackBar);

  isLoading: boolean = false;
  isRegistered: boolean = false;
  loginFormInfos = {
    username: '',
    password: ''
  }

  constructor(
    private  targetApiService: TargetApiService
  ) {}

  public async register(){
    this.isLoading = true;
    let {username, password} = this.loginFormInfos;
    this.targetApiService.register(username, password).subscribe({
      next: (res)=>{
        this.isRegistered = true;
        this.isLoading = false;
      },
      error: ()=>{
        this.isLoading = false;
        this._snackBar.open("Dados inválidos", "", {duration: 3000});
      },
    })
  }

}
