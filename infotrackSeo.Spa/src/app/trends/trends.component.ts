import { Component, inject, ErrorHandler } from '@angular/core';
import { RouterOutlet } from '@angular/router';;
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { JsonPipe, NgFor, NgIf, CommonModule } from '@angular/common';
import { SearchResponse } from '../models/search-response';
import { HttpClient} from '@angular/common/http';
import { NgbCalendar, NgbDatepickerModule, NgbDateStruct, NgbDate } from '@ng-bootstrap/ng-bootstrap';
import { SearchTool } from '../models/search-tool';

import { TrendService } from '../services/trend/trend.service';
import { SearchTrendResponse } from '../models/search-trend-response';
;

@Component({
  selector: 'app-trends',
  standalone: true,
  imports: [RouterOutlet, JsonPipe, NgFor, NgIf, ReactiveFormsModule, FormsModule, CommonModule, NgbDatepickerModule ],
  templateUrl: './trends.component.html',
  styleUrl: './trends.component.scss'
})
export class TrendsComponent {

  title = 'Trends';
  trendForm!: FormGroup;
  result: SearchTrendResponse = new SearchTrendResponse;
  loading = false;
  errorHandler = inject(ErrorHandler);
  searchTools = Object.values(SearchTool); 

  unfilteredPageData: SearchTrendResponse[] = [];
  filteredPageData: SearchTrendResponse[] = [];



  presentDay: NgbDateStruct;
  filterByDate: {startDate: NgbDateStruct, endDate: NgbDateStruct};
  // filterByUrl:  string = " ";
  // filterByWord: string = " ";
  
  constructor(private formBuilder: FormBuilder, private trendService: TrendService) { 

    const present = new Date();

    this.presentDay = {
      year: present.getFullYear(),
      month: present.getMonth() + 1,
      day: present.getDate()
    };

    this.filterByDate = {
      startDate: {
        year: present.getFullYear() - 1,
        month: present.getMonth() + 1,
        day: present.getDate()
      },
      endDate: this.presentDay
    };

  }


  transformDate(ngbDate: NgbDateStruct): Date {
    return new Date(
      ngbDate.year, 
      ngbDate.month - 1, 
      ngbDate.day);
  }


  filterData(): void {

    this.filteredPageData = this.unfilteredPageData.filter(x =>      
      (this.filterByDate?.startDate == null ?
        true :
        new Date(x.searchDate) >= this.transformDate(this.filterByDate?.startDate)) &&
      (this.filterByDate?.endDate == null ?
        true :
        new Date(x.searchDate) <= this.transformDate(
          { year: this.filterByDate?.endDate.year, month: this.filterByDate?.endDate.month, day: this.filterByDate?.endDate.day + 1 }
        )));
  }
  
  ngOnInit(): void {

    // this.trendForm = this.formBuilder.group({
    //   WordToSearch: new FormControl(('')),
    //   UrlToFind: new FormControl((''), [Validators.pattern("^(?:(ftp|http|https)?:\/\/)?(?:[\\w-]+\\.)+([a-z]|[A-Z]|[0-9]){2,6}$")]),
    //   SearchTool: new FormControl()
    // });

    this.populatePageData();

  }


  populatePageData() {
    this.loading = true;
    this.trendService.getTrends().subscribe({

      next: (data) => {
        this.filteredPageData = data;
        this.unfilteredPageData = data;
        this.loading = false;
      },
      error: err => console.log(err)     
    })
  }

  onSubmit() {
    this.loading = true;
    this.trendService.getTrends().subscribe({

      next: (data) => {
        this.filteredPageData = data;
        this.unfilteredPageData = data;
        this.filterData()
        this.loading = false;
      },
      error: err => console.log(err)     
    })
  }
}
