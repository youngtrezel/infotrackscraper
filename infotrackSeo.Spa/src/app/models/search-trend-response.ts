import { SearchTool } from "./search-tool";

export class SearchTrendResponse {
    id!: string;
    wordToSearch!: string;
    urlToFind!: string;
    searchTool = SearchTool;
    positionList!: number[];
    searchDate!: Date;
}