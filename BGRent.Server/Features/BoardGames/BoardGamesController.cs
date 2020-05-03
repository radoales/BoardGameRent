namespace BGRent.Server.Features.BoardGames
{
    using Features;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using System.Threading.Tasks;
    using static Infrastructure.Extensions.IdentityExtensions;

    [Authorize]
    public class BoardGamesController : ApiController
    {
        private readonly IBoardGameService boardGameService;

        public BoardGamesController(IBoardGameService boardGameService)
            => this.boardGameService = boardGameService;

        [HttpPost]
        [Route(nameof(Create))]
        public async Task<ActionResult> Create(CreateBoardGameRequestModel model)
        {
            var userId = this.User.GetUserId();

            var id = await boardGameService.Create(
                  model.Name,
                  model.Description,
                  model.MinPlayers,
                  model.MaxPlayers,
                  model.MinPlayingTime,
                  model.MaxPlayingTime,
                  model.AgeRating,
                  model.Weight,
                  model.CategoryId,
                  userId);

            return Created(nameof(Create), id);
        }


    }
}
