namespace BGRent.Server.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<BoardGame> BoardGames { get; } = new List<BoardGame>();
    }
}
