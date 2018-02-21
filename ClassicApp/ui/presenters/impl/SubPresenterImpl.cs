using ClassicApp.services.interfaces;
using ClassicApp.ui.entities;
using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using Ninject;
using System;

namespace ClassicApp.ui.presenters.impl
{
    public class SubPresenterImpl : ISubPresenter
    {
        private readonly IDummy dummy;
        private readonly ISubView view;

        [Inject]
        public SubPresenterImpl(IDummy dummy, ISubView view)
        {
            this.dummy = dummy;

            this.view = view;
            view.Ok += View_Ok;
            view.Cancel += View_Cancel;
        }

        private void View_Ok(object sender, EventArgs e)
        {
            ((ISubPresenter)this).Model.Stuff = view.SelectedStuff;
            view.Close();
        }

        private void View_Cancel(object sender, EventArgs e)
        {
            view.Close();
        }

        SubModel ISubPresenter.Model { get; set; }

        void ISubPresenter.ShowDialog()
        {
            view.Stuff = dummy.GetStuff();
            view.SelectedStuff = ((ISubPresenter)this).Model.Stuff;

            view.ShowDialog();
        }
    }
}
