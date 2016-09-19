select AspNetUsers.Fname, AspNetUsers.Sname, AspNetRoles.Name from AspNetUsers,AspNetUserRoles, AspNetRoles
where AspNetUsers.Id = AspNetUserRoles.UserId and
AspNetUserRoles.RoleId  = AspNetRoles.Id and
AspNetRoles.Name = 'Student'