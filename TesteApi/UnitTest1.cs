using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Moq;
using Service.AutoMapper;
using Service.Interface;
using Service.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi;
using Xunit;

namespace TesteApi
{
    public class UnitTest1
    {
        private readonly HttpClient _client;
        private readonly User _user;
        private readonly Mock<IUserRepository> _userRepository;
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        public UnitTest1()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new UserProfile());
            });
            _userRepository = new Mock<IUserRepository>();
            _user = new User()
            {
                Id = 0,
                Name = "Jannielly",
                Email = "janniellygarcia12@gmail.com",
                Senha = "senha",
                PhoneNumber = "88993085731",
                BirthDate = "21062000",
                PasswordCheck = "senha"

            };
            _userService = new UserService(_userRepository.Object, _mapper);
            var configuration = new ConfigurationBuilder()
                                    .AddJsonFile("appsettings.json")
                                    .Build();
            var server = new TestServer(new WebHostBuilder()
                .UseConfiguration(configuration)
                .UseStartup<Startup>());
            _client = server.CreateClient();    

        }
        [Theory]
        [InlineData("POST")]
        public async Task TestAuthenticGenery(string metodo)
        {
            var request = new HttpRequestMessage(new HttpMethod(metodo), "/api/user/authenticateGeneric");
            var response = await _client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task InsertUser()
        {
            _userRepository.Setup(x => x.GetAllAuthentication("janniellygarcia12@gmail.com", "senha")).Returns(_user);
            
            var result =  _userService.GetUserForLogin("janniellygarcia12@gmail.com", "senha");
            Assert.True(result != null ?true : false);
        }
            
    }
}
