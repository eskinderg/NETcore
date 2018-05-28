using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectAPI.Services
{
    public interface IMovieService
    {
        Task <List<MovieViewModel>> GetPopular();
    }
}
