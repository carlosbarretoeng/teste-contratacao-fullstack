import {Injectable} from '@angular/core';

const USER_KEY = 'target-fullstack-api-auth-user';
const JWT_KEY = 'target-fullstack-api-auth-jwt';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  clean(): void {
    window.sessionStorage.clear();
  }

  public saveJwt(token: string): void {
    window.sessionStorage.removeItem(JWT_KEY);
    window.sessionStorage.setItem(JWT_KEY, token);
  }

  public getJwt(): string|null {
    return window.sessionStorage.getItem(JWT_KEY);
  }

  public isLoggedIn(): boolean {
    const token = window.sessionStorage.getItem(JWT_KEY);
    return !!token;
  }
}
