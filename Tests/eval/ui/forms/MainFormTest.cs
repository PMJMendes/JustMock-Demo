using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Telerik.JustMock;

namespace EvalApp.ui.forms
{
    [TestClass]
    public class MainFormTest : JustMockTestBase
    {
        private MainForm subject;

        [TestInitialize]
        public void SetUp()
        {
            subject = new MainForm();
        }

        [TestMethod]
        public void EvalTestShowDialog()
        {
            FireDotNetEvent(subject, null, "Load", EventArgs.Empty);
        }

        [TestMethod]
        public void EvalTestOk()
        {
            FireDotNetEvent(subject, null, "Load", EventArgs.Empty);

            Mock.Arrange(() => subject.Close()).DoNothing().MustBeCalled();

            FireDotNetEvent(subject, "btnOk", "Click", EventArgs.Empty);

            Mock.Assert(subject);
        }
    }
}
