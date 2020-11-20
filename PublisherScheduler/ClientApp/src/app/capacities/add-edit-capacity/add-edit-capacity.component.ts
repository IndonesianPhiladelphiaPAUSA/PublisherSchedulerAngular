import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-capacity',
  templateUrl: './add-edit-capacity.component.html',
  styleUrls: ['./add-edit-capacity.component.css']
})
export class AddEditCapacityComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() capacity:any;
  Id:string;
  Name:string;

  ngOnInit():void {
    this.Id = this.capacity.id;
    this.Name = this.capacity.name;
  }

  addCapacity(){
    var val = { Id:this.Id, Name:this.Name };
    this.service.addCapacity(val).subscribe(data =>
      alert("Added Successfully!")
      )
  }

  updateCapacity() {
    var val = { Id:this.Id, Name:this.Name };
    this.service.updateCapacity(val).subscribe(data =>
      alert("Updated!")
      )
  }

}
