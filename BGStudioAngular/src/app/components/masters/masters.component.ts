import { Component,OnInit } from '@angular/core';
import { User } from 'src/app/models/user';
import { MastersService} from 'src/app/services/masters.service';

@Component({
  selector: 'app-masters',
  templateUrl: './masters.component.html',
  styleUrls: ['./masters.component.scss']
})
export class MastersComponent implements OnInit {

  masters: User[] = [];
  
  constructor(
    private masterService: MastersService,
    ) {}

  ngOnInit() {
    this.masterService.GetMasters().subscribe( result => this.masters = result);
  }
  click(){
    console.log(this.masters);
  }
}
