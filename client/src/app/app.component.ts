import { HttpClient } from '@angular/common/http';
import { Component ,OnInit} from '@angular/core';
import { BasketService } from './basket/basket.service';
import { IPagination } from './shared/models/pagination';
import { IProduct } from './shared/models/product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'eCommerce';

  constructor(private basketService: BasketService) {
    
  }
  ngOnInit(): void {
    const baksetId = localStorage.getItem('basket_id');
    if(baksetId){
      this.basketService.getBasket(baksetId).subscribe(() => {
        console.log('initialised basket');
      }, error => {
        console.log(error);
      })
    }
  }
 
}
