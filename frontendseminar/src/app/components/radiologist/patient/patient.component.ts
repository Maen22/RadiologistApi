import { OktaAuthService } from '@okta/okta-angular';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-patient',
  templateUrl: './patient.component.html',
  styleUrls: ['./patient.component.css'],
})
export class PatientComponent implements OnInit {
  constructor(private authService: OktaAuthService) {}

  ngOnInit(): void {}

  logout() {
    this.authService.signOut();
  }
}
