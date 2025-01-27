import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { HttpService } from '../services/http.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private httpService: HttpService, private router: Router) {}

  canActivate(): boolean {
    if (this.httpService.isLoggedIn()) {
      return true; // Permitir acceso si está logueado
    } else {
      this.router.navigate(['/login']); // Redirigir al login si no está logueado
      return false;
    }
  }
}
