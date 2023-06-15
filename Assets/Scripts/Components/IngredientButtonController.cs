namespace Assets.Scripts.Components
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class IngredientButtonController : MonoBehaviour
    {
        [SerializeField] private List<Button> _buttons;
        [SerializeField] private Color _selectedColor;

        public void SetButtonsToBeInteractive()
        {
            foreach (Button button in _buttons)
            {
                button.interactable = true;
            }
        }

        public void ChangeButtonColors(Button button)
        {
            SetButtonNormalAndSelectColorTo(button, _selectedColor);
        }

        public void ClearButtonsNormalColor()
        {
            foreach (Button button in _buttons)
            {
                SetButtonNormalAndSelectColorTo(button, Color.white);
            }
        }

        private void SetButtonNormalAndSelectColorTo(Button button, Color color)
        {
            ColorBlock buttonColors = button.colors;
            buttonColors.normalColor = color;
            buttonColors.selectedColor= color;
            button.colors = buttonColors;
        }

    }
}