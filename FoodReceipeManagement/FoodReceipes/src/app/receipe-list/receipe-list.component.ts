
import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { RepositoryService } from '../shared/repository.service';
import { Receipe } from '../_interface/receipe.model';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { Router } from '@angular/router';


@Component({
  selector: 'app-receipe-list',
  templateUrl: './receipe-list.component.html',
  styleUrl: './receipe-list.component.css'
})
export class ReceipeListComponent implements OnInit, AfterViewInit {

  public displayedColumns = ['name', 'description', 'cookingTime', 'update', 'delete'
  ];
    public dataSource = new MatTableDataSource<Receipe>();

    @ViewChild(MatSort) sort! : MatSort;

    @ViewChild(MatPaginator) paginator! : MatPaginator;

    constructor(private service: RepositoryService, private router: Router) {
      
    }
    ngOnInit(): void {
      this.getReceipes();
   }
   ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
  public getReceipes = () => {
    this.service.getData('/api/FoodReceipe').subscribe(res => {
      this.dataSource.data = res as Receipe[];
    });
  }
  public redirectToDetails = (id: number) => {
    let url: string = `/details/${id}`;
    this.router.navigate([url]);
  }
  public redirectToUpdate = (id: number) => {
    
  }
  public redirectToDelete = (id: number) => {
    
  }
  public doFilter = (event: Event) => {
    this.dataSource.filter = (event.target as HTMLInputElement).value.trim().toLocaleLowerCase();
  }
}
