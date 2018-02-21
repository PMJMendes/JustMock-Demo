using EvalApp.services.impl;
using EvalApp.services.interfaces;
using Ninject.Modules;

namespace EvalApp
{
    class ClassicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDummy>().To<DummyImpl>();
        }
    }
}
