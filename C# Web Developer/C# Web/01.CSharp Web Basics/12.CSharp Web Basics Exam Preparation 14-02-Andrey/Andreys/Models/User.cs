using System;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Models
{
    public class User
    {
        // TODO: Remove ID
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}