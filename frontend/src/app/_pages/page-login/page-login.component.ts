import {Component, inject} from '@angular/core';
import {LayoutCenterComponent} from '../../_layouts/layout-center/layout-center.component';
import {MatFormField} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatButton} from '@angular/material/button';
import {Router, RouterLink} from '@angular/router';
import {CommonModule} from '@angular/common';
import {FormsModule} from '@angular/forms';
import {TargetApiService} from '../../_services/target-api.service';
import {MatCard, MatCardContent} from '@angular/material/card';
import {StorageService} from '../../_services/storage.service';
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
    MatCardContent
  ],
  templateUrl: './page-login.component.html',
  styleUrl: './page-login.component.css'
})
export class PageLoginComponent {
  private readonly router = inject(Router);
  private _snackBar = inject(MatSnackBar);

  loginFormInfos = {
    username: '',
    password: ''
  }

  constructor(
    private  targetApiService: TargetApiService,
    private storageService: StorageService
  ) {}

  public async login(){
    console.log(this.loginFormInfos);
    let {username, password} = this.loginFormInfos;
    this.targetApiService.login(username, password).subscribe({
      next: (res)=>{
        console.log('next', res.token);
        this.storageService.saveJwt(res.token);
        this.router.navigate(['/app']);
      },
      error: ()=>{
        this._snackBar.open("Dados inválidos", "", {duration: 3000});
        this.loginFormInfos.username = "";
        this.loginFormInfos.password = "";
      }
    })
  }

}
