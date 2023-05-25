import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './components/login/login.component';
import { LayoutComponent } from './components/Layout/layout/layout.component';
import { SharedModule } from './shared/shared/shared.module';
import { DashboardComponent } from './components/Layout/pages/dashboard/dashboard.component';
import { ReportComponent } from './components/Layout/pages/report/report.component';
import { SaleComponent } from './components/Layout/pages/sale/sale.component';
import { SaleHistoryComponent } from './components/Layout/pages/sale-history/sale-history.component';

@NgModule({
  declarations: [AppComponent, LoginComponent, LayoutComponent, DashboardComponent, ReportComponent, SaleComponent, SaleHistoryComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
