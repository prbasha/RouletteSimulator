using Prism.Mvvm;

namespace RouletteSimulator.ViewModels
{
    public class RouletteSimulatorViewModel : BindableBase
    {
        private string _title = "Roulette Simulator";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public RouletteSimulatorViewModel()
        {

        }
    }
}
