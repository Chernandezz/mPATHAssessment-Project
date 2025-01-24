import { Routes } from '@angular/router';
import { HeaderComponent } from './modules/global/components/header/header.component';
import { IndexComponent } from './modules/global/components/index/index.component';
import { AppComponent } from './app.component';

export const routes: Routes = [
  {
    path: '',
    component: HeaderComponent,
    loadChildren: () => import('./routes.module').then(m => m.RoutesModule)
  }
];
