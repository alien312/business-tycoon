using System;
using System.Collections.Generic;

namespace Source.Data
{
    [Serializable]
    public class SessionData
    {
        public SessionStateData StateData;

        public bool HasSessionStateData;
    }
    
    [Serializable]
    public class SessionStateData
    {
        public float PlayerBalance;
        public List<Business> Businesses = new List<Business>();
        public List<Modifier> Modifiers = new List<Modifier>();
    }

    [Serializable]
    public struct Business
    {
        public string BusinessId;
        public int Level;
        public float IncomeProgress;
    }

    [Serializable]
    public struct Modifier
    {
        public string ModifierId;
        public string BusinessId;
    }
}