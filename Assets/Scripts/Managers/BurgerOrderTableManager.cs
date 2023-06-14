namespace Assets.Scripts.Managers
{
    using Assets.Scripts._ScriptableObjects;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class BurgerOrderTableManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _burgerName;
        [SerializeField] private GameObject _burgerContainer;
        [SerializeField] private List<Image> _recipeImageList;


        public void SetBurgerOnTable(BurgerData burger)
        {

            if(_burgerContainer.transform.childCount > 0)
            {
                Destroy(_burgerContainer.transform.GetChild(0).gameObject);
            }

            _burgerName.text = burger.Name;

            for (int i = 0; i < burger.Ingredients.Length; i++)
            {
                _recipeImageList[i].sprite = burger.Ingredients[i].IngredientIcon;
            }

            Instantiate(burger.TheBurgerPrefab, _burgerContainer.transform);

        }
        
    }
}