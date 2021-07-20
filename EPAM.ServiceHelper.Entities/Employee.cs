using System;

namespace EPAM.ServiceHelper.Entities
{
    [Flags]
    public enum Permissions
    {
        none =          0b_0000,
        view =          0b_0001,
        editOrder =     0b_0011,
        editRoll=       0b_0101,
        addEmployee =   0b_1001,
        admin =         0b_1111
    }
    public class Employee : Person
    {
        private Permissions _permissions;

        public Permissions Permissions { get => _permissions; }

        public Employee(int id, string name, string phonNumber, string comment, Permissions perm) : base(id, name, phonNumber, comment)
        {
            _permissions = perm;
        }


        public bool HasPermissions(Permissions permissions)
        {        
            return Permissions.HasFlag(permissions);
        }
        public void SetPermissions(Permissions permissions)
        {
            _permissions = Permissions | permissions;
        }

        public void RemovePermissions(Permissions permissions)
        {
            _permissions = Permissions ^ permissions;
        }

    }
}
