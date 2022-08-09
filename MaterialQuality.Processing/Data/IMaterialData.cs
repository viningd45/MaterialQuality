using MaterialQuality.Processing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialQuality.Processing.Data;

public interface IMaterialData<T> where T: MaterialBase
{
    IEnumerable<T> GetMaterial();
    T GetMaterial(int id);
    void AddMaterial(T material);
    void RemoveMaterial(int id);
}
