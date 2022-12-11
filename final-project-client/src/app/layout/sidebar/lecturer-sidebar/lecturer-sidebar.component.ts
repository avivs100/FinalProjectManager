import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-lecturer-sidebar',
  templateUrl: './lecturer-sidebar.component.html',
  styleUrls: ['./lecturer-sidebar.component.scss'],
})
export class LecturerSidebarComponent {
  public items: MenuItem[] = [
    {
      label: 'Submission',
      routerLink: 'submissions',
      icon: 'pi pi-book',
      tooltipOptions: {
        tooltipLabel: 'Submission',
      },
    },
    {
      label: 'Grade',
      routerLink: 'grades',
      icon: 'pi pi-sitemap',
      tooltipOptions: {
        tooltipLabel: 'Grade Page',
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
      label: 'Projects',
      routerLink: 'projects',
      icon: 'pi pi-sitemap',
      tooltipOptions: {
        tooltipLabel: 'Projects Page',
      },
    },
  ];

  constructor() {}
}
