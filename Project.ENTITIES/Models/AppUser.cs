using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid ActivationCode { get; set; } //Kullanıcıya üyelik onayı icin gönderilen unique bir sifreleme tipi (Guid)
        public bool Active { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }

        //Relational Properties
        public virtual AppUserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }

        public AppUser()
        {
            Role = UserRole.Member;
            ActivationCode = Guid.NewGuid();
        }


    }
}
