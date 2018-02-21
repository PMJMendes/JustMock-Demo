using ClassicApp.services.interfaces;
using ClassicApp.ui.entities;
using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace ClassicApp.ui.presenters.impl
{
    [TestClass]
    public class SubPresenterTest
    {
         [TestMethod]
        public void ClassicTestShowDialog()
        {
            var dummy = new Mock<IDummy>(MockBehavior.Strict);
            var view = new Mock<ISubView>(MockBehavior.Strict);

            dummy.Setup(d => d.GetStuff()).Returns(new List<string> { "a", "b", "c" });
            view.SetupSet(v => v.Stuff = new List<string> { "a", "b", "c" });
            view.SetupSet(v => v.SelectedStuff = "b");
            view.Setup(v => v.ShowDialog());

            ISubPresenter subject = new SubPresenterImpl(dummy.Object, view.Object);
            subject.Model = new SubModel { Stuff = "b" };

            subject.ShowDialog();

            dummy.VerifyAll();
            view.VerifyAll();
        }

        [TestMethod]
        public void ClassicTestOk()
        {
            var dummy = new Mock<IDummy>(MockBehavior.Strict);
            var view = new Mock<ISubView>(MockBehavior.Strict);

            view.Setup(v => v.SelectedStuff).Returns("a");
            view.Setup(v => v.Close());

            ISubPresenter subject = new SubPresenterImpl(dummy.Object, view.Object);
            subject.Model = new SubModel();

            view.Raise(v => v.Ok += null, EventArgs.Empty);

            Assert.AreEqual("a", subject.Model.Stuff);

            dummy.VerifyAll();
            view.VerifyAll();
        }

        [TestMethod]
        public void ClassicTestCancel()
        {
            var dummy = new Mock<IDummy>(MockBehavior.Strict);
            var view = new Mock<ISubView>(MockBehavior.Strict);

            view.Setup(v => v.Close());

            ISubPresenter subject = new SubPresenterImpl(dummy.Object, view.Object);

            view.Raise(v => v.Cancel += null, EventArgs.Empty);

            dummy.VerifyAll();
            view.VerifyAll();
        }
    }
}
