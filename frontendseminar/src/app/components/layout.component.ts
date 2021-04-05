import { OktaAuthService } from '@okta/okta-angular';
import { MenuItem } from 'primeng/api';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
})
export class LayoutComponent implements OnInit {
  itemsNav: MenuItem[];
  itemsSideNav: MenuItem[];
  constructor(private authService: OktaAuthService) {}

  ngOnInit() {
    this.itemsNav = [
      {
        label: '<img />',
        escape: false,
        style: {
          'margin-left': '1000px',
        },
      },
      {
        label: 'Settings',
        icon: 'pi pi-cog',

        items: [
          {
            label: 'New Treatment Type',
            icon: 'pi pi-plus',
          },
          {
            label: 'New Expense Type',
            icon: 'pi pi-plus',
          },
        ],
      },
    ];

    this.itemsSideNav = [
      {
        label: 'Dashboard',
        icon: 'pi pi-home',
      },

      {
        label: 'Patients',
        icon: 'pi pi-fw pi-user',
      },

      {
        label: 'Expenses',
        icon: 'pi pi-dollar',
      },
    ];
  }

  logout() {
    this.authService.signOut();
  }
}
