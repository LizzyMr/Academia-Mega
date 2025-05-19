import { Component } from '@angular/core';
import { ApiDataService } from '../../Service/api-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  imports: [CommonModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  products: any[] = [];
  constructor(private productService: ApiDataService){

  }

  ngOnInit(){
    this.productService.getProduct().subscribe(data => {
      this.products = data;
    })
  }
}
