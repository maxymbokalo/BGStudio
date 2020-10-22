import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { MastersComponent } from './components/masters/masters.component';

const routes: Routes = [
  {path: '',component: AppComponent},
  {path: 'masters', component: MastersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
