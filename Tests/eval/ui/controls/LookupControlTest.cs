using EvalApp.ui.entities;
using EvalApp.ui.forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Telerik.JustMock;

namespace EvalApp.ui.controls
{
    [TestClass]
    public class LookupControlTest : JustMockTestBase
    {
        private LookupControl subject;
        private SubForm subForm;

        [TestInitialize]
        public void SetUp()
        {
            subForm = Mock.Create<SubForm>(Behavior.Strict);

            subject = new LookupControl();
            subject.SubFormFactory = () => subForm;
        }

        [TestMethod]
        public void EvalTestSearch()
        {
            SubModel model = null;

            SetDotNetProperty(subject, "txtDisplay", "Text", "b");

            Mock.ArrangeSet(() => subForm.Model = Arg.IsAny<SubModel>()).DoInstead((SubModel m) =>
            {
                model = m;
                Assert.AreEqual("b", model.Stuff);
            });
            Mock.Arrange(() => subForm.ShowDialog()).DoInstead(() => {
                model.Stuff = "a";
            }).Returns(DialogResult.OK);
            Mock.Arrange(() => subForm.Model).Returns(() => model);

            FireDotNetEvent(subject, "btnSearch", "Click", EventArgs.Empty);

            Assert.AreEqual("a", GetDotNetProperty(subject, "txtDisplay", "Text"));
        }
    }
}
