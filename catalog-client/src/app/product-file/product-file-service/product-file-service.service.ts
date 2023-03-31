import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment'
import { ProductsFile } from '../products-file.model';

@Injectable({
  providedIn: 'root'
})
export class ProductFileServiceService {
  private productServiceEndpoint = `${environment.baseUrl}/files`;

  constructor(private httpClient: HttpClient) { }

  uploadFile(file: ProductsFile): Observable<ProductsFile> {
    return this.httpClient.post<ProductsFile>(this.productServiceEndpoint, file);
  }
}
