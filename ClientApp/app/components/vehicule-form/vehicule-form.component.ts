import { FeatureService } from './../../feature.service';
import { MakeService } from './../../../services/make.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehicule-form',
  templateUrl: './vehicule-form.component.html',
  styleUrls: ['./vehicule-form.component.css']
})
export class VehiculeFormComponent implements OnInit {
  makes: any[];
  models: any[];
  vehicle: any = {};
  features: any[];
  variablePrueba: string;

  constructor(private makeService: MakeService,
              private featureService: FeatureService) {       
  }

  ngOnInit() {
    this.makeService.getMakes().subscribe(makes=>{
      this.makes=makes;
      
    });
    
    this.featureService.getFeatures().subscribe(features => { 
      this.features = features
      
    });    
    
  }

  onMakeChange()
  {
     var selectedMake = this.makes.find(m=>m.id == this.vehicle.make);
     this.models = selectedMake ? selectedMake.models : [];    
  }

}
