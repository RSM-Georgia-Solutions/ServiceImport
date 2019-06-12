using ServiceImport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImport.Initialization
{
    interface IRunnable
    {
        void Run(DiManager diManager);
    }
}
