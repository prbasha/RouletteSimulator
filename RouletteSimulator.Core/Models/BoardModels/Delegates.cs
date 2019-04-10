using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Models.BoardModels
{
    public delegate void HighLightSplitBet(SplitBet splitBet);
    public delegate void ClearHighLightSplitBet(SplitBet splitBet);
    public delegate void HighLightStreetBet(StreetBet streetBet);
    public delegate void ClearHighLightStreetBet(StreetBet streetBet);
    public delegate void HighLightCornerBet(CornerBet cornerBet);
    public delegate void ClearHighLightCornerBet(CornerBet cornerBet);
    public delegate void HighLightDoubleStreetBet(DoubleStreetBet doubleStreetBet);
    public delegate void ClearHighLightDoubleStreetBet(DoubleStreetBet doubleStreetBet);
    public delegate void HighLightEvenOddBet(EvenOddBet evenOddBet);
    public delegate void ClearHighLightEvenOddBet(EvenOddBet evenOddBet);
    public delegate void HighLightRedBlackBet(RedBlackBet redBlackBet);
    public delegate void ClearHighLightRedBlackBet(RedBlackBet redBlackBet);
    public delegate void HighLightDozenBet(DozenBet dozenBet);
    public delegate void ClearHighLightDozenBet(DozenBet dozenBet);
    public delegate void HighLightColumnBet(ColumnBet columnBet);
    public delegate void ClearHighLightColumnBet(ColumnBet columnBet);
    public delegate void HighLightLowHighBet(LowHighBet columnBet);
    public delegate void ClearHighLightLowHighBet(LowHighBet columnBet);
}
