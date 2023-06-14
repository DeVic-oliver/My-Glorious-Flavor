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
            if (HasNextOrder())
            {
                
                SetNextOrderDataThenUpdateTable();
            }
            else
            {
                ClearOrderDataThenInvokeEndEvents();
                
            }
        }

        private bool HasNextOrder()
        {
            return (_ordersRandomized[_currentOrderIndex]);
            int nextIndex = _currentOrderIndex + 1;
            try
            {
                return (Orders[nextIndex]);
            }
            catch
            {
                return false;
            }
        }

        private void SetNextOrderDataThenUpdateTable()
        {
            _currentOrderIndex++;
            _currentOrder = GetNextOrder();
            UpdateIngredientsNameArray();
            UpdateTheOrderTableWithCurrentOrderData();
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

        private int GetCurrentOrderIngredientsLength()
        {
            return GetCurrentOrderIngredients().Length;
        }

        private BurgerIngredient[] GetCurrentOrderIngredients()
        {
            return _currentOrder.Ingredients;
        }

        private BurgerIngredient GetCurrentOrderIngredientIn(int index)
        {
            return _currentOrder.Ingredients[index];
        }

        private void ClearOrderDataThenInvokeEndEvents()
        {
            _currentOrder = null;
            ClearIngredientsNamesList();
            OnEndOrder?.Invoke();
        }

        private void ClearIngredientsNamesList()
        {
            _currentOrderIngredientsNames.Clear();
        }

        private void UpdateTheOrderTableWithCurrentOrderData()
        {
            _tableManager.SetBurgerOnTable(_currentOrder);
        }

    }
}