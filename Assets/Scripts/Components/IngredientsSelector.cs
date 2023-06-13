namespace Assets.Scripts.Components
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;

    public class IngredientsSelector : MonoBehaviour
    {
        public UnityEvent<string[]> OnMountBurger;
        private string[] _ingredientsNameArray = new string[3];

        
        public void AddIngredientToMount(GameObject gameObject)
        {
            IterateThroughIngredientsArrayAndAddIngredientOnNullIndex(gameObject);
            SendIngredientsWhenLastItemOnArrayIsNotNull();
        }

        private void IterateThroughIngredientsArrayAndAddIngredientOnNullIndex(GameObject gameObject)
        {
            int length = _ingredientsNameArray.Length;
            for (int index = 0; index < length; index++)
            {
                if (_ingredientsNameArray[index] == null)
                {
                    _ingredientsNameArray[index] = gameObject.transform.name;
                    break;
                }
            }
        }

        private void SendIngredientsWhenLastItemOnArrayIsNotNull()
        {
            bool isNotNull = IsLastIndexNotNull();
            if (isNotNull)
            {
                MountBurgerThenClearArray();
            }
        }

        private bool IsLastIndexNotNull()
        {
            int lastIndex = _ingredientsNameArray.Length - 1;
            return (_ingredientsNameArray[lastIndex] != null);
        }

        private void MountBurgerThenClearArray()
        {
            OnMountBurger?.Invoke(_ingredientsNameArray);
            ClearIngredientsArray();
        }

        private void ClearIngredientsArray()
        {
            int length = _ingredientsNameArray.Length;
            Array.Clear(_ingredientsNameArray, 0, length);
        }

    }

}
