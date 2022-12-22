using System.Collections.Generic;
using Zenject;

namespace Source.Simulation.Root.Installers.DataInstallers
{
    public class InstallSettings 
    {
        public System.Func<DiContainer> Container;
        public List<SystemInstallInfo> SystemInstallInfos = new List<SystemInstallInfo>();
        int currentOrderIndex;

        public void Add<T>(object[] args)
        {
            SystemInstallInfos.Add(new SystemInstallInfo()
            {
                OrderIndex = currentOrderIndex++,
                SystemType = typeof(T),
                OptionalArguments = args
            });
        }
    }
}