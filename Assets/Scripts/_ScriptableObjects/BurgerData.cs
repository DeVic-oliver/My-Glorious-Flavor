namespace Assets.Scripts._ScriptableObjects
{
    #if UNITY_EDITOR
    using UnityEditor;
    #endif
    using UnityEngine;

    [CreateAssetMenu(fileName = "Burger", menuName = "ScriptableObjects/Food/Burger")]
    public class BurgerData : ScriptableObject
    {
        public GameObject TheBurgerPrefab;
        public string Name;
        public BurgerIngredient[] Ingredients = new BurgerIngredient[3];
    }
}