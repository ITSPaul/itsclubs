Insert into AspNetUserRoles(UserID, RoleID)
select Id, 'db0fa761-98f5-4b16-90fe-ddff6fdbba46' from AspNetUsers 
where Id not in (Select UserId from AspNetUserRoles)