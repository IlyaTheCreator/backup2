using SpotifyAppApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyAppApi.Data
{
    public class SqlSpotifyAppApiRepository : ISpotifyAppApiRepository
    {
        private readonly SpotifyAppApiContext _context;

        public SqlSpotifyAppApiRepository(SpotifyAppApiContext context)
        {
            _context = context;
        }

        public User Authorize(string username, string password)
        {
            return _context.Users.FirstOrDefault(user => user.Username == username && user.Password == password);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(user => user.Id == id);
        }

        public void Register(User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _context.Users.Add(user);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void UpdateUser(User user)
        {
            // nothing
        }
    }
}
