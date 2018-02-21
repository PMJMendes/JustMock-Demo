using System;
using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using ClassicApp.ui.entities;
using Ninject;

namespace ClassicApp.ui.presenters.impl
{
    public class LookupPresenterImpl : ILookupPresenter
    {
        private readonly Func<ISubPresenter> subPresenterFactory;
        private ILookupView view;

        [Inject]
        public LookupPresenterImpl(Func<ISubPresenter> presenterFactory)
        {
            this.subPresenterFactory = presenterFactory;
        }

        private void View_Search(object sender, EventArgs e)
        {
            var subPresenter = subPresenterFactory();
            subPresenter.Model = new SubModel
            {
                Stuff = view.SelectedStuff
            };

            subPresenter.ShowDialog();

            view.SelectedStuff = subPresenter.Model.Stuff;
        }

        ILookupView ILookupPresenter.View
        {
            set
            {
                view = value;
                view.Search += View_Search;
            }
        }
    }
}
