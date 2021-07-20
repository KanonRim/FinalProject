using System;
using System.Collections.Generic;
using System.Web.Security;
using EPAM.ServiceHelper.Entities;
using EPAM.ServiceHelper.InterfaceBLL;

public class ServiceRoleProvider : RoleProvider
{
    IBLL logic = DependencyResolver.Instance.Logic;


    [Flags]
    enum Roll 
    {
        none = Permissions.none,
        user = Permissions.editOrder,
        admin = Permissions.editOrder | Permissions.addEmployee,
        owner = Permissions.admin

    }
    public override string[] GetRolesForUser(string username)
    {
        var user = logic.GetEmployeeByName(username);

        List<string> roll = new List<string>();
        foreach (var item in Enum.GetValues(typeof(Roll)))
        {
            if (user.Permissions.HasFlag((Permissions)item))
            {
                roll.Add(((Roll)item).ToString());
            }
        }
        return roll.ToArray();
    }

    public override bool IsUserInRole(string username, string roleName)
    {
        var user = logic.GetEmployeeByName(username);
        var roll = Enum.Parse(typeof(Roll), roleName);
        return user.HasPermissions((Permissions)roll);
               
       
    }

    public override string[] GetUsersInRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override void CreateRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
        throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
        throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
        throw new NotImplementedException();
    }





    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
        throw new NotImplementedException();
    }
}
