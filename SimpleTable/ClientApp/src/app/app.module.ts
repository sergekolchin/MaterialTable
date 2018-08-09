import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import {
  MatInputModule, MatRadioModule, MatSelectModule, MatButtonModule, MatCheckboxModule, MatDatepickerModule,
  MatTableModule, MatPaginatorModule, MatProgressSpinnerModule, MatSortModule, MatGridListModule
} from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    MatInputModule, MatRadioModule, MatSelectModule, MatButtonModule, MatCheckboxModule, MatDatepickerModule,
    MatTableModule, MatPaginatorModule, MatProgressSpinnerModule, MatSortModule, MatGridListModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: "**", redirectTo: "/" }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
