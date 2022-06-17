using System;
using System.Collections.Generic;

namespace MaterialQuality.Processing.Entities
{
    public abstract class MaterialBase
    {
        public MaterialBase()
        {
            this.DefectCodes = new List<int>();
            this.QualityChecks = new List<QualityChecker>();
            AddQualityCheckers();
        }

        public void EvaluateQuality(Tolerances tolerances)
        {
            foreach(var checker in this.QualityChecks)
            {
                if (checker.Eval.Invoke(tolerances))
                    this.DefectCodes.Add(checker.DefectCode);
            }
        }
        
        internal abstract void AddQualityCheckers();
        internal List<QualityChecker> QualityChecks { get; set; }
        public List<int> DefectCodes { get; set; }
    }
}
