using MaterialQuality.Console;
using MaterialQuality.Processing.Data;
using MaterialQuality.Processing.Data.Offline;
using MaterialQuality.Processing.Entities;
using MaterialQuality.Processing.Evaluation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IMaterialData<Tube>, OfflineTubeData>()
                .AddTransient<IQualityEvaluation, StandardQualityEvaluation>()
                .AddSingleton<MaterialQualityEvaluationService>())
    .Build();

Exec(host.Services);

static void Exec(IServiceProvider provider) 
{
    MaterialQualityEvaluationService service = provider.GetRequiredService<MaterialQualityEvaluationService>();
    service.OfflineSetup();

    Tolerances tolerances = new()
    {
        LengthMax = 5500,
        LengthMin = 4500,
        WallThicknessMax = 6,
        WallThicknessMin = 5,
        OuterDiameterMax = 126,
        OuterDiameterMin = 124
    };

    service.RunQualityEvaluation(tolerances);
}

