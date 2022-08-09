using MaterialQuality.Processing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialQuality.Processing.Evaluation;

public class StandardQualityEvaluation : IQualityEvaluation
{
    public void Evaluate(IEnumerable<MaterialBase> materials, Tolerances tolerances)
    {
        foreach (MaterialBase material in materials)
            material.EvaluateQuality(tolerances);
    }
}
