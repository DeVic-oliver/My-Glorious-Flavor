namespace Assets.Scripts.Managers
{
    using Assets.Scripts._ScriptableObjects;
    using Assets.Scripts.Services;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.Events;

    public class BurguerOrderManager : MonoBehaviour
    {
        public UnityEvent OnOrderMountSuccess;
        public UnityEvent OnOrderMountFail;
        public UnityEvent OnEndOrder;

        public List<BurgerData> Orders;
        
        [SerializeField] private BurgerOrderTableManager _tableManager;

        private List<BurgerData> _ordersRandomized;
        private BurgerData _currentOrder;
        private int _currentOrderIndex;
        private List<string> _currentOrderIngredientsNames = new();


        void Start()
        {
            RandomizeOrders();
            SetCurrentOrderWithFirstOnOrdersList();
            InitializeOrderIngredientsNames();
        }

        private void RandomizeOrders()
        {
            _ordersRandomized = ListRandomizer.Randomize(Orders);
        }

        private void SetCurrentOrderWithFirstOnOrdersList()
        {
            _currentOrder = _ordersRandomized[0];
            _currentOrderIndex = 0;
            UpdateTheOrderTableWithCurrentOrderData();
        }

        private void InitializeOrderIngredientsNames()
        {
            UpdateIngredientsNameArray();
        }

        public void IsMountedBurgerIngredientsCorrect(string[] ingredientsNames)
        {
            if (IsMountedCorrectly(ingredientsNames))
            {
                OnOrderMountSuccess?.Invoke();
            }
            else
            {
                OnOrderMountFail?.Invoke();
            }
            SetNextOrder();
        }

        private bool IsMountedCorrectly(string[] ingredientsNames)
        {
            foreach (string itemName in ingredientsNames)
            {
                if (!_currentOrderIngredientsNames.Contains(itemName))
                {
                    ClearIngredientsNamesList();
                    return false;
                }
                _currentOrderIngredientsNames.Remove(itemName);
            }
            ClearIngredientsNamesList();
            return true;
        }

        private void SetNextOrder()
        {
            _currentOrderIndex++;
            if (HasNextOrder())
            {
                _currentOrder = GetNextOrder();
            }
            else
            {
                OnEndOrder?.Invoke();
            }
        }

        private bool HasNextOrder()
        {
            return (_ordersRandomized[_currentOrderIndex]);
        }

        private BurgerData GetNextOrder()
        {
            return _ordersRandomized[_currentOrderIndex];
        }

        private void UpdateIngredientsNameArray()
        {
            int length = GetCurrentOrderIngredientsLength();
            for (int i = 0; i < length; i++)
            {
                BurgerIngredient ingredient = GetCurrentOrderIngredientIn(i);
                string ingredientName = ingredient.Name;
                _currentOrderIngredientsNames.Add(ingredientName);
            }
        }
        private void UpdateTheOrderTableWithCurrentOrderData()
        {
            _tableManager.SetBurgerOnTable(_currentOrder);
        }

    }
}