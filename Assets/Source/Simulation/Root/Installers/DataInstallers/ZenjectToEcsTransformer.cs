using System.Linq;
using NanoEcs;
using Zenject;

namespace Source.Simulation.Root.Installers.DataInstallers
{
    public class ZenjectToEcsTransporting : IInitializable, ITickable, IFixedTickable, System.IDisposable
    {
        [Inject] InstallSettings installSettings;
        NanoEcs.Systems systems;
    
        public void Initialize()
        {
            systems = new NanoEcs.Systems(installSettings.Container().TryResolve(typeof(Contexts)) as IContext);

            var systemTypes = typeof(ISystem).GetChildTypes();

            systemTypes.Select(x => installSettings.Container().TryResolve(x) as SystemEcs)
                .Where(x => x != null)
                .OrderBy(x => GetInfo(x, installSettings).OrderIndex)
                .ToList()
                .ForEach(x => systems.Add(x));

            systems.Initialize();

            SystemInstallInfo GetInfo(SystemEcs x, InstallSettings installInfo)
            {
                return installInfo.SystemInstallInfos.Find(info => info.SystemType == x.GetType());
            }
        }

        public void Tick()
        {
            systems.Execute();
        }

        public void FixedTick()
        {
            systems.FixedExecute();
        }

        public void Dispose()
        {
            systems?.Stop();
        }
    }
}