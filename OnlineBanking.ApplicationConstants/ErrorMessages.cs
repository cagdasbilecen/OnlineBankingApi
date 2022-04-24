using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.ApplicationConstants
{
    public static class ErrorMessages
    {
        public static readonly string MON_CUSTOMER_NOT_FOUND = "MON-003";
        public static readonly string MON_ACCOUNT_NOT_FOUND = "MON-002";
        public static readonly string CUS_CUSTOMER_NOT_FOUND = "CUS-001";
        public static readonly string MON_INSUFFICIENT_BALANCE = "MON-001";
        public static readonly string TCH_TECHNICAL_ERROR= "TCH-001";
        public static readonly string MON_ACCOUNT_CURRENCY_DOES_NOT_MATCH = "MON-004";

    }
}
