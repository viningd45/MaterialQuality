using System;
using System.Collections.Generic;

namespace MaterialQuality.Processing.Entities
{
    public abstract class QualityCheckBase
    {
        public QualityCheckBase()
        {
            DefectCodes = new List<int>();
            QualityChecks = new List<Action<Tolerances>>();
            AddQualityChecks();
        }
        internal abstract void AddQualityChecks();
        public List<int> DefectCodes { get; set; }
        internal List<Action<Tolerances>> QualityChecks { get; set; }
    }
}
