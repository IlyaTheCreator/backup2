using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SpotifyAppApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(2)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        public string Password { get; set; }

        public string PlaylistIds { get; set; }

        public string LikedTracksIds { get; set; }
    }
}
