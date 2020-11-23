using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpotifyAppApi.Dtos
{
    public class UserReadDto
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
