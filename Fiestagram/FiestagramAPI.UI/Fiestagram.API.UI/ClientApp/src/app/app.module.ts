import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { MenuGeneralComponent } from './shared/components/menu-general/menu-general.component';
import { SelfiesListComponent } from './features/selfies/selfies-list/selfies-list.component';
import { OneSelfieReadonlyComponent } from './features/selfies/one-selfie-readonly/one-selfie-readonly.component';
import { CodingameComponent } from './shared/components/codingame/codingame.component';
import { StructuralDirectivesComponent } from './shared/components/structural-directives/structural-directives.component';
import { ParentComponent } from './shared/components/parentChild/parent/parent.component';
import { ChildComponent } from './shared/components/parentChild/child/child.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    MenuGeneralComponent,
    SelfiesListComponent,
    OneSelfieReadonlyComponent,
    CodingameComponent,
    StructuralDirectivesComponent,
    ParentComponent,
    ChildComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
