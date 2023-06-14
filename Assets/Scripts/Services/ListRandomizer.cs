namespace Assets.Scripts.Services
{
    using System.Collections.Generic;
    using UnityEngine;
    
    public class ListRandomizer
    {
        public static List<T> Randomize<T>(List<T> listToRandomize)
        {
            List<T> originalList = new List<T>(listToRandomize);
            List<T> randomizedList = new List<T>();

            for (int i = originalList.Count; i > 0; i--)
            {
                int randomIndex = Random.Range(0, originalList.Count - 1);
                T item = originalList[randomIndex];
                randomizedList.Add(item);
                originalList.Remove(item);
            }

            return randomizedList;
        }
    }
}