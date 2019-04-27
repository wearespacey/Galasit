import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule,MatMenuModule} from '@angular/material';
import { BackgroundComponentComponent } from './background-component/background-component.component';
import { LoginComponentComponent } from './login-component/login-component.component';
import { RegisterComponentComponent } from './register-component/register-component.component';
import { BubbleComponentComponent } from './bubble-component/bubble-component.component';
import { SelectionComponentComponent } from './selection-component/selection-component.component';
import { SeatInfoComponentComponent } from './seat-info-component/seat-info-component.component';
import { UnbookComponentComponent } from './unbook-component/unbook-component.component';

@NgModule({
  declarations: [
    AppComponent,
    BackgroundComponentComponent,
    LoginComponentComponent,
    RegisterComponentComponent,
    BubbleComponentComponent,
    SelectionComponentComponent,
    SeatInfoComponentComponent,
    UnbookComponentComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatButtonModule, 
    MatCheckboxModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
