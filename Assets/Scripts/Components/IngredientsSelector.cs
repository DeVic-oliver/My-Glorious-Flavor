namespace Assets.Scripts.Components
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class IngredientsSelector : MonoBehaviour
    {
        public GameObject[] IngredientsList = new GameObject[3];
        
        
        public void AddIngredientToList(GameObject gameObject)
        {
            int length = IngredientsList.Length;
            for (int index = 0; index < length; index++)
            {
                if (IngredientsList[index] == null)
                {
                    IngredientsList[index] = gameObject;
                    break;
                }
            }

            

            if (IngredientsList[length - 1] != null)
            {
                Debug.Log("FIRE EVENT");
                Debug.Log("MOUNT SANDWICH");
                foreach (GameObject ingredient in IngredientsList)
                {
                    Debug.Log(ingredient.name);
                }
                Debug.Log("APPLY SCORE LOGIC");
                Array.Clear(IngredientsList, 0, length);
            }

        }

        public void DebugMessage()
        {
            Debug.Log("THE GAME STARTED");
        }

    }

}
