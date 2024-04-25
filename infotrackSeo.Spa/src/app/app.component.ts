import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';;
import { SearchComponent } from './search/search.component';
import { TrendsComponent } from './trends/trends.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SearchComponent, TrendsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent { }
