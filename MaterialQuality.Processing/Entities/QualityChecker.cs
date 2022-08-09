using System;
using System.Collections.Generic;
using System.Text;

namespace MaterialQuality.Processing.Entities;

public class QualityChecker
{
    public QualityChecker()
    {
    }

    public QualityChecker(int defectCode, Func<Tolerances, bool> eval)
    {
        this.DefectCode = defectCode;
        this.Eval = eval;
    }

    public int DefectCode { get; set; }
    public Func<Tolerances, bool> Eval { get; set; }
}
