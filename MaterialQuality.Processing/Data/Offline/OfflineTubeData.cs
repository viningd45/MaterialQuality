using MaterialQuality.Processing.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialQuality.Processing.Data.Offline;

public class OfflineTubeData : IMaterialData<Tube>
{
    private List<Tube> _data;

    public OfflineTubeData()
    {
        _data = new List<Tube>();
    }

    public void AddMaterial(Tube material)
    {
        _data.Add(material);
    }

    public IEnumerable<Tube> GetMaterial()
    {
        return _data;
    }

    public Tube GetMaterial(int id)
    {
        return _data.Where(ent => ent.Id == id).FirstOrDefault();
    }

    public void RemoveMaterial(int id)
    {
        int index = _data.FindIndex(ent => ent.Id == id); ;
        _data.RemoveAt(index);
    }
}
