using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace ServiceImport.Initialization
{
    class CreateFields : IRunnable
    {
        public void Run(DiManager diManager)
        {
            diManager.AddField("RSM_SERVICE_MAPPINGS", "SAP_FIELD", "SAP Field", BoFieldTypes.db_Alpha, 250, false);
            diManager.AddField("RSM_SERVICE_MAPPINGS", "EXCEL_COLUMN", "Excel Column", BoFieldTypes.db_Alpha, 250, false);

            diManager.AddField("RSM_SERVICE_CHILD_MAPPINGS", "DEBIT_ACCOUNT", "Debit Account", BoFieldTypes.db_Alpha, 250, false);
            diManager.AddField("RSM_SERVICE_CHILD_MAPPINGS", "CREDIT_ACCOUNT", "Credit Account", BoFieldTypes.db_Alpha, 250, false);
            diManager.AddField("RSM_SERVICE_CHILD_MAPPINGS", "PARENT_ID", "RSM_SERVICE_MAPPINGS Codet", BoFieldTypes.db_Alpha, 250, false);
            diManager.AddField("RSM_SERVICE_CHILD_MAPPINGS", "CREDIT_CONTROL_ACCOUNT", "Credit Account", BoFieldTypes.db_Alpha, 250, false);
            diManager.AddField("RSM_SERVICE_CHILD_MAPPINGS", "DEBIT_CONTROL_ACCOUNT", "Debit Account", BoFieldTypes.db_Alpha, 250, false);
        }
    }
}
