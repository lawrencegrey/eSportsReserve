using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSportsReserve.Controller;
using eSportsReserve.Core.Data;
using eSportsReserve.Core.Manager;
using eSportsReserve.Core.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using eSportsReserve.Abstractions.Controllers;
using eSportsReserve.Abstractions.Enums;
using eSportsReserve.Abstractions.Extensions;
using eSportsReserve.Abstractions.Services;
using eSportsReserve.Abstractions.ViewModels;
using eSportsReserve.Controller.ViewModels;

namespace eSportsReserve.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : ApiController
    {
        private readonly PlayerManager _playerManager;

        public PlayerController(PlayerManager playerManager, ExecutionTimerService apiTimerService, ILoggerFactory loggerFactory)
            : base(apiTimerService, loggerFactory)
        {
            _playerManager = playerManager;
        }
    }
}
