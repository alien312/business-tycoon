using System;
using System.IO;
using Source.Handlers;
using UnityEngine;

namespace Source.Data
{
    public class SaveLoadHandler : IPause, IQuit
    {
        const string Format = ".json";
        
        string rootpath;
        
        string RootPath
        {
            get
            {
                if (rootpath == null)
                {
                    rootpath = Application.isEditor ? "Assets/Data/Saves/" : Application.persistentDataPath;
                }

                return rootpath;
            }
        }
        
        private SessionData _data;

        public SaveLoadHandler(SessionData sessionData)
        {
            _data = sessionData;
            
            _data.StateData = LoadData();
        }

        private SessionStateData LoadData()
        {
            var path = Path.Combine(RootPath, nameof(SessionStateData) + Format);
            if (File.Exists(path))
            {
                try
                {
                    var json = File.ReadAllText(Path.Combine(RootPath, nameof(SessionStateData) + Format));
                    var result = JsonUtility.FromJson<SessionStateData>(json);
                    _data.HasSessionStateData = true;
                    return result;
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                    return null;
                }
            }

            return null;
        }

        private void Save(SessionStateData data)
        {
            if (data == null) throw new NullReferenceException("save-object is null");
            
            try
            {
                var json = JsonUtility.ToJson(data);
                File.WriteAllText(Path.Combine(RootPath, nameof(SessionStateData) + Format), json);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        public void Pause(bool pause)
        {
            if (pause)
            {
                Save(_data.StateData);
            }
        }

        public void Quit()
        {
            Save(_data.StateData);
        }
    }
}