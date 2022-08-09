using MaterialQuality.Processing.Entities;
using System.Collections.Generic;

namespace MaterialQuality.Processing.Evaluation;

public interface IQualityEvaluation
{
    void Evaluate(IEnumerable<MaterialBase> materials, Tolerances tolerances);
}
