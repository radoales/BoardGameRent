namespace BGRent.Server.Features.BoardGames.Models
{
    using BGRent.Server.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static BGRent.Server.Data.Validation.BoardGame;
    public class BoardGameUpdateRequestModel
    {
        [Required]
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

        public bool IsAvailable { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
