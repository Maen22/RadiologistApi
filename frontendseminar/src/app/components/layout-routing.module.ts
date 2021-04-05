import { Patient } from './radiologist/shared/models/patient.model';
import { PatientModule } from './radiologist/patient/patient.module';
import { PatientComponent } from './radiologist/patient/patient.component';
import { LayoutComponent } from './layout.component';
import { NgModule } from '@angular/core';

import { RouterModule, Routes } from '@angular/router';
import { OktaAuthGuard } from '@okta/okta-angular';

const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    canActivate: [OktaAuthGuard],
    children: [
      {
        path: 'patients',
        loadChildren: () =>
          import('./radiologist/patient/patient.module').then(
            (m) => m.PatientModule
          ),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class LayoutRoutingModule {}
