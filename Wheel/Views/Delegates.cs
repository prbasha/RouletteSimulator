using RouletteSimulator.Core.Models.WheelModels;

namespace Wheel.Views
{
    public delegate void WheelSpinning(bool wheelSpinning);
    public delegate void BallTossed(bool ballTossed);
    public delegate void WinningNumber(Pocket winningNumber);
}
