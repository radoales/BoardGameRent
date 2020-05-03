using BGRent.Server.Data;
using BGRent.Server.Data.Models;

namespace BGRent.Server.Features.BoardGames
{
    using System.Threading.Tasks;
    public class BoardGameService : IBoardGameService
    {
        private readonly BGRentDbContext db;

        public BoardGameService(BGRentDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string name, string description, int minPlayers, int maxPlayers,
            int minPlayingTime, int maxPlayingTime, AgeRating ageRating, double weight, int categoryId, string userId)
        {
            var boardGame = new BoardGame
            {
                Name = name,
                Description = description,
                MinPlayers = minPlayers,
                MaxPlayers = maxPlayers,
                MinPlayingTime = minPlayingTime,
                MaxPlayingTime = maxPlayingTime,
                AgeRating = ageRating,
                UserId = userId,
                CategoryId = categoryId,
                Weight = weight
            };

            db.Add(boardGame);
            await db.SaveChangesAsync();

            return boardGame.Id;
        }
    }
}
