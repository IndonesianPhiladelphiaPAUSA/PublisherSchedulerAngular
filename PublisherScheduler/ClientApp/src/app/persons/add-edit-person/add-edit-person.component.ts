import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-add-edit-person',
  templateUrl: './add-edit-person.component.html',
  styleUrls: ['./add-edit-person.component.css']
})
export class AddEditPersonComponent implements OnInit {

  constructor(private service:SharedService) { }

  @Input() person:any;
  Id:string;
  Name:string;
  IsActive:boolean;
  SecurityLevel:number;
  PhotoFileName:string;
  PhotoFilePath:string;

  CapacitiesList:any=[];

  ngOnInit():void {
    this.Id = this.person.id;
    this.Name = this.person.name;
  }

  loadCapacitiesList(){
    this.service.getAllCapacityNames().subscribe((data:any) => {
      this.CapacitiesList=data;

      this.Id = this.person.Id;
      this.Name = this.person.Name;
      this.IsActive = this.person.IsActive;
      this.SecurityLevel = this.person.SecurityLevel;
      this.PhotoFileName = "";
      this.PhotoFilePath = this.service.PhotoUrl+this.PhotoFileName;

    })
  }

  addPerson(){
    var val = { Id:this.Id, Name:this.Name, IsActive:this.IsActive, SecurityLevel:this.SecurityLevel};
    this.service.addPerson(val).subscribe(data =>
      alert("Added Successfully!")
      )
  }

  updatePerson() {
    var val = { Id:this.Id, Name:this.Name, IsActive:this.IsActive, SecurityLevel:this.SecurityLevel };
    this.service.updatePerson(val).subscribe(data =>
      alert("Updated!")
      )
  }

}
