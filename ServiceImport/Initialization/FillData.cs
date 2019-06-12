using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;

namespace ServiceImport.Initialization
{
    class FillData : IRunnable
    {
        public void Run(DiManager diManager)
        {
            DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte($"SELECT * FROM [@RSM_SERVICE_MAPPINGS]"));
            Recordset recSet = (Recordset)DiManager.Company.GetBusinessObject(BoObjectTypes.BoRecordset);
            if (DiManager.Recordset.EoF)
            {
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'თარიღი')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'დანახარჯთა ცენტრი (თანამშრომელი)')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'ფილიალი')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'დარიცხული ხელფასი')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'საშემოსავლო გადასახადი')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'სხვა დაქვითვა')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'საპენსიო შენატანი (თანამშრომელი)')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'საპენსიო შენატანი (კომპანია)')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'დაზღვევა (თანამშრომელი)')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'დაზღვევა (კომპანია)')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'ბონუსი')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'პრემია')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'ღამისთევის')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'დაქვითვა')"));
                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte("INSERT INTO [@RSM_SERVICE_MAPPINGS] (U_SAP_FIELD) VALUES(N'დანახარჯთა ცენტრი (ფილიალი)')"));


                DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte($"SELECT * FROM [@RSM_SERVICE_CHILD_MAPPINGS]"));
                if (DiManager.Recordset.EoF)
                {
                    DiManager.Recordset.DoQuery(DiManager.QueryHanaTransalte($"SELECT * FROM [@RSM_SERVICE_MAPPINGS]"));
                    while (!DiManager.Recordset.EoF)
                    {
                        string parentId = DiManager.Recordset.Fields.Item("Code").Value.ToString();
                        recSet.DoQuery(DiManager.QueryHanaTransalte($"INSERT INTO [@RSM_SERVICE_CHILD_MAPPINGS] (U_PARENT_ID) VALUES (N'{parentId}')"));
                        DiManager.Recordset.MoveNext();
                    }
                }

            }
        }
    }
}
