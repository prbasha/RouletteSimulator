using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.Enumerations
{
    /// <summary>
    /// The BetType enumeration represents the type of bet.
    /// </summary>
    public enum BetType
    {
        Straight,
        Split,
        Street,
        Corner,
        DoubleStreet,
        FirstFour,
        FirstColumn,
        SecondColumn,
        ThirdColumn,
        FirstDozen,
        SecondDozen,
        ThirdDozen,
        Low,
        High,
        Even,
        Odd,
        Red,
        Black
    }
}
