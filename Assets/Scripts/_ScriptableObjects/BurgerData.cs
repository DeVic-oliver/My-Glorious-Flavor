namespace Assets.Scripts._ScriptableObjects
{
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    using UnityEngine;

    [CreateAssetMenu(fileName = "Burger", menuName = "ScriptableObjects/Burguers")]
    public class BurgerData : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public GameObject[] Ingredients = new GameObject[3];
    }
}