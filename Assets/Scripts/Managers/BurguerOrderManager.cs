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
        }

        private void InitializeOrderIngredientsNames()
        {
        }

        {
            for (int i = 0; i < _currentOrder.Ingredients.Length; i++)
            {
                string ingredientName = _currentOrder.Ingredients[i].name;
                _currentOrderIngredientsNames[i] = ingredientName;
            }
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

    }
}