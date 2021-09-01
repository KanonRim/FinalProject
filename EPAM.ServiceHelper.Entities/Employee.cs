using System;

namespace EPAM.ServiceHelper.Entities
{
    [Flags]
    public enum Permissions
    {
        none =          0b_0000, // nice binary literal, but enum values should be in PascalCase
        view =          0b_0001,
        editOrder =     0b_0011,
        editRoll=       0b_0101, // if you want to combine flags, make standalone flags first - you will be able to combine them here like `View | EditOrders` and will be able to add/subtract them in code
        addEmployee =   0b_1001,
        admin =         0b_1111 // if you `RemovePermissions` EditRoll from admin, he'll be left with permission mask "1010", meaning he is able to add employees and edit orders, but isn't able to view anything
    }
    public class Employee : Person
    {
        public Permissions Permissions { get; private set; } // practically the same, but takes less place

        public Employee(int id, string name, string phonNumber, string comment, Permissions perm) : base(id, name, phonNumber, comment)
        {
            Permissions = perm;
        }


        public bool HasPermissions(Permissions permissions)
        {        
            return Permissions.HasFlag(permissions);
        }
        public void SetPermissions(Permissions permissions)
        {
            Permissions |= permissions; // a compound operator like += etc, but for binary
        }

        public void RemovePermissions(Permissions permissions)
        {
            Permissions = Permissions ^ permissions;
        }

    }
}
