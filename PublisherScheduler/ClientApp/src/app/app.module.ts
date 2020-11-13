import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { PersonsComponent } from './persons/persons.component';
import { CapacitiesComponent } from './capacities/capacities.component';
import { ShowPersonComponent } from './persons/show-person/show-person.component';
import { AddEditPersonComponent } from './persons/add-edit-person/add-edit-person.component';
import { ShowCapacityComponent } from './capacities/show-capacity/show-capacity.component';
import { AddEditCapacityComponent } from './capacities/add-edit-capacity/add-edit-capacity.component';
import { SharedService } from './shared.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    PersonsComponent,
    ShowPersonComponent,
    AddEditPersonComponent,
    CapacitiesComponent,
    ShowCapacityComponent,
    AddEditCapacityComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: SharedService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
