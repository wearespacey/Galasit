import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BackgroundComponent } from './background/background.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BubbleComponent } from './bubble/bubble.component';
import { UnbookComponent } from './unbook/unbook.component';
import { SelectionComponent } from './selection/selection.component';
import { SeatInfoComponent } from './seat-info/seat-info.component';

const routes: Routes = [
  {path:'', component: BackgroundComponent, children: [
    {path:'login', component: LoginComponent},
    {path:'register', component:RegisterComponent},
    {path:'bubble', component: BubbleComponent},
    {path:'unbook', component: UnbookComponent}
  ]},
  {path:'', component: SelectionComponent, children:[
    {path:'seat', component:SeatInfoComponent}
  ]}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
