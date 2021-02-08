using System;
using System.Collections.Generic;

namespace ArandaSoft.Identity.Entities
{
    public class Rol
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public virtual ICollection<RolPermission> RolPermissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
