using System.Collections;
using System.Collections.Generic;
using BGRent.Server.Data.Models;
using BGRent.Server.Features.BoardGames.Models;

namespace BGRent.Server.Features.BoardGames
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    public interface IBoardGameService
    {
        public Task<int> Create(string name, string description, int minPlayers, 
            int maxPlayers, int minPlayingTime, int maxPlayingTime, AgeRating ageRating,
            double weight, int categoryId, string userId);

        public Task<IEnumerable<BoardGameListingResponseModel>> ByUser(string userId);
    }
}
