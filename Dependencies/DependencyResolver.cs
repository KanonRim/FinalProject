using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.ServiceHelper.InterfaceDAO;
using EPAM.ServiceHelper.InterfaceBLL;
using EPAM.ServiceHelper.BLL;
using EPAM.ServiceHelper.DAO;

namespace EPAM.ServiceHelper.Entities
{

    public class DependencyResolver
    {
        #region SINGLETONE

        private static DependencyResolver _instance;
        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    return _instance = new DependencyResolver();
                else
                    return _instance;
            }
        }

        #endregion

        public IDAO DAO => new DAOSQL();

        public IBLL Logic => new ServiceHelperBLL(DAO);

    }
} 
