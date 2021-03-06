import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { LoginComponent } from './login-component/login-component.component';
import { AuthenticationService } from './services/authentication.service';
import { RegisterComponent } from './register/register.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { InvoiceService } from './services/invoice.service';
import { InvoiceComponent } from './invoice/invoice.component';
import { SearchComponent } from './search/search.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoginComponent,
    RegisterComponent,
    ForgotPasswordComponent,
    DashboardComponent,
    InvoiceComponent,
    SearchComponent,
    PageNotFoundComponent,
    ConfirmationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'forgot-password', component: ForgotPasswordComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'invoice', component: InvoiceComponent },
      { path: 'search', component: SearchComponent },
      { path: '**', component: PageNotFoundComponent },
      { path: 'confirmation', component: ConfirmationComponent },
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
      },
    ])
  ],
  providers: [
    AuthenticationService,
    InvoiceService
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
