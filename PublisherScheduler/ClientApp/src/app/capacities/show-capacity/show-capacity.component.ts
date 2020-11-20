import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-capacity',
  templateUrl: './show-capacity.component.html',
  styleUrls: ['./show-capacity.component.css']
})
export class ShowCapacityComponent implements OnInit {

  constructor(private service:SharedService) { }

  CapacitiesList:any=[];
  ModalTitle:string;
  ActivateAddEditCapacityComp:boolean=false;
  capacity:any;

  ngOnInit(): void {
    this.refreshCapacitiesList();
  }

  addClick(){
    this.capacity={
      Id:0,
      Name:""
    }
    this.ModalTitle="Add Capacity";
    this.ActivateAddEditCapacityComp=true;
  }

  editClick(item) {
    this.capacity=item;
    this.ModalTitle="Edit Department";
    this.ActivateAddEditCapacityComp=true;
  }

  deleteClick(item) {
    if(confirm("Are you sure?")) {
      this.service.deleteCapacity(item.id).subscribe(data => {
        this.refreshCapacitiesList();
      })
    };
  }

  closeClick(){
    this.ActivateAddEditCapacityComp=false;
    this.refreshCapacitiesList();
  }

  refreshCapacitiesList(){
    this.service.getCapacityList().subscribe(data => {
      console.log(data);
      this.CapacitiesList=data;
    })
  }

}
