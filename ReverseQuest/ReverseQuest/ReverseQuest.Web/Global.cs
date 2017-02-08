namespace ReverseQuest.Web
{
    public class Global
    {
        public static string ReverseQuestDevAPIUrl = System.Configuration.ConfigurationManager.AppSettings["ReverseQuestDevAPIUrl"];
        public static string ReverseQuestAPIUrl = System.Configuration.ConfigurationManager.AppSettings["ReverseQuestAPIUrl"];
        public static string AuthToken = System.Configuration.ConfigurationManager.AppSettings["AuthId"];
        public static string ClientRequestId = System.Configuration.ConfigurationManager.AppSettings["ClientRequestId"];
    }
}