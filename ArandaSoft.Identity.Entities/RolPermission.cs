using System;

namespace ArandaSoft.Identity.Entities
{
    public class RolPermission
    {
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
