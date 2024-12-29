namespace CashFlow.Communication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessage { get; set; }

        public ResponseErrorJson(string errrorMessage)
        {
            ErrorMessage = [errrorMessage];
        }

        public ResponseErrorJson(List<string> errrorMessages)
        {
            ErrorMessage = errrorMessages;
        }
    }
}
