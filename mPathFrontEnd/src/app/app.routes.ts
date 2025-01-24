import { Routes } from '@angular/router';
import { HeaderComponent } from './modules/global/components/header/header.component';

export const routes: Routes = [
  {
    path: '',
    component: HeaderComponent,
    loadChildren: () => import('./routes.module').then(m => m.RoutesModule)
  }
];
