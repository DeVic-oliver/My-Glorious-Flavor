namespace Assets.Scripts.Managers
{
    using Assets.Scripts._ScriptableObjects;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class BurguerOrderManager : MonoBehaviour
    {
        public UnityEvent OnOrderMountSuccess;
        public UnityEvent OnOrderMountFail;
        public UnityEvent OnEndOrder;

        public List<BurgerData> Orders;
        public BurgerData CurrentOrder;
        private int _currentOrderIndex;

        private string[] _currentOrderIngredientsNames;

        // Use this for initialization
        void Start()
        {
            SetInitialOrder();

            InitializeOrderIngredientsNames();
        }

        private void SetInitialOrder()
        {
            CurrentOrder = Orders[0];
            _currentOrderIndex = 0;
        }

        private void InitializeOrderIngredientsNames()
        {
            InitializeIngredientsNamesArrayWithSameSizeOfOrderIngredients();
            PopulateIngredientsNameArray();
        }

        private void InitializeIngredientsNamesArrayWithSameSizeOfOrderIngredients()
        {
            int length = CurrentOrder.Ingredients.Length;
            _currentOrderIngredientsNames = new string[length];
        }

        private void PopulateIngredientsNameArray()
        {
            for (int i = 0; i < CurrentOrder.Ingredients.Length; i++)
            {
                string ingredientName = CurrentOrder.Ingredients[i].name;
                _currentOrderIngredientsNames[i] = ingredientName;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void IsMountedBurgerIngredientsCorrect(string[] ingredientsNames)
        {
            foreach (string itemName in ingredientsNames)
            {
                int pos = Array.IndexOf(_currentOrderIngredientsNames, itemName);
                if(pos == -1)
                {
                    OnOrderMountFail?.Invoke();
                    SetNextOrder();
                    break;
                }
            }
            OnOrderMountSuccess?.Invoke();
            SetNextOrder();
        }

        private void SetNextOrder()
        {
            _currentOrderIndex++;
            if (HasNextOrder())
            {
                CurrentOrder = GetNextOrder();
            }
            else
            {
                OnEndOrder?.Invoke();
            }
        }

        private bool HasNextOrder()
        {
            return (Orders[_currentOrderIndex]);
        }

        private BurgerData GetNextOrder()
        {
            return Orders[_currentOrderIndex];
        }

    }
}