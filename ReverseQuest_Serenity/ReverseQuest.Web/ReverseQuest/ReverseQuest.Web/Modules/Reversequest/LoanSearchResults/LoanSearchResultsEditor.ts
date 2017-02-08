
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace ReverseQuest.Reversequest {
    
    @Serenity.Decorators.registerClass()
    export class LoanSearchResultsEditor extends Common.GridEditorBase<LoanSearchResultsRow> {
        protected getColumnsKey() { return 'Reversequest.LoanSearchResults'; }
        protected getDialogType() { return LoanSearchResultsEditorDialog; }
                protected getLocalTextPrefix() { return LoanSearchResultsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}