using BGRent.Server.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BGRent.Server.Features.BoardGames.Models
{
    public class BoardGameDetailsResponseModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public int MinPlayers { get; set; }
        
        public int MaxPlayers { get; set; }
      
        public int MinPlayingTime { get; set; }
        
        public int MaxPlayingTime { get; set; }        
        public AgeRating AgeRating { get; set; }
       
        public double Weight { get; set; }
        
        public int CategoryId { get; set; }
    }
}
