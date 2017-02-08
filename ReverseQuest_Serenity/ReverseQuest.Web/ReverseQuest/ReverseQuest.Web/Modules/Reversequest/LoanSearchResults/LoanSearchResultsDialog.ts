
namespace ReverseQuest.Reversequest {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class LoanSearchResultsDialog extends Serenity.EntityDialog<LoanSearchResultsRow, any> {
        protected getFormKey() { return LoanSearchResultsForm.formKey; }
        protected getIdProperty() { return LoanSearchResultsRow.idProperty; }
        protected getLocalTextPrefix() { return LoanSearchResultsRow.localTextPrefix; }
        protected getNameProperty() { return LoanSearchResultsRow.nameProperty; }
        protected getService() { return LoanSearchResultsService.baseUrl; }

        protected form = new LoanSearchResultsForm(this.idPrefix);

    }
}