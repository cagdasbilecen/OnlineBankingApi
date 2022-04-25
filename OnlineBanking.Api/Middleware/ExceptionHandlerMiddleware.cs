using Microsoft.AspNetCore.Http;
using OnlineBanking.Api.Models;
using OnlineBanking.ApplicationConstants;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineBanking.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        
        

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IApplicationBiz applicationBiz)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                BaseResponseModel<object> result;
                if (ex is GringottsException)
                {
                    var gringottsException = ex as GringottsException;
                    //TODO: Get these variables from request header.
                    var errorMessage = GetErrorMessage(applicationBiz, GeneralConstants.ApplicationName, GeneralConstants.DefaultLanguage, gringottsException.Code, gringottsException.Message);
                    
                    if (gringottsException.Type == GringottsExceptionTypes.BusinessException)
                    {
                        result = new BaseFaultResponseModel(gringottsException.Code, errorMessage);
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    }
                    else
                    {
                        result = new BaseErrorResponseModel(gringottsException.Code, errorMessage);
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    }

                }
                else
                {
                    var errorCode = ErrorMessages.TCH_TECHNICAL_ERROR;
                    result = new BaseErrorResponseModel(errorCode, GetErrorMessage(applicationBiz, GeneralConstants.ApplicationName, GeneralConstants.DefaultLanguage, errorCode), ex.ToString());
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }

                context.Response.ContentType = GeneralConstants.ResponseContentType;
                var bytes = Encoding.UTF8.GetBytes(result.ToString());
                context.Response.Body.Write(bytes, 0, bytes.Length);
            }
        }

        public string GetErrorMessage(IApplicationBiz applicationBiz, string application, string languageCode, string errorCode, string defaultMessage = "")
        {
            return applicationBiz.GetMessage(application, languageCode, errorCode, defaultMessage);
        }


    }


}
