import { Component } from '@angular/core';
import { PrimeNGConfig } from 'primeng/api';
import { DataGenService } from './services/data-gen.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(
    private primengConfig: PrimeNGConfig,
    private dataDervice: DataGenService
  ) {}

  ngOnInit() {
    this.primengConfig.ripple = true;
    this.dataDervice.genrateLogedStudent;
  }
}
