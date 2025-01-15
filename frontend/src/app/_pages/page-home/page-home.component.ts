import {Component, OnInit} from '@angular/core';
import {TargetApiService} from '../../_services/target-api.service';
import {MatTableModule} from '@angular/material/table';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-page-home',
  imports: [
    MatTableModule,
    MatButton
  ],
  templateUrl: './page-home.component.html',
  styleUrl: './page-home.component.css'
})
export class PageHomeComponent implements OnInit {
  people = [];
  peopleColumns: string[] = ['taxNumber', 'name'];

  vehicles = [];
  vehiclesColumns: string[] = ['plate', 'model', 'person'];

  constructor(private targetApiService: TargetApiService) { }

  ngOnInit(): void {
    this.targetApiService.getPersonAll().subscribe({
      next: (res) => {
        this.people = res;
      }
    })

    this.targetApiService.getVehiclesAll().subscribe({
      next: (res) => {
        console.log(res);
        this.vehicles = res;
      }
    })
  }

  onClickPersonRow(row: any) {
    let {taxNumber} = row;
    this.targetApiService.getVehiclesByPersonId(taxNumber).subscribe({
      next: (res:any) => {
        this.vehicles = res;
      }
    })
  }

}
