namespace BGRent.Server.Features.BoardGames
{
    using BGRent.Server.Data.Models;
    using BGRent.Server.Features.BoardGames.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IBoardGameService
    {
        public Task<int> Create(string name, string description, int minPlayers,
            int maxPlayers, int minPlayingTime, int maxPlayingTime, AgeRating ageRating,
            double weight, int categoryId, string userId);

        public Task<IEnumerable<BoardGameListingResponseModel>> ByUser(string userId);

        public Task<BoardGameDetailsResponseModel> Details(int id);
    }
}
