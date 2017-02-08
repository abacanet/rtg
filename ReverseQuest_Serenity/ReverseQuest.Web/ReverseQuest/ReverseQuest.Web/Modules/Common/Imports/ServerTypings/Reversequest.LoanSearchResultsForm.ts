namespace ReverseQuest.Reversequest {
    export class LoanSearchResultsForm extends Serenity.PrefixedContext {
        static formKey = 'Reversequest.LoanSearchResults';

    }

    export interface LoanSearchResultsForm {
        OriginalLoanNumber: Serenity.StringEditor;
        FhaCaseNumber: Serenity.StringEditor;
        PriorServicerLoanNumber: Serenity.StringEditor;
        InvestorLoanNumber: Serenity.StringEditor;
        LoanStatus: Serenity.StringEditor;
        LoanSubStatus: Serenity.StringEditor;
        BorrowerFirstName: Serenity.StringEditor;
        BorrowerMiddleName: Serenity.StringEditor;
        BorrowerLastName: Serenity.StringEditor;
        CoborrowerFirstName: Serenity.StringEditor;
        CoborrowerMiddleName: Serenity.StringEditor;
        CoborrowerLastName: Serenity.StringEditor;
        BorrowerPhoneNumber: Serenity.StringEditor;
        EnbsFirstName: Serenity.StringEditor;
        EnbsMiddleName: Serenity.StringEditor;
        EnbsLastName: Serenity.StringEditor;
        PropertyAddress1: Serenity.StringEditor;
        PropertyAddress2: Serenity.StringEditor;
        PropertyCity: Serenity.StringEditor;
        PropertyCounty: Serenity.StringEditor;
        PropertyState: Serenity.StringEditor;
        PropertyZipcode: Serenity.StringEditor;
        ServicerName: Serenity.StringEditor;
        InvestorName: Serenity.StringEditor;
        LoanPoolDescription: Serenity.StringEditor;
        ProductTypeDescription: Serenity.StringEditor;
        PaymentPlanTypeDescription: Serenity.StringEditor;
        ArmTypeDescription: Serenity.StringEditor;
        RateIndexTypeDescription: Serenity.StringEditor;
        LoanManagerName: Serenity.StringEditor;
        BoardedBy: Serenity.StringEditor;
        BoardedDate: Serenity.DateEditor;
        BoardingTypeDescription: Serenity.StringEditor;
        CreditTypeDescription: Serenity.StringEditor;
        MersMinNumber: Serenity.StringEditor;
        LoanStatusCode: Serenity.StringEditor;
        LoanSubStatusCode: Serenity.StringEditor;
        LoanServicerSkey: Serenity.IntegerEditor;
        InvestorSkey: Serenity.IntegerEditor;
        LoanPoolSkey: Serenity.IntegerEditor;
        ProductTypeSkey: Serenity.IntegerEditor;
        PaymentPlanType: Serenity.IntegerEditor;
        ArmType: Serenity.StringEditor;
        RateIndexTypeSkey: Serenity.IntegerEditor;
        LoanManagerId: Serenity.StringEditor;
        BoardingType: Serenity.StringEditor;
        CreditType: Serenity.StringEditor;
        Filler: Serenity.StringEditor;
    }

    [['OriginalLoanNumber', () => Serenity.StringEditor], ['FhaCaseNumber', () => Serenity.StringEditor], ['PriorServicerLoanNumber', () => Serenity.StringEditor], ['InvestorLoanNumber', () => Serenity.StringEditor], ['LoanStatus', () => Serenity.StringEditor], ['LoanSubStatus', () => Serenity.StringEditor], ['BorrowerFirstName', () => Serenity.StringEditor], ['BorrowerMiddleName', () => Serenity.StringEditor], ['BorrowerLastName', () => Serenity.StringEditor], ['CoborrowerFirstName', () => Serenity.StringEditor], ['CoborrowerMiddleName', () => Serenity.StringEditor], ['CoborrowerLastName', () => Serenity.StringEditor], ['BorrowerPhoneNumber', () => Serenity.StringEditor], ['EnbsFirstName', () => Serenity.StringEditor], ['EnbsMiddleName', () => Serenity.StringEditor], ['EnbsLastName', () => Serenity.StringEditor], ['PropertyAddress1', () => Serenity.StringEditor], ['PropertyAddress2', () => Serenity.StringEditor], ['PropertyCity', () => Serenity.StringEditor], ['PropertyCounty', () => Serenity.StringEditor], ['PropertyState', () => Serenity.StringEditor], ['PropertyZipcode', () => Serenity.StringEditor], ['ServicerName', () => Serenity.StringEditor], ['InvestorName', () => Serenity.StringEditor], ['LoanPoolDescription', () => Serenity.StringEditor], ['ProductTypeDescription', () => Serenity.StringEditor], ['PaymentPlanTypeDescription', () => Serenity.StringEditor], ['ArmTypeDescription', () => Serenity.StringEditor], ['RateIndexTypeDescription', () => Serenity.StringEditor], ['LoanManagerName', () => Serenity.StringEditor], ['BoardedBy', () => Serenity.StringEditor], ['BoardedDate', () => Serenity.DateEditor], ['BoardingTypeDescription', () => Serenity.StringEditor], ['CreditTypeDescription', () => Serenity.StringEditor], ['MersMinNumber', () => Serenity.StringEditor], ['LoanStatusCode', () => Serenity.StringEditor], ['LoanSubStatusCode', () => Serenity.StringEditor], ['LoanServicerSkey', () => Serenity.IntegerEditor], ['InvestorSkey', () => Serenity.IntegerEditor], ['LoanPoolSkey', () => Serenity.IntegerEditor], ['ProductTypeSkey', () => Serenity.IntegerEditor], ['PaymentPlanType', () => Serenity.IntegerEditor], ['ArmType', () => Serenity.StringEditor], ['RateIndexTypeSkey', () => Serenity.IntegerEditor], ['LoanManagerId', () => Serenity.StringEditor], ['BoardingType', () => Serenity.StringEditor], ['CreditType', () => Serenity.StringEditor], ['Filler', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(LoanSearchResultsForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

