import { Component, OnInit } from '@angular/core';
import { RepositoryService } from '../shared/repository.service';
import { Receipe } from '../_interface/receipe.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-receipe-details',
  templateUrl: './receipe-details.component.html',
  styleUrl: './receipe-details.component.css'
})
export class ReceipeDetailsComponent implements OnInit {
  public receipe! : Receipe;
  constructor(private repository: RepositoryService, private router: Router,  private activeRoute: ActivatedRoute){

  }
  ngOnInit(): void {
    this.getReceipeDetails();
  }

  public getReceipeDetails = () => {
    let id: string = this.activeRoute.snapshot.params['id'];
    let apiUrl: string = `api/FoodReceipe/${id}`;
    this.repository.getData(apiUrl)
    .subscribe(res => {
      this.receipe = res as Receipe;
    });
  }
}
