namespace BGRent.Server.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    public class User : IdentityUser
    {
        public IEnumerable<BoardGame> BoardGames { get; set; } = new List<BoardGame>();
    }
}
