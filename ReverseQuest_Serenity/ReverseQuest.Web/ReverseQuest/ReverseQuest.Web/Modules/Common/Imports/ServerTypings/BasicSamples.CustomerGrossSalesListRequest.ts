namespace ReverseQuest.BasicSamples {
    export interface CustomerGrossSalesListRequest extends Serenity.ListRequest {
        StartDate?: string;
        EndDate?: string;
    }
}

