import { Response, ReturnType } from './../../Model/response';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { HttpServiceCallService } from '../../Services/http-service-call.service';
import { Product } from '../../Model/product';
import { Router } from '@angular/router';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-parent',
  standalone: true,
  imports: [],
  templateUrl: './parent.component.html',
  styleUrl: './parent.component.css'
})
export class ParentComponent implements OnInit {

 @Output() public data = new EventEmitter();
 private productData: Product[] = [];
 private testObservable$: Observable<Response<Product>> = new Observable<Response<Product>>;

constructor(private httpService: HttpServiceCallService) {
}
  ngOnInit(){

    this.testObservable$ = this.httpService.addAllProducts();
    this.testObservable$
    .subscribe((prod) => {
      if(prod.returnType == ReturnType.Success) {
        alert(prod.message);
        //call to get all products list and send to child components
        this.httpService.getAllProducts()
        // .pipe(
        //   tap((val) => val.returnedValue.forEach((x) => console.log(x)))
        // )
        .subscribe((products) => {
          this.productData = products.returnedValue;
        });
      }
    });

    //test of shareReplay
    this.testObservable$
    .subscribe((prod) => {
      if(prod.returnType == ReturnType.Success) {
        alert(prod.message);
        //call to get all products list and send to child components
        this.httpService.getAllProducts()
        .subscribe((products) => {
          this.productData = products.returnedValue;
        });
      }
    });

    //test of shareReplay
    this.testObservable$
    .subscribe((prod) => {
      if(prod.returnType == ReturnType.Success) {
        alert(prod.message);
        //call to get all products list and send to child components
        this.httpService.getAllProducts()
        .subscribe((products) => {
          this.productData = products.returnedValue;
        });
      }
    });

  //generate the products list first:
  this.httpService.addAllProducts()

  }

  sendProducts(){
    this.data.emit(this.productData);
  }

}
