import { Component, OnInit } from '@angular/core';
import { NavBarComponent } from '../nav-bar/nav-bar.component';
import { DataService } from '../data.service';
import { CommonModule, JsonPipe } from '@angular/common';
import { RouterLink } from '@angular/router';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-classes',
  standalone: true,
  imports: [NavBarComponent, RouterLink, RouterOutlet, CommonModule],
  providers: [DataService, HttpClient],
  templateUrl: './classes.component.html',
  styleUrls: ['./classes.component.css'],
})
export class ClassesComponent implements OnInit {

  classes: any[] = [];

  constructor(private data: DataService) {}

  ngOnInit(): void {
    this.data.getAllClasses().subscribe(
      (resp) => {
        this.classes = resp;
      }
    );
  }

}
