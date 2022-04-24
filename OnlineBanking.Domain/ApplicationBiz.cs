using System;
using System.Collections.Generic;
using OnlineBanking.Data.Models;
using OnlineBanking.Data.Repositories;
using OnlineBanking.Domain.Interfaces;

namespace OnlineBanking.Domain
{
    public class ApplicationBiz : IApplicationBiz
    {
        private readonly IRepository repository;
        public ApplicationBiz(IRepository repository)
        {
            this.repository = repository;
        }

        
        public string GetMessage(string application, string languageCode, string messageCode, string defaultMessage)
        {
            try
            {
                var messageList = GetMessageList(application, languageCode);
                if (messageList.ContainsKey(messageCode))
                {
                    return messageList[messageCode];
                }

                return defaultMessage;
            }
            catch (Exception ex)
            {
                return defaultMessage;
            }
        }

        private Dictionary<string, string> GetMessageList(string application, string languageCode)
        {
            //TODO: Apply caching here.
            var response = new Dictionary<string, string>();
            var messageList = repository.GetByFilter<ErrorMessage>(r => r.Application == application && r.Language == languageCode);
            if (messageList != null && messageList.Count > 0)
            {
                foreach (var message in messageList)
                {
                    response.TryAdd(message.MessageCode, message.Message);
                }
            }
            return response;
        }

    }
    
}
