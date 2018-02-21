using ClassicApp.ui.entities;

namespace ClassicApp.ui.presenters.interfaces
{
    public interface ISubPresenter
    {
        SubModel Model { get; set; }

        void ShowDialog();
    }
}
