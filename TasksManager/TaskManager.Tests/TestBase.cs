using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Tests
{
    public class TestBase
    {
        public TestContext TestContext { get; set; }
        protected string goodFileName;

        protected void SetGoodFileName()
        {
            goodFileName = TestContext.Properties["GoodFileName"].ToString();
            if (goodFileName.Contains("[AppPath]"))
            {
                goodFileName = goodFileName.Replace("[AppPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
        }
    }
}
