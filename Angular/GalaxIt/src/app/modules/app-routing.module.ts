import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BackgroundComponent } from '../components/background/background.component';
import { LoginComponent } from '../components/login/login.component';
import { RegisterComponent } from '../components/register/register.component';
import { BubbleComponent } from '../components/bubble/bubble.component';
import { UnbookComponent } from '../components/unbook/unbook.component';
import { SelectionComponent } from '../components/selection/selection.component';
import { SeatInfoComponent } from '../components/seat-info/seat-info.component';
import { PageNotFoundComponent } from '../components/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: '', component: BackgroundComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'bubble', component: BubbleComponent },
      { path: 'bubble/:id', component: SelectionComponent },
      { path: 'unbook', component: UnbookComponent }
    ]
  },
  { path: 'seat', component: SelectionComponent },
  { path: 'seat/:id', component: SeatInfoComponent },
  { path: '**', component: PageNotFoundComponent }
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
