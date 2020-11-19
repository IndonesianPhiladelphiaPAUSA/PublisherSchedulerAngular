import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-capacity',
  templateUrl: './show-capacity.component.html',
  styleUrls: ['./show-capacity.component.css']
})
export class ShowCapacityComponent implements OnInit {

  constructor(private service:SharedService) { }

  CapacitiesList:any[];

  ngOnInit() {
    this.refreshCapacitiesList();
  }

  refreshCapacitiesList(){
    this.service.getCapacityList().subscribe(data => {
      this.CapacitiesList=data;
    })
  }

}
