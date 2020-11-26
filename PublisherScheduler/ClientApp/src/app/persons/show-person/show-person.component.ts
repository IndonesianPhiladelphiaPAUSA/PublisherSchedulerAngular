import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-show-person',
  templateUrl: './show-person.component.html',
  styleUrls: ['./show-person.component.css']
})
export class ShowPersonComponent implements OnInit {

  constructor(private service:SharedService) { }

  PersonsList:any=[];
  ModalTitle:string;
  ActivateAddEditPersonComp:boolean=false;
  person:any;

  ngOnInit(): void {
    this.refreshPersonsList();
  }

  addClick(){
    this.person={
      Id:0,
      Name:"",
      IsActive:1,
      SecurityLevel:0,
      PhotoFileName:"anonymous.png"
    }
    this.ModalTitle="Add Person";
    this.ActivateAddEditPersonComp=true;
  }

  editClick(item) {
    this.person=item;
    this.ModalTitle="Edit Person";
    this.ActivateAddEditPersonComp=true;
  }

  deleteClick(item) {
    if(confirm("Are you sure?")) {
      this.service.deletePerson(item.id).subscribe(data => {
        this.refreshPersonsList();
      })
    };
  }

  closeClick(){
    this.ActivateAddEditPersonComp=false;
    this.refreshPersonsList();
  }

  refreshPersonsList(){
    this.service.getPersonList().subscribe(data => {
      console.log(data);
      this.PersonsList=data;
    })
  }

}
