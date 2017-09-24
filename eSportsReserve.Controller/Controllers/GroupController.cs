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
    public class GroupController : ApiController
    {
        private readonly GroupManager _groupManager;

        public GroupController(GroupManager groupManager, ExecutionTimerService apiTimerService, ILoggerFactory loggerFactory)
            : base(apiTimerService, loggerFactory)
        {
            _groupManager = groupManager;
        }

        //all groups
        [HttpGet, Route("/group")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroups()
        {
            try
            {
                var group = await _groupManager.GetGroups();
                if (group != null)
                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Groups retrieved successfully."));
                else
                    return NotFound(ApiResponse(ApiResponseStatus.Fail, group, $@"Groups could not be found."));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while retrieving record. Please try again later.");
            }
        }

        //all groups by name
        [HttpGet, Route("/group/name/{name}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroupByName(string name)
        {
            try
            {
                var group = await _groupManager.GetGroupByName(name);
                if (group != null)
                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Group(s) with values {name} retrieved successfully."));
                else
                    return NotFound(ApiResponse(ApiResponseStatus.Fail, group, $@"Groups with values {name} could not be found."));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while retrieving record. Please try again later.");
            }
        }


        //all groups by id
        [HttpGet, Route("/group/id/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroupById(System.Guid Id)
        {
            try
            {
                var group = await _groupManager.GetGroupById(Id);
                if (group != null)
                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Group(s) with id {Id} retrieved successfully."));
                else
                    return NotFound(ApiResponse(ApiResponseStatus.Fail, group, $@"Group(s) with id {Id} could not be found."));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while retrieving record. Please try again later.");
            }
        }


        //create group
        [HttpPost, Route("/group/create/")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateGroup([FromBody] GroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Group group = new Group()
                    {
                        Name = model.Name,
                        CaptainId = model.CaptainId,
                        GroupType = model.GroupType,
                        CreatedAt = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                        UpdatedAt = model.UpdateddAt,
                         UpdatedBy = model.UpdatedBy
                    };

                    await _groupManager.CreateGroup(group);

                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Group successfully added."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while adding record. Please try again later.");
            }
        }

        //delete group
        [HttpDelete, Route("/group/delete/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteGroup([FromBody] GroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Group group = new Group()
                    {
                        Name = model.Name,
                        CaptainId = model.CaptainId,
                        GroupType = model.GroupType,
                        CreatedAt = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                        UpdatedAt = model.UpdateddAt,
                        UpdatedBy = model.UpdatedBy
                    };

                    await _groupManager.DeleteGroup(group);

                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Group successfully deleted."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while deleting record. Please try again later.");
            }
        }

        //update group
        [HttpPut, Route("/group/update/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateGroup([FromBody] GroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Group group = new Group()
                    {
                        Name = model.Name,
                        CaptainId = model.CaptainId,
                        GroupType = model.GroupType,
                        CreatedAt = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                        UpdatedAt = model.UpdateddAt,
                         UpdatedBy = model.UpdatedBy
                    };

                    await _groupManager.UpdatePlayerGroup(group);

                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"group invitation successfully updated."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while updating record. Please try again later.");
            }
        }


        //****************************************************************************************

       
        //all groups by captain
        [HttpGet, Route("/group/captain/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroupByCaptain(System.Guid captainId)
        {
            try
            {
                var group = await _groupManager.GetGroupsIOwn(captainId);
                if (group != null)
                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Leader Groups retrieved successfully."));
                else
                    return NotFound(ApiResponse(ApiResponseStatus.Fail, group, $@"Leader Groups could not be found."));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while retrieving record. Please try again later.");
            }
        }

        //get player groups
        [HttpGet, Route("/group/player/group/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPlayerGroups(System.Guid playerId)
        {
            try
            {
                var group = await _groupManager.GetPlayerGroups(playerId);
                if (group != null)
                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Player Groups retrieved successfully."));
                else
                    return NotFound(ApiResponse(ApiResponseStatus.Fail, group, $@"Player Groups could not be found."));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while retrieving record. Please try again later.");
            }
        }

        //get players in group
        [HttpGet, Route("/group/players/")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroupPlayers(System.Guid groupId)
        {
            try
            {
                var group = await _groupManager.GetPlayersInGroup(groupId);
                if (group != null)
                    return Ok(ApiResponse(ApiResponseStatus.Success, group, $@"Players in group retrieved successfully."));
                else
                    return NotFound(ApiResponse(ApiResponseStatus.Fail, group, $@"Players in group could not be found."));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while retrieving record. Please try again later.");
            }
        }

        //create player group
        [HttpPost, Route("/group/player/create/")]
        [Produces("application/json")]
        public async Task<IActionResult> CreatePlayerGroup([FromBody] PlayerGroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlayerGroup playergroup = new PlayerGroup()
                    {
                        GroupId = model.GroupId,
                        PlayerId = model.PlayerId,
                        IsInvitationAccepted = model.IsInvitationAccepted

                    };

                    await _groupManager.CreatePlayerGroup(playergroup);

                    return Ok(ApiResponse(ApiResponseStatus.Success, playergroup, $@"Player succesfully added to GrGroup successfully added."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while adding record. Please try again later.");
            }
        }

        //delete group
        [HttpDelete, Route("/group/player/delete/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeletePlayerGroup([FromBody] PlayerGroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlayerGroup playergroup = new PlayerGroup()
                    {
                        GroupId = model.GroupId,
                        PlayerId = model.PlayerId,
                        IsInvitationAccepted = model.IsInvitationAccepted

                    };

                    await _groupManager.DeletePlayerGroup(playergroup);

                    return Ok(ApiResponse(ApiResponseStatus.Success, playergroup, $@"group invitation successfully deleted."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while updating record. Please try again later.");
            }
            

        }


        //update group
        [HttpPut, Route("/group/player/update/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdatePlayerGroup([FromBody] PlayerGroupViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlayerGroup playergroup = new PlayerGroup()
                    {
                        GroupId = model.GroupId,
                        PlayerId = model.PlayerId,
                        IsInvitationAccepted = model.IsInvitationAccepted

                    };

                    await _groupManager.UpdatePlayerGroup(playergroup);

                    return Ok(ApiResponse(ApiResponseStatus.Success, playergroup, $@"group invitation successfully updated."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while updating record. Please try again later.");
            }

        }

        //****************************************************************************************

        [HttpGet, Route("/group/invitation/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetGroupInvitation(System.Guid groupId)
        {
            try
            {
                var groupinvitations = await _groupManager.GetGroupInvitation(groupId);
                if (groupinvitations != null)
                    return Ok(ApiResponse(ApiResponseStatus.Success, groupinvitations, $@"Group invitations(s) retrieved successfully."));
                else
                    return NotFound(ApiResponse(ApiResponseStatus.Fail, groupinvitations, $@"Group invitation(s) could not be found."));

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while retrieving record. Please try again later.");
            }
        }

        //create group invitation
        [HttpPost, Route("/group/invitation/create/")]
        [Produces("application/json")]
        public async Task<IActionResult> CreateGroupInvitation([FromBody] GroupInvitationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GroupInvitation invitation = new GroupInvitation()
                    {
                        GroupId = model.GroupId,
                        ContactInfo = model.ContactInfo,
                        ContactPreference = model.ContactPreference,
                        IsAccepted = model.IsAccepted,
                        CreatedAt = model.CreatedAt
                    };

                    await _groupManager.CreateGroupInvitation(invitation);

                    return Ok(ApiResponse(ApiResponseStatus.Success, invitation, $@"Invitation added successfully added."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while adding record. Please try again later.");
            }

        }

        //delete group invitation
        [HttpDelete, Route("/group/invitation/delete/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> DeleteGroupInvitation([FromBody] GroupInvitationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GroupInvitation invitation = new GroupInvitation()
                    {
                        GroupId = model.GroupId,
                        ContactInfo = model.ContactInfo,
                        ContactPreference = model.ContactPreference,
                        IsAccepted = model.IsAccepted,
                        CreatedAt = model.CreatedAt
                    };

                    await _groupManager.DeleteGroup();

                    return Ok(ApiResponse(ApiResponseStatus.Success, invitation, $@"Invitation added successfully deleted."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while adding record. Please try again later.");
            }

        }

        //update group invitation
        [HttpPut, Route("/group/invitation/update/{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> UpdateGroupInvitation([FromBody] GroupInvitationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GroupInvitation invitation = new GroupInvitation()
                    {
                        GroupId = model.GroupId,
                        ContactInfo = model.ContactInfo,
                        ContactPreference = model.ContactPreference,
                        IsAccepted = model.IsAccepted,
                        CreatedAt = model.CreatedAt
                    };

                    await _groupManager.UpdateGroupInvitation(invitation);

                    return Ok(ApiResponse(ApiResponseStatus.Success, invitation, $@"group invitation successfully updated."));
                }

                return BadRequest(ApiResponse(ApiResponseStatus.Fail, GetModelStateErrors(ModelState), "Model validation failure."));
            }

            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return HandleException("1", e, "An error occurred while updating record. Please try again later.");
            }
        }

        private ObjectResult HandleException(string errorCode, Exception e, string errorMessage)
        {
            var error = new ErrorViewModel
            {
                ErrorCode = errorCode,
                ErrorString = e.Message
            };
            return StatusCode(500, ApiResponse(ApiResponseStatus.Error, error, errorMessage));
        }


    }
}
