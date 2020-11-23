using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpotifyAppApi.Models;

namespace SpotifyAppApi.Data
{
    public interface ISpotifyAppApiRepository
    {
        bool SaveChanges();
        User GetUserById(int id);
        void Register(User user);
        void UpdateUser(User user);
        User Authorize(string username, string password);
    }
}
