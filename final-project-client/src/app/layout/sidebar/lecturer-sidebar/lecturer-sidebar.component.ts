import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-lecturer-sidebar',
  templateUrl: './lecturer-sidebar.component.html',
  styleUrls: ['./lecturer-sidebar.component.scss'],
})
export class LecturerSidebarComponent {
  public items: MenuItem[] = [
    // {
    //   label: 'Grade',
    //   routerLink: 'grades',
    //   icon: 'pi pi-sitemap',
    //   tooltipOptions: {
    //     tooltipLabel: 'Grade Page',
    //   },
    // },
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
      label: 'Projects',
      routerLink: 'projects',
      icon: 'pi pi-sitemap',
      tooltipOptions: {
        tooltipLabel: 'Projects Page',
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
    // {
    //   label: 'Grades',
    //   routerLink: 'grades',
    //   icon: 'pi pi-star-fill',
    //   tooltipOptions: {
    //     tooltipLabel: 'Grades',
    //   },
    // },
  ];

  constructor() {}
}
