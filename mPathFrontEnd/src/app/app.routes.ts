import { Routes } from '@angular/router';
import { HeaderComponent } from './modules/global/components/header/header.component';
import { IndexComponent } from './modules/global/components/index/index.component';

export const routes: Routes = [
  {
    path: '',
    component: IndexComponent,
  }
];
