using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArandaSolft.Identity.IntegrationTests.API.Controllers
{
    public class IdentityControllerShould : IDisposable, IClassFixture<Initialization>
    {
        protected TestServer _testServer;
        protected string invalidToken = "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";
        public IdentityControllerShould(Initialization initialization)
        {
            _testServer = initialization.TestServer;
        }        

        [Fact]
        public  async Task GetAllUsers_NoToken_ReturnUnAuthorizedCode()
        {
            var response = await _testServer
                .CreateRequest("/api/identity/user")                
                .SendAsync("GET");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetAllUsers_InvalidToken_ReturnUnAuthorizedCode()
        {
            var response = await _testServer
                .CreateRequest("/api/identity/user")
                .AddHeader("Authorization", invalidToken)
                .SendAsync("GET");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetUserByUserName_NoToken_ReturnUnAuthorizedCode()
        {
            var response = await _testServer
                .CreateRequest("/api/identity/user/name?username=jcromero")
                .SendAsync("GET");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task GetUsersByRolId_NoToken_ReturnUnAuthorizedCode()
        {
            var response = await _testServer
                .CreateRequest("/api/identity/rol/users?rolId=4")
                .SendAsync("GET");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        
        public void Dispose()
        {
            _testServer.Dispose();
        }
    }
}
