using System;
using UnityEngine;

namespace SaveLoad
{
    public static class Profile
    {
        [Serializable]
        private class MainData
        {
            public float totalDistance = 0f;
            public int points = 0;
        }

        private static MainData mainData;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CheckData()
        {
            CheckMainData(); 
        }

        
        private static void CheckMainData()
        {
            if(mainData!= null) return;

            mainData = GetData<MainData>("MainData");
        }

        private static T GetData<T>(string key) where T : new()
        {
            if (PlayerPrefs.HasKey(key))
            {
                return JsonUtility.FromJson<T>(PlayerPrefs.GetString(key));
            }

            var data = new T();
            PlayerPrefs.SetString(key, JsonUtility.ToJson(data));
            return data;
        }

        public static void Save(bool main = false)
        {
            if (main)
            {
                PlayerPrefs.SetString("MainData", JsonUtility.ToJson(mainData));
            }
        }

        public static void DeletaAll()
        {
            PlayerPrefs.DeleteKey("MainData");
        }

        public static float TotalDistance
        {
            get => mainData.totalDistance;
            set
            {
                mainData.totalDistance = value;
                Save(main: true);
            } 
        }
        
        public static int Points
        {
            get => mainData.points;
            set 
            {
                mainData.points = value;
                Save(main: true);
            } 
        }
    }
}