namespace Core.CrossCuttingConcerns.Logging
{
    public class ExceptionLogDetail : LogDetail
    {
        public ExceptionLogDetail() : base()
        {
            ExceptionMessage = string.Empty;
        }

        public ExceptionLogDetail(string fullName, string methodName, string user, string exceptionMessage, List<LogParameter> parameters) : base(fullName, methodName, user, parameters)
        {
            ExceptionMessage = exceptionMessage;
        }

        public string ExceptionMessage { get; set; }

    }
}
