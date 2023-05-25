import { SharedModule } from './../../../shared/shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LayoutRoutingModule } from './layout-routing.module';
import { UserComponent } from '../pages/user/user.component';
import { ProductComponent } from '../pages/product/product.component';

@NgModule({
  declarations: [UserComponent, ProductComponent],
  imports: [CommonModule, LayoutRoutingModule, SharedModule],
})
export class LayoutModule {}
