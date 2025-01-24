import { Component, OnInit } from '@angular/core';
import { SharedModule } from '../../../global/shared.module';
import { HttpService } from '../../../../services/http.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-index',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss',
})
export class IndexComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'firstName',
    'lastName',
    'email',
    'actions',
  ];
  dataSource = new MatTableDataSource<any>([]);

  totalCount = 0;
  pageCount = 10;
  pageNumber = 0;
  paginationOptions: number[] = [1, 5, 10, 25, 100];

  searchText = '';

  constructor(private httpService: HttpService) {}

  ngOnInit(): void {
    this.GetAll();
  }

  GetAll() {
    this.httpService.GetAll(this.pageCount, this.pageNumber, this.searchText).subscribe((response: any) => {
      console.log(response);
      this.dataSource.data = response.data.element;
      this.totalCount = response.data.totalCount;
    });
  }

  handlePageEvent(event: any){
    this.pageCount = event.pageSize;
    this.pageNumber = event.pageIndex;

    this.GetAll();
  }
}
