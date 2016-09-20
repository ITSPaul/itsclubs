Delete from AspNetUserRoles where 
AspNetUserRoles.UserId in
(select AspNetUsers.Id from AspNetUsers,AspNetUserRoles, AspNetRoles
where AspNetUsers.Id = AspNetUserRoles.UserId and
AspNetUserRoles.RoleId  = AspNetRoles.Id and
AspNetRoles.Name = 'Student' and
AspNetUsers.UserName = 'colinfeehilysrfc@hotmail.com')