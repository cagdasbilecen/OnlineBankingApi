using System;

namespace OnlineBanking.Exceptions
{
    public class GringottsException : Exception
    {
        public string Code { get; }
        public GringottsExceptionTypes Type { get; set; }

        public GringottsException(GringottsExceptionTypes type, string code, string message = "") : base(message)
        {
            Code = code.ToString();
            Type = type;
        }
    }

    public enum GringottsExceptionTypes
    {
        BusinessException,
        SystemException
    }
}
