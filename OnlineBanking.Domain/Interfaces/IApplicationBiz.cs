namespace OnlineBanking.Domain.Interfaces
{
    public interface IApplicationBiz
    {
        public string GetMessage(string application, string languageCode, string messageCode, string defaultMessage);
    }
}
