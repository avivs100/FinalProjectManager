import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-student-sidebar',
  templateUrl: './student-sidebar.component.html',
  styleUrls: ['./student-sidebar.component.scss'],
})
export class StudentSidebarComponent {
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
  ];

  constructor() {}
}
