
namespace ReverseQuest.Reversequest {
    
    @Serenity.Decorators.registerClass()
    export class LoanSearchResultsGrid extends Serenity.EntityGrid<Object, any> {
        protected getColumnsKey() { return 'Reversequest.LoanSearchResults'; }
        protected getDialogType() { return LoanSearchResultsDialog; }
        //protected getIdProperty() { return LoanSearchResultsRow.idProperty; }
        protected getIdProperty() { return "__id"; }
        protected getLocalTextPrefix() { return LoanSearchResultsRow.localTextPrefix; }
        protected getService() { return LoanSearchResultsService.baseUrl; }

        private nextId = 1;

        constructor(container: JQuery) {
            super(container);
        }

        protected onViewProcessData(response: Serenity.ListResponse<Reversequest.LoanSearchResultsRow>) {

            response = super.onViewProcessData(response);

           // alert(response);
              
             //there is no __id property in CustomerGrossSalesRow but 
             //this is javascript and we can set any property of an object
            for (var x of response.Entities) {
                (x as any).__id = this.nextId++;
            }
            return response;
        }

        //protected onViewProcessData(response: Serenity.ListResponse<Reversequest.LoanSearchResultsRow>) {
            
        //    response = super.onViewProcessData(response);

        //    // there is no __id property in CustomerGrossSalesRow but 
        //    // this is javascript and we can set any property of an object
        //    for (var x of response.Entities) {
        //        (x as any).__id = this.nextId++;
        //    }
        //    return response;
        //}
    }
}