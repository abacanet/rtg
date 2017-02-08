using Serenity.Services;

namespace ReverseQuest.Northwind
{
    public class OrderListRequest : ListRequest
    {
        public int? ProductID { get; set; }
    }
}