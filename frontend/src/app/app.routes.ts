import { Routes } from '@angular/router';
import {PageLoginComponent} from './_pages/page-login/page-login.component';
import {PageRegisterComponent} from './_pages/page-register/page-register.component';
import {LayoutMainComponent} from './_layouts/layout-main/layout-main.component';
import {PageHomeComponent} from './_pages/page-home/page-home.component';

export const routes: Routes = [
  {
    path: '',
    component: PageLoginComponent
  },
  {
    path: 'register',
    component: PageRegisterComponent
  },
  {
    path: 'app',
    component: LayoutMainComponent,
    children: [
      {
        path: '',
        component: PageHomeComponent,
      },
      {
        path: 'person',
        component: PageLoginComponent
      },
      {
        path: 'vehicle',
        component: PageLoginComponent
      },
      {
        path: 'user',
        component: PageLoginComponent
      }
    ]
  }
];
