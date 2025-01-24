import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../../../global/shared.module';
import { HttpService } from '../../../../services/http.service';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss',
})
export class IndexComponent implements OnInit {
  constructor(private httpService: HttpService) {}

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll() {
    this.httpService.GetAll(10,0,'').subscribe((response: any) => {
      console.log(response)
    });
  }
}
