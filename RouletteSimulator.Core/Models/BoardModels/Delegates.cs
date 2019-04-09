using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    public delegate void HighLightSplitBet(SplitBet splitBet);
    public delegate void ClearHighLightSplitBet(SplitBet splitBet);
    public delegate void HighLightStreetBet(StreetBet StreetBet);
    public delegate void ClearHighLightStreetBet(StreetBet StreetBet);
    public delegate void HighLightCornerBet(CornerBet CornerBet);
    public delegate void ClearHighLightCornerBet(CornerBet CornerBet);
    public delegate void HighLightDoubleStreetBet(DoubleStreetBet DoubleStreetBet);
    public delegate void ClearHighLightDoubleStreetBet(DoubleStreetBet DoubleStreetBet);
}
