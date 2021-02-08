using ArandaSoft.Identity.API.Infrastructure;
using ArandaSoft.Identity.API.Models.Request;
using ArandaSoft.Identity.API.Models.Response;
using ArandaSoft.Identity.Contracts.Dtos;
using ArandaSoftware.Identity.Manager.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArandaSoft.Identity.API.Controllers
{
    [Route("api/identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityManager _identityManager;
        private readonly IMapper _mapper;

        public IdentityController(IIdentityManager identityManager, IMapper mapper)
        {
            _identityManager = identityManager;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(
            [FromBody]LoginRequestModel loginRequestModel)
        {
            IActionResult response = Unauthorized();
            var loginRequestDto = _mapper.Map<LoginRequestDto>(loginRequestModel);

            var isUserAuthenticated = await _identityManager.LoginAsync(loginRequestDto);

            if(isUserAuthenticated)
            {
                string tokenString = await _identityManager.GenerateJSONWebToken(loginRequestModel.UserName);
                response = Ok(new { token = tokenString });
            }

            return response;
        }

        [Authorize(Policy = Constants.SelectPolicy)]
        [HttpGet("user")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetAllUsersResponseModel>> GetAllUsersAsync()
        {
            var result = await _identityManager.GetAllUsersAsync();
            var usersCollection = _mapper.Map<ICollection<UserInfoDto>, ICollection<UserInfoResponseModel>>(result);
            return new GetAllUsersResponseModel { Users = usersCollection };
        }

        [Authorize(Policy = Constants.SelectPolicy)]
        [HttpGet("user/name")]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserInfoResponseModel>> GetUserByUserNameAsync(
            [FromQuery] GetUsersByNameRequestModel getUsersByNameRequestModel)
        {
            var result = await _identityManager.GetUserByUserNameAsync(getUsersByNameRequestModel.UserName);             
            return _mapper.Map<UserInfoDto, UserInfoResponseModel>(result);
        }

        [Authorize(Policy = Constants.SelectPolicy)]
        [HttpGet("rol/users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GetUserByResponseModel>> GetUsersByRolAsync(
            [FromQuery] GetUsersByRolIdRequestModel getUsersByRolIdRequestModel)
        {

            var result = await _identityManager.GetUserByRolAsync(getUsersByRolIdRequestModel.RolId);
            var usersCollection = _mapper.Map<ICollection<UserInfoDto>, ICollection<UserInfoResponseModel>>(result);
            return new GetUserByResponseModel { Users = usersCollection };

        }

        [Authorize(Policy = Constants.CreatePolicy)]
        [HttpPost("user/add")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> AddUserAsync([FromBody] AddUserRequestModel addUserRequestModel)
        {
            var newUserDto = _mapper.Map<NewUserDto>(addUserRequestModel);
            var createdUser = await _identityManager.CreateUserAsync(newUserDto);
            return NoContent();
        }

        [Authorize(Policy = Constants.UpdatePolicy)]
        [HttpPatch("user/update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUserAsync(
            [FromBody] UpdateUserRequestModel updateUserRequestModel)
        {
            var updateUserDto = _mapper.Map<UpdateUserDto>(updateUserRequestModel);
            await _identityManager.UpdateUserInfoAsync(updateUserDto);

            return NoContent();
        }

        [Authorize(Policy = Constants.DeletePolicy)]
        [HttpDelete("user/remove/{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteUserAsync(
            [FromRoute] UserIdentifierRequestModel userIdentifier)
        {
            await _identityManager.DeledeUserAsync(userIdentifier.UserId);
            return NoContent();
        }
    }
}
