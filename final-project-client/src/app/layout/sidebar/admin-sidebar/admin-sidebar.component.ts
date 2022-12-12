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
      icon: 'pi pi-forward',
      tooltipOptions: {
        tooltipLabel: 'Messages',
      },
    },
    {
      label: 'Schedule',
      routerLink: 'schedule',
      icon: 'pi pi-book',
      tooltipOptions: {
        tooltipLabel: 'Schedule',
      },
    },
    {
      label: 'Grades',
      routerLink: 'grades',
      icon: 'pi pi-book',
      tooltipOptions: {
        tooltipLabel: 'Grades',
      },
    },
    {
      label: 'Premissions',
      routerLink: 'premissions',
      icon: 'pi pi-book',
      tooltipOptions: {
        tooltipLabel: 'Submission',
      },
    },
    {
      label: 'Submission',
      routerLink: 'submissions',
      icon: 'pi pi-book',
      tooltipOptions: {
        tooltipLabel: 'Submission',
      },
    },
  ];
}
