using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicApp.ui.views
{
    public interface IMainView
    {
        void ShowDialog();

        event EventHandler Ok;

        void Close();
    }
}
