import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';

@NgModule({
declarations: [],
imports: [
CommonModule,
BrowserAnimationsModule,
FlexLayoutModule,
MatListModule,
MatCardModule,
MatIconModule,
MatFormFieldModule,
MatInputModule,
MatProgressSpinnerModule,
MatToolbarModule,
MatButtonModule,
MatSidenavModule

],
exports: [
BrowserAnimationsModule,
FlexLayoutModule,
MatListModule,
MatCardModule,
MatIconModule,
MatFormFieldModule,
MatInputModule,
MatProgressSpinnerModule,
MatToolbarModule,
MatButtonModule,
MatSidenavModule
]
})
export class MaterialModule { }
