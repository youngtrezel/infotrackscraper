import { ErrorHandler, Injectable } from "@angular/core";

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

    handleError(error: any): void {
        console.error("Issue occurred internally.")
        throw new Error("Method not implemented.", error);
    }

}