namespace Assets.Scripts._ScriptableObjects
{
    #if UNITY_EDITOR
        using UnityEditor;
    #endif
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "BurgerIngredient_", menuName = "ScriptableObjects/Food/Ingredient")]
    public class BurgerIngredient : ScriptableObject
    {
        public string Name;
        public Sprite IngredientIcon;
        public GameObject IngredientPrefab;
    }
}