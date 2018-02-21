using System;
using System.Collections.Generic;

namespace ClassicApp.ui.views
{
    public interface ISubView
    {
        List<string> Stuff { set; }
        string SelectedStuff { get; set; }

        void ShowDialog();

        event EventHandler Ok;
        event EventHandler Cancel;

        void Close();
    }
}
