export class Query
{
    constructor(public sortBy: string, public isSortAscending: boolean, public page:number, public pageSize:number) {

            this.sortBy = sortBy;
            this.isSortAscending = isSortAscending;
            this.page = page;
            this.pageSize = pageSize;
           

        }
}