using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using Ninject;
using System;

namespace ClassicApp.ui.presenters.impl
{
    public class MainPresenterImpl : IMainPresenter
    {
        private readonly IMainView view;

        [Inject]
        public MainPresenterImpl(IMainView view)
        {
            this.view = view;
            view.Ok += View_Ok;
        }

        private void View_Ok(object sender, EventArgs e)
        {
            view.Close();
        }

        void IMainPresenter.ShowDialog()
        {
            view.ShowDialog();
        }
    }
}
