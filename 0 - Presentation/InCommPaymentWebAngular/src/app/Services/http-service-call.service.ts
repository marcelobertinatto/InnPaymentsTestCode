import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlServicesService } from './url-services.service';
import { Observable, shareReplay, tap } from 'rxjs';
import { Product } from '../Model/product';
import { Response } from '../Model/response';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceCallService {

  constructor(private http: HttpClient, private urlService: UrlServicesService) { }

  getProductById(productId: string): Observable<Response<Product>> {
    return this.http.get<Response<Product>>(this.urlService.getUrl() + "Product/getproductbyid/${productId}",
    {headers: this.urlService.getHeaders()});
  }

  getAllProducts(): Observable<Response<Product>> {
    return this.http.get<Response<Product>>( this.urlService.getUrl() + "Product/getallproducts",
    {headers: this.urlService.getHeaders()});
  }

  addAllProducts(product?: Product): Observable<Response<Product>> {
    return this.http.post<Response<Product>>(this.urlService.getUrl() + "Product/addallproducts", product,
    { headers: this.urlService.getHeaders()}).pipe(
      shareReplay(1)
    );

  }
}
