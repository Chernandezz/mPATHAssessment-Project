import { Component } from '@angular/core';
import { SharedModule } from '../../shared.module';
import { Router, RouterOutlet } from '@angular/router';
import { HttpService } from '../../../../services/http.service';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [SharedModule, RouterOutlet],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {
  constructor(private router: Router, private httpService: HttpService) {}

  navigateBasedOnAuth() {
    if (this.httpService.isLoggedIn()) {
      this.router.navigate(['/login']); // Navega al inicio si está logueado
    } else {
      this.router.navigate(['/']); // Navega al login si no está logueado
    }
  }

  logout() {
    this.httpService.logout(); // Llama al método logout del servicio
    this.router.navigate(['/login']); // Redirige al login
  }
}
