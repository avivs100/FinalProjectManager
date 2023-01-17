import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-admin-sidebar',
  templateUrl: './admin-sidebar.component.html',
  styleUrls: ['./admin-sidebar.component.scss'],
})
export class AdminSidebarComponent {
  public items: MenuItem[] = [
    {
      label: 'Projects',
      routerLink: 'projects',
      icon: 'pi pi-sitemap',
      tooltipOptions: {
        tooltipLabel: 'Projects Page',
      },
    },
    {
      label: 'Messages',
      routerLink: 'messages',
      icon: 'pi pi-book',
      tooltipOptions: {
        tooltipLabel: 'Messages',
      },
    },
    {
      label: 'Schedule',
      routerLink: 'schedule',
      icon: 'pi pi-calendar',
      tooltipOptions: {
        tooltipLabel: 'Schedule',
      },
    },
    {
      label: 'Premissions',
      routerLink: 'premissions',
      icon: 'pi pi-check-circle',
      tooltipOptions: {
        tooltipLabel: 'Submission',
      },
    },
    {
      label: 'Proposals',
      routerLink: 'proposals',
      icon: 'pi pi-paypal',
      tooltipOptions: {
        tooltipLabel: 'Project Proposals',
      },
    },
  ];
}
