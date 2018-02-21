using ClassicApp.services.impl;
using ClassicApp.services.interfaces;
using ClassicApp.ui.controls;
using ClassicApp.ui.forms;
using ClassicApp.ui.presenters.impl;
using ClassicApp.ui.presenters.interfaces;
using ClassicApp.ui.views;
using Ninject.Modules;

namespace ClassicApp
{
    class ClassicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDummy>().To<DummyImpl>();

            Bind<IMainPresenter>().To<MainPresenterImpl>();
            Bind<IMainView>().To<MainForm>();

            Bind<ISubPresenter>().To<SubPresenterImpl>();
            Bind<ISubView>().To<SubForm>();

            Bind<ILookupPresenter>().To<LookupPresenterImpl>();
            Bind<ILookupView>().To<LookupControl>();
        }
    }
}
