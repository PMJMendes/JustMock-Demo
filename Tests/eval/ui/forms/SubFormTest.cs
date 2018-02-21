using EvalApp.services.interfaces;
using EvalApp.ui.entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Telerik.JustMock;

namespace EvalApp.ui.forms
{
    [TestClass]
    public class SubFormTest : JustMockTestBase
    {
        private SubForm subject;
        IDummy dummy;

        [TestInitialize]
        public void SetUp()
        {
            dummy = Mock.Create<IDummy>();

            subject = new SubForm(dummy);
            subject.Model = new SubModel();
        }

        [TestMethod]
        public void EvalTestShowDialog()
        {
            Mock.Arrange(() => dummy.GetStuff()).Returns(new List<string> { "a", "b", "c" });

            subject.Model.Stuff = "b";

            FireDotNetEvent(subject, null, "Load", EventArgs.Empty);

            ComboBox.ObjectCollection items = (ComboBox.ObjectCollection)GetDotNetProperty(subject, "cbxStuff", "Items");
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("a", items[0]);
            Assert.AreEqual("b", items[1]);
            Assert.AreEqual("c", items[2]);

            Assert.AreEqual("b", (string)GetDotNetProperty(subject, "cbxStuff", "SelectedItem"));
        }

        [TestMethod]
        public void EvalTestOk()
        {
            Mock.Arrange(() => dummy.GetStuff()).Returns(new List<string> { "a", "b", "c" });

            subject.Model.Stuff = "b";

            FireDotNetEvent(subject, null, "Load", EventArgs.Empty);

            SetDotNetProperty(subject, "cbxStuff", "SelectedItem", "a");

            Mock.Arrange(() => subject.Close()).DoNothing().MustBeCalled();

            FireDotNetEvent(subject, "btnOk", "Click", EventArgs.Empty);

            Mock.Assert(subject);

            Assert.AreEqual("a", subject.Model.Stuff);
        }

        [TestMethod]
        public void EvalTestCancel()
        {
            Mock.Arrange(() => dummy.GetStuff()).Returns(new List<string> { "a", "b", "c" });

            subject.Model.Stuff = "b";

            FireDotNetEvent(subject, null, "Load", EventArgs.Empty);

            SetDotNetProperty(subject, "cbxStuff", "SelectedItem", "a");

            Mock.Arrange(() => subject.Close()).DoNothing().MustBeCalled();

            FireDotNetEvent(subject, "btnCancel", "Click", EventArgs.Empty);

            Mock.Assert(subject);

            Assert.AreEqual("b", subject.Model.Stuff);
        }
    }
}
