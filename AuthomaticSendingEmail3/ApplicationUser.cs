using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace NemeTschek.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        //  public int Id { get; set; }
        public ICollection<Event> Events { get => events; set => events = value; }

        public ICollection<Event> events;

    }
}
