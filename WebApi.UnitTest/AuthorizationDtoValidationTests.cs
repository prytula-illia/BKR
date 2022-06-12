using DTOs.Authentication;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.UnitTest
{
    public class AuthorizationDtoValidationTests
    {
        private IList<ValidationResult> GetValidationErrors<T>(T dto)
        {
            var ctx = new ValidationContext(dto);
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(dto, ctx, result);
            return result; 
        }

        [Test]
        public void LoginModel_If_Password_Not_Provided_Validation_Fails()
        {
            var result = GetValidationErrors(new LoginModelDto()
            {
                Username = "UserName"
            });

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result.FirstOrDefault(x => x.ErrorMessage == "Password is required"));
        }

        [Test]
        public void LoginModel_If_Username_Not_Provided_Validation_Fails()
        {
            var result = GetValidationErrors(new LoginModelDto()
            {
                Password = "3asd2341asfd234###44"
            });

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result.FirstOrDefault(x => x.ErrorMessage == "User Name is required"));
        }

        [Test]
        public void RegisterModel_If_Password_Not_Provided_Validation_Fails()
        {
            var result = GetValidationErrors(new RegisterModelDto()
            {
                Username = "UserName",
                Email = "iasd@asdfm.com"
            });

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result.FirstOrDefault(x => x.ErrorMessage == "Password is required"));
        }

        [Test]
        public void RegisterModel_If_Username_Not_Provided_Validation_Fails()
        {
            var result = GetValidationErrors(new RegisterModelDto()
            {
                Password = "3asd2341asfd234###44",
                Email = "iasd@asdfm.com"
            });

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result.FirstOrDefault(x => x.ErrorMessage == "User Name is required"));
        }

        [Test]
        public void RegisterModel_If_Email_Not_Provided_Validation_Fails()
        {
            var result = GetValidationErrors(new RegisterModelDto()
            {
                Username = "username",
                Password = "3asd2341asfd234###44"
            });

            Assert.IsNotEmpty(result);
            Assert.IsNotNull(result.FirstOrDefault(x => x.ErrorMessage == "Email is required"));
        }
    }
}
