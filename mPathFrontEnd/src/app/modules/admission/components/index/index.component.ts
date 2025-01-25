import { Component } from '@angular/core';
import { SharedModule } from '../../../global/shared.module';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent {

}
