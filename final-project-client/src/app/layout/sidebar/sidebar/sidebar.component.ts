import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent {
  public expendSideBar = true;

  public items: MenuItem[] = [
    {
      label: 'Home',
      routerLink: '',
      icon: 'pi pi-book',
      tooltipOptions: {
        tooltipLabel: 'Home',
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
  ];

  constructor() {}

  public toggleSidebar(): void {
    this.expendSideBar = !this.expendSideBar;
    console.log(this.expendSideBar);
  }
}
