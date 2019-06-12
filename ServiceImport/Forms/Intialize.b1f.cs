using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SAPbouiCOM.Framework;
using ServiceImport.Initialization;
using ServiceImport;

namespace ServiceImport.Forms
{
    [FormAttribute("ServiceImport.Forms.Intialize", "Forms/Intialize.b1f")]
    class Intialize : UserFormBase
    {
        public Intialize()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.PictureBox0 = ((SAPbouiCOM.PictureBox)(this.GetItem("Item_0").Specific));
            this.PictureBox0.PressedAfter += new SAPbouiCOM._IPictureBoxEvents_PressedAfterEventHandler(this.PictureBox0_PressedAfter);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.PictureBox PictureBox0;

        private void OnCustomInitialize()
        {
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Media\\c9.bmp";
            PictureBox0.Picture = path;
        }

        private void PictureBox0_PressedAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            DiManager diManager = new DiManager();
            Initial init = new Initial();
            init.Run(diManager);
        }
    }
}
