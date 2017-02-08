
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace ReverseQuest.Reversequest {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class LoanSearchResultsEditorDialog extends Common.GridEditorDialog<LoanSearchResultsRow> {
        protected getFormKey() { return LoanSearchResultsForm.formKey; }
                protected getLocalTextPrefix() { return LoanSearchResultsRow.localTextPrefix; }
        protected getNameProperty() { return LoanSearchResultsRow.nameProperty; }
        protected form = new LoanSearchResultsForm(this.idPrefix);
    }
}