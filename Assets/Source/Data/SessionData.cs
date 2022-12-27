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
    }

    [Serializable]
    public class Business
    {
        public string BusinessId;
        public int Level;
        public float IncomeProgress;
        public List<bool> BoughtModifiers = new List<bool>();
    }
}