namespace BGRent.Server.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Data.Validation.BoardGame;

    public enum AgeRating
    {
        Three,
        Seven,
        Twelve,
        Sixteen,
        Eighteen

    }
    public class BoardGame
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public int MinPlayers { get; set; }

        [Required]
        public int MaxPlayers { get; set; }

        [Required]
        public int MinPlayingTime { get; set; }

        [Required]
        public int MaxPlayingTime { get; set; }

        [Required]
        public AgeRating AgeRating { get; set; }

        [Required]
        public double Weight { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
