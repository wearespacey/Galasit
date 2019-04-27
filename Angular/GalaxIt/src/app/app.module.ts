import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './modules/app-routing.module';
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
    PageNotFoundComponent,
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
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
