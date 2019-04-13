using Prism.Events;
using RouletteSimulator.Core.Enumerations;
using RouletteSimulator.Core.Models.ChipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteSimulator.Core.EventsAggregator
{
    /// <summary>
    /// The SelectedChipEvent class represents a selected chip event.
    /// </summary>
    public class SelectedChipEvent : PubSubEvent<ChipType> { }
}
