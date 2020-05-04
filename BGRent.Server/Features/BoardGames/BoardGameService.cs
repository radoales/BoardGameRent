namespace BGRent.Server.Features.BoardGames
{
    using BGRent.Server.Data.Models;
    using BGRent.Server.Features.BoardGames.Models;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public class BoardGameService : IBoardGameService
    {
        private readonly BGRentDbContext db;

        public BoardGameService(BGRentDbContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(string name, string description, int minPlayers, int maxPlayers,
            int minPlayingTime, int maxPlayingTime, AgeRating ageRating, double weight, bool isAvailable, int categoryId, string userId)
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
                Weight = weight,
                IsAvailable = isAvailable
            };

            db.Add(boardGame);
            await db.SaveChangesAsync();

            return boardGame.Id;
        }

        public async Task<IEnumerable<BoardGameListingResponseModel>> ByUser(string userId)
            => await this.db
                .BoardGames
                .Where(bg => bg.UserId == userId)
                .Select(bg => new BoardGameListingResponseModel
                {
                    Id = bg.Id,
                    Name = bg.Name
                })
                .ToListAsync();

        public async Task<BoardGameDetailsResponseModel> Details(int id)
         => await this.db
            .BoardGames
            .Where(bg => bg.Id == id)
            .Select(bg => new BoardGameDetailsResponseModel
            {
                UserId = bg.UserId,
                Name = bg.Name,
                Description = bg.Description,
                MinPlayers = bg.MinPlayers,
                MaxPlayers = bg.MaxPlayers,
                MinPlayingTime = bg.MinPlayingTime,
                MaxPlayingTime = bg.MaxPlayingTime,
                AgeRating = bg.AgeRating,
                CategoryId = bg.CategoryId,
                Weight = bg.Weight
            })
            .FirstOrDefaultAsync();

        public async Task<bool> Update(int id, string name, string description, int minPlayers, 
            int maxPlayers, int minPlayingTime, int maxPlayingTime, AgeRating ageRating,
            double weight, bool isAvailable, int categoryId, string userId)
        {
            var boardGame = await this.GetByIdAndByUserId(id, userId);

            if (boardGame == null)
            {
                return false;
            }

            boardGame.Name = name;
            boardGame.Description = description;
            boardGame.MinPlayers = minPlayers;
            boardGame.MaxPlayers = maxPlayers;
            boardGame.MinPlayingTime = minPlayingTime;
            boardGame.MaxPlayingTime = maxPlayingTime;
            boardGame.AgeRating = ageRating;
            boardGame.IsAvailable = isAvailable;
            boardGame.Weight = weight;
            boardGame.CategoryId = categoryId;

            await this.db.SaveChangesAsync();

            return true;
            
        }

        private async Task<BoardGame> GetByIdAndByUserId(int id, string userId)
            => await this.db
                .BoardGames
                .Where(bg => bg.Id == id && bg.UserId == userId)
                .FirstOrDefaultAsync();
    }
}
