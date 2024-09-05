import { Component, Input, OnInit } from '@angular/core';
import { Product } from '../../Model/product';
import { ParentComponent } from '../parent/parent.component';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { HttpServiceCallService } from '../../Services/http-service-call.service';
import { ReturnType } from '../../Model/response';

@Component({
  selector: 'app-child',
  standalone: true,
  imports: [CommonModule, ParentComponent],
  templateUrl: './child.component.html',
  styleUrl: './child.component.css'
})
export class ChildComponent {
productsList: Product[]=[];

receivingProductsFromParent(products: Product[]): void {
  this.productsList = products;
}

}
