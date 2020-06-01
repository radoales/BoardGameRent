namespace BGRent.Test.Features.Identity.TestData
{
    using BGRent.Server.Features.Identity.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Collections.Generic;
    public class IdentityTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new RegisterRequestModel { UserName = "short", Email = "@as", Password = "22" }, new IdentityResult{ } };
            yield return new object[] { new RegisterRequestModel { UserName = "short", Email = "@as", Password = "222" }, new IdentityResult { } };
            yield return new object[] { new RegisterRequestModel { UserName = "short", Email = "@as", Password = "2" }, new IdentityResult { } };
            yield return new object[] { new RegisterRequestModel { UserName = "short", Email = "@as", Password = "2222" }, new IdentityResult { } };
            yield return new object[] { new RegisterRequestModel { UserName = "short", Email = "@as", Password = "22222" }, new IdentityResult { } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
