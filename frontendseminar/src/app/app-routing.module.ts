import { HomeComponent } from './home/home.component';
import { NgModule } from '@angular/core';

import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { OktaCallbackComponent, OktaAuthGuard } from '@okta/okta-angular';
import { LayoutComponent } from './components/layout.component';

const appRoutes: Routes = [
  {
    path: 'login/callback',
    component: OktaCallbackComponent,
  },

  { path: '', redirectTo: 'home', pathMatch: 'full' },

  { path: 'home', component: HomeComponent },

  {
    path: 'dash',
    canActivate: [OktaAuthGuard],
    loadChildren: () =>
      import('./components/layout.module').then((m) => m.LayoutModule),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
