import { Component } from '@angular/core';
import {RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-layout-main',
  imports: [
    RouterOutlet
  ],
  templateUrl: './layout-main.component.html',
  styleUrl: './layout-main.component.css'
})
export class LayoutMainComponent {
  menus = [
    {
      label: 'Início',
      path: '/app',
      icon: 'home'
    },
    {
      label: 'Pessoas',
      path: '/app/person',
      icon: 'person'
    },
    {
      label: 'Veículos',
      path: '/app/vehicle',
      icon: 'commute'
    },
    null,
    {
      label: 'Usuários',
      path: '/app/user',
      icon: 'people_outline'
    },
    {
      label: 'Sair',
      path: '/app/logout',
      icon: 'logout'
    }
  ]
}
