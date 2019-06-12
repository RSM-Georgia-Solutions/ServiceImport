using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using SAPbouiCOM.Framework;
using ServiceImport.Controllers;
using ServiceImport.Helpers;

namespace ServiceImport
{
    [FormAttribute("ServiceImport.ServiceImport", "Forms/ServiceImport.b1f")]
    class ServiceImport : UserFormBase
    {
        public ServiceImport()
        {
        }

        ExcelFileController excelFileController = new ExcelFileController();


        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_3").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_4").Specific));
            this.Button0.PressedAfter += new SAPbouiCOM._IButtonEvents_PressedAfterEventHandler(this.Button0_PressedAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_5").Specific));
            this.PictureBox0 = ((SAPbouiCOM.PictureBox)(this.GetItem("Item_6").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Media\\Sap.bmp";
            PictureBox0.Picture = path;
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.PictureBox PictureBox0;

        private void Button0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            ShowFolder newFolder = new ShowFolder();
            //add function to event 
            newFolder.currFunc += addPath1;
            //run method of folder class
            newFolder.loadFolder();

        }
        private void addPath1(string value)
        {
            EditText0.Value = value;

            if (value != "")
            {
                var sheetNames = excelFileController.ToExcelsSheetList(EditText0.Value);
                Others.SetSheetNames(sheetNames, ComboBox0);
            }
        }
    }
}