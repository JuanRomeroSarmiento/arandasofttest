using System;
using System.Collections.Generic;

namespace ArandaSoft.Identity.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RolPermission> RolPermissions { get; set; }
    }
}
