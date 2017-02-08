

namespace ReverseQuest.Reversequest.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Linq;
    using System.Net;
    using MyRow = Entities.LoanSearchResultsRow;
    //using ReverseQuest.LoanSearchListRequest;

    public class LoanSearchResultsRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        //public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        //{
        //    return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        //}

        //public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        //{
        //    return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        //}

        //public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        //{
        //    return new MyDeleteHandler().Process(uow, request);
        //}

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
           
           var data = connection.Query<MyRow>("usp_GetResultsLoanSearch", commandType: System.Data.CommandType.Text);

            //param: new
            //{
            //    ai_loanskey = 43951 //request.ai_LoanSkey,
            //    //endDate = //request.EndDate
            //},

            var response = new ListResponse<MyRow>();
            //response.Entities = (List<MyRow>)data;
            IEnumerable<MyRow> filtered = (List<MyRow>)data;
            response.TotalCount = filtered.Count();
            response.Skip = request.Skip;
            response.Take = request.Take;

            if (request.Skip > 0)
                filtered = filtered.Skip(request.Skip);

            if (request.Take > 0)
                filtered = filtered.Take(request.Take);

            response.Entities = filtered.ToList();

            return response;
            
        }

        //private class MySaveHandler : SaveRequestHandler<MyRow> { }
        //private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}