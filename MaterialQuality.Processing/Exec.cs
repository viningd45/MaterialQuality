using MaterialQuality.Processing.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialQuality.Processing
{
    public class Exec
    {
        public static void Ex()
        {
            Tube tube = new Tube();

            Tolerances tolerances = new Tolerances();

            foreach (var t in tube.QualityChecks)
                t.Invoke(tolerances);
        }
    }
}
