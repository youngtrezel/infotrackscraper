import { ApplicationConfig, ErrorHandler } from '@angular/core';
import { provideRouter } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { importProvidersFrom } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';

import { routes } from './app.routes';
import { GlobalErrorHandler } from './global-error-handler';

export const appConfig: ApplicationConfig = {
  providers: [

    importProvidersFrom(HttpClientModule, BrowserModule),

    // importProvidersFrom(HttpClientModule),
    // {        
    //   provide: ErrorHandler,
    //   useClass: GlobalErrorHandler
    // }

  ]
};
