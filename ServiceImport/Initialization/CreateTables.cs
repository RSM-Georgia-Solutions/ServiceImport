using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace ServiceImport.Initialization
{
    class CreateTables : IRunnable
    {
        public void Run(DiManager diManager)
        {
            diManager.CreateTable("RSM_SERVICE_MAPPINGS", BoUTBTableType.bott_NoObjectAutoIncrement);
            diManager.CreateTable("RSM_SERVICE_CHILD_MAPPINGS", BoUTBTableType.bott_NoObjectAutoIncrement);
            diManager.CreateTable("RSM_SERVICE_SETTINGS", BoUTBTableType.bott_NoObjectAutoIncrement);
        }
    }
}
