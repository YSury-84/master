using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.PLL.Views;

namespace SocialNetwork.Tests
{
    [TestFixture]
    public class ClassTest
    {
        [Test]
        public void Authenticate_Test()
        {
            UserService userService = new UserService();
            var authenticationData = new UserAuthenticationData();

            authenticationData.Email = "mail@mail.ru";

            authenticationData.Password = "1111";

            try
            {
                var user = userService.Authenticate(authenticationData);

                Assert.True(10 == 100);
            }

            catch (WrongPasswordException)
            {
                Assert.True(100 == 100);
            }

            catch (UserNotFoundException)
            {
                Assert.True(100 == 100);
            }
        }

    }
}