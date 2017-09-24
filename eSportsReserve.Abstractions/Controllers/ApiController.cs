using eSportsReserve.Abstractions.Enums;
using eSportsReserve.Abstractions.Extensions;
using eSportsReserve.Abstractions.Services;
using eSportsReserve.Abstractions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace eSportsReserve.Abstractions.Controllers
{
    public abstract class ApiController : Controller
    {
        private readonly ExecutionTimerService _apiTimerService;
        protected readonly ILogger _logger;

        protected ApiController(ExecutionTimerService apiTimerService, ILoggerFactory loggerFactory)
        {
            _apiTimerService = apiTimerService;
            _logger = loggerFactory.CreateLogger<ApiController>();
        }

        protected ApiResponseViewModel<T> ApiResponse<T>(ApiResponseStatus status, T data, string message)
        {

            return new ApiResponseViewModel<T>
            {
                Status = status.GetDescription(),
                Data = data,
                Message = message,
                Timestamp = DateTime.Now.ToString("o"),
                ExecutionTime = $@"{_apiTimerService.RequestTime()}ms"
            };
        }

        protected ModelStateErrorViewModel GetModelStateErrors(ModelStateDictionary modelState)
        {
            var errorsModel = new ModelStateErrorViewModel();
            var modelErrors = ModelState.Values.SelectMany(v => v.Errors).ToList();
            foreach (var modelError in modelErrors)
            {
                errorsModel.Errors.Add(new ErrorViewModel
                {
                    ErrorCode = "1",
                    ErrorString = modelError.ErrorMessage
                });
            }
            return errorsModel;
        }
    }
}

