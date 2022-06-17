using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialQuality.Processing.Entities
{
    public class Tolerances
    {
        public double OuterDiameterMax { get; set; }
        public double OuterDiameterMin { get; set; }
        public double WallThicknessMax { get; set; }
        public double WallThicknessMin { get; set; }
        public double LengthMax { get; set; }
        public double LengthMin { get; set; }
    }
}
