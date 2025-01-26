import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";


@Injectable({
  providedIn: 'root'
})
export class HttpService{

  constructor(
    private httpClient: HttpClient
  ){

  }

  GetAll(count: number, page: number, searchText: string, route: string){
    let params = new HttpParams();
    params = params.append('count', count)
    params = params.append('page', page)
    params = params.append('searchText', searchText)
    return this.httpClient.get(`http://localhost:54756/api/${route}`, {
      params: params,
    });
  }

  Delete(ids: number[]){
    const option = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      body: ids
    };

    return this.httpClient.delete('http://localhost:54756/api/Doctor', option);
  }

  Create(id: number, firstName:string, lastName: string, active:boolean, email:string){
    const body = {
      id: id,
      firstName: firstName,
      lastName: lastName,
      active: active,
      email: email,
    };
      const headers = new HttpHeaders({
        'Content-Type': 'application/json',
      });
      return this.httpClient.post('http://localhost:54756/api/Doctor', body, {
        headers: headers,
      });
  }
}