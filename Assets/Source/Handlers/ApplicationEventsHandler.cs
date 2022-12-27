using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Source.Handlers
{
    public class ApplicationEventsHandler : MonoBehaviour
    {
        [Inject] List<IPause> pauseObjects;
        [Inject] List<IQuit> quitObjects;
        
        
        private void OnApplicationPause(bool pauseStatus)
        {
            foreach (var pauseObject in pauseObjects)
            {
                pauseObject.Pause(pauseStatus);
            }
        }

        private void OnApplicationQuit()
        {
            foreach (var quitObject in quitObjects)
            {
                quitObject.Quit();
            }
        }
    }
    
    public interface IPause
    {
        void Pause(bool pause); 
    }
    public interface IQuit
    {
        void Quit();
    }
}