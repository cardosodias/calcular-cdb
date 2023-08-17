import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
//import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { ResgateCdbComponent } from './components/resgate-cdb/resgate-cdb.component';

@NgModule({
  declarations: [
    AppComponent,
    ResgateCdbComponent
    
  ],
  imports: [BrowserModule, ReactiveFormsModule,HttpClientModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
