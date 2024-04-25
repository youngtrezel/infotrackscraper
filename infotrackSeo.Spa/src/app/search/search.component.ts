import { Component, inject, ErrorHandler } from '@angular/core';
import { RouterOutlet } from '@angular/router';;
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { JsonPipe, NgFor, NgIf, CommonModule } from '@angular/common';
import { SearchResponse } from '../models/search-response';

import { SearchRequest } from '../models/search-request';
import { SearchTool } from '../models/search-tool';
import { SearchService } from '../services/search/search.service';

@Component({
  selector: 'app-search',
  standalone: true,
  imports: [RouterOutlet, JsonPipe, NgFor, NgIf, ReactiveFormsModule, FormsModule, CommonModule ],
  templateUrl: './search.component.html',
  styleUrl: './search.component.scss'
})
export class SearchComponent {

  title = 'infotrackSeo.Spa';
  profileForm!: FormGroup;
  result: SearchResponse = new SearchResponse;
  searchTools = Object.values(SearchTool); 
  loading = false;
  errorHandler = inject(ErrorHandler);

  ngOnInit(): void {  

    this.profileForm = this.formBuilder.group({
      WordToSearch: new FormControl((''), [Validators.required]),
      UrlToFind: new FormControl((''), [Validators.required, Validators.pattern("^(?:(ftp|http|https)?:\/\/)?(?:[\\w-]+\\.)+([a-z]|[A-Z]|[0-9]){2,6}$")]),
      SearchTool: new FormControl(SearchTool.Google, [Validators.required])
    });
  }

  constructor( private formBuilder: FormBuilder, private searchService: SearchService) { }

  onSubmit() {

    this.loading = true;

    const searchRequest: SearchRequest = {
      SearchTool: this.profileForm.value.SearchTool,
      WordToSearch: this.profileForm.value.WordToSearch,
      UrlToFind: this.profileForm.value.UrlToFind
    }

    this.searchService.getSearch(searchRequest).subscribe({

      next: (data) => {
        this.result = data;
        this.loading = false;
      },
      error: err => console.log(err)
    })
  }
}
