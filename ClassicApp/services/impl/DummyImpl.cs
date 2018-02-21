using ClassicApp.services.interfaces;
using System.Collections.Generic;

namespace ClassicApp.services.impl
{
    public class DummyImpl : IDummy
    {
        List<string> IDummy.GetStuff()
        {
            return new List<string> { "ABC", "DEF" };
        }
    }
}
