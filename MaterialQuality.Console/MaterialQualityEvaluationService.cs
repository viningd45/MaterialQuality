using MaterialQuality.Processing.Data;
using MaterialQuality.Processing.Entities;
using MaterialQuality.Processing.Evaluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialQuality.Console;

public class MaterialQualityEvaluationService
{
    private IQualityEvaluation _qualityEvaluation;
    private IMaterialData<Tube> _materialData;
    public MaterialQualityEvaluationService(IQualityEvaluation qualityEvaluation, IMaterialData<Tube> materialData)
    {
        _qualityEvaluation = qualityEvaluation;
        _materialData = materialData;
    }

    public void OfflineSetup()
    {
        _materialData.AddMaterial(new Tube() { Id = 1, Length = 5000, OuterDiameter = 124.2, WallThickness = 5.5 });
        _materialData.AddMaterial(new Tube() { Id = 2, Length = 3500, OuterDiameter = 125.4, WallThickness = 5.5 });
        _materialData.AddMaterial(new Tube() { Id = 3, Length = 5000, OuterDiameter = 122.8, WallThickness = 5.5 });
        _materialData.AddMaterial(new Tube() { Id = 4, Length = 5000, OuterDiameter = 129.2, WallThickness = 5.5 });
        _materialData.AddMaterial(new Tube() { Id = 5, Length = 5000, OuterDiameter = 124.5, WallThickness = 5.5 });
    }

    public void RunQualityEvaluation(Tolerances tolerances)
    {
        IEnumerable<Tube> materials = _materialData.GetMaterial();
        _qualityEvaluation.Evaluate(materials, tolerances);

        foreach(var material in materials)
        {
            System.Console.WriteLine($"Material ID: {material.Id}");
            if(material.DefectCodes.Count > 0)
            {
                System.Console.WriteLine("Material has defects detected");
                material.DefectCodes.ForEach(code => System.Console.WriteLine(code));
                continue;
            }

            System.Console.WriteLine("Material has no defects detected");
        }
    }
}
