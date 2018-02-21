using ClassicApp.services.interfaces;
using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace ClassicApp.ui.presenters.impl
{
    [TestClass]
    public class MainPresenterTest
    {
        [TestMethod]
        public void ClassicTestShowDialog()
        {
            var view = new Mock<IMainView>(MockBehavior.Strict);

            view.Setup(v => v.ShowDialog());

            IMainPresenter subject = new MainPresenterImpl(view.Object);

            subject.ShowDialog();

            view.VerifyAll();
        }

        [TestMethod]
        public void ClassicTestOk()
        {
            var view = new Mock<IMainView>(MockBehavior.Strict);

            view.Setup(v => v.Close());

            IMainPresenter subject = new MainPresenterImpl(view.Object);

            view.Raise(v => v.Ok += null, EventArgs.Empty);

            view.VerifyAll();
        }
    }
}
