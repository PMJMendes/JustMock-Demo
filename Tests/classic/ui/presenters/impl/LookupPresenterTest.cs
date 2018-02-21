using ClassicApp.ui.entities;
using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ClassicApp.ui.presenters.impl
{
    [TestClass]
    public class LookupPresenterTest
    {
        [TestMethod]
        public void ClassicTestSearch()
        {
            var subPresenter = new Mock<ISubPresenter>(MockBehavior.Strict);
            var view = new Mock<ILookupView>(MockBehavior.Strict);

            view.Setup(v => v.SelectedStuff).Returns("a");
            subPresenter.SetupSet(sp => sp.Model = It.IsAny<SubModel>()).Callback<SubModel>(m => Assert.AreEqual("a", m.Stuff));
            subPresenter.Setup(sp => sp.ShowDialog());
            subPresenter.Setup(sp => sp.Model).Returns(new SubModel { Stuff = "b" });
            view.SetupSet(v => v.SelectedStuff = "b");

            ILookupPresenter subject = new LookupPresenterImpl(() => subPresenter.Object);
            subject.View = view.Object;

            view.Raise(v => v.Search += null, EventArgs.Empty);

            subPresenter.VerifyAll();
            view.VerifyAll();
        }
    }
}
