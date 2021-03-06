import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http'
import {BrowserAnimationsModule} from '@angular/platform-browser/animations'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';
import { HomeModule } from './home/home.module';
import { ErrorInteceptor } from './core/interceptors/error.inteceptor';
import { LoadingInterceptor } from './core/interceptors/loading.inteceptors';
import { JwtInteceptor } from './core/interceptors/jwt.inteceptor';
import { NgxSpinner } from 'ngx-bootstrap-spinner/lib/ngx-spinner.enum';
import { NgxSpinnerModule } from "ngx-spinner";


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    CoreModule,
    HomeModule,
    NgxSpinnerModule
    ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInteceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInteceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
