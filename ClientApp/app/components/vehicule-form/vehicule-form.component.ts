import { MakeService } from './../../../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicule-form',
  templateUrl: './vehicule-form.component.html',
  styleUrls: ['./vehicule-form.component.css']
})
export class VehiculeFormComponent implements OnInit {
  makes: any;
  constructor(private makeService: MakeService) { }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes=>{this.makes=makes;
      console.log("MAKES", this.makes);
    });
    
  }

}
