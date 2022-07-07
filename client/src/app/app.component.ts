import { HttpClient } from '@angular/common/http';
import { Component ,OnInit} from '@angular/core';
import { AccountService } from './account/account.service';
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

  constructor(private basketService: BasketService,private accountService: AccountService) {}
  ngOnInit() : void {
    this.loadBasket();
    this.loadCurrentUser();
  }

  loadCurrentUser(){
    const token = localStorage.getItem('token');
      this.accountService.loadCurrentUser(token).subscribe(() =>{
        console.log('user loaded');
      }, error => {
        console.log(error);
      })
  }
  loadBasket(){
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
