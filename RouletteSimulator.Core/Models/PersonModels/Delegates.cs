using RouletteSimulator.Core.Enumerations;

namespace RouletteSimulator.Core.Models.PersonModels
{
    public delegate void ChipSelected(ChipType selectedChip);
    public delegate void ClearBets();
    public delegate void SpinWheel();
    public delegate void TossBall();
    public delegate void PlaceBets(bool placeBets);
}
