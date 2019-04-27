import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule,MatMenuModule } from '@angular/material';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { BackgroundComponent } from './background/background.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BubbleComponent } from './bubble/bubble.component';
import { UnbookComponent } from './unbook/unbook.component';
import { SelectionComponent } from './selection/selection.component';
import { InfoComponent } from './info/info.component';
import { SeatInfoComponent } from './seat-info/seat-info.component';



@NgModule({
  declarations: [
    AppComponent,
    BackgroundComponent,
    LoginComponent,
    RegisterComponent,
    BubbleComponent,
    UnbookComponent,
    SelectionComponent,
    InfoComponent,
    SeatInfoComponent
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
