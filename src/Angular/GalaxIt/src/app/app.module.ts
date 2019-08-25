import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatProgressBarModule, MatDatepickerModule,
         MatFormFieldModule, MatNativeDateModule, MatInputModule, MatCheckboxModule,
         MatMenuModule, MatGridListModule } from '@angular/material';
import { AppRoutingModule } from './modules/app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'

import { AppComponent } from './app.component';
import { UnbookComponent } from './components/unbook/unbook.component';
import { BackgroundComponent } from './components/background/background.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { BubbleComponent } from './components/bubble/bubble.component';
import { SelectionComponent } from './components/selection/selection.component';
import { SeatInfoComponent } from './components/seat-info/seat-info.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

import { APIS } from './services/api';
import { BASE_PATH } from './variables';
import { environment } from 'src/environments/environment';

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
    SeatInfoComponent
  ],
  imports: [
    BrowserModule,
    MatProgressBarModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatButtonModule,
    MatCheckboxModule,
    MatInputModule,
    FormsModule,
    MatNativeDateModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatDatepickerModule,
    MatMenuModule,
    MatCardModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    MatGridListModule
  ],
  providers: [APIS, { provide: BASE_PATH, useValue: environment.API_BASE_PATH }],
  bootstrap: [AppComponent]
})
export class AppModule { }
