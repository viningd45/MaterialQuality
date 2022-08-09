using MaterialQuality.Processing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialQuality.Processing.Data;

public interface ITolerancesData
{
    Tolerances GetTolerances();
}
