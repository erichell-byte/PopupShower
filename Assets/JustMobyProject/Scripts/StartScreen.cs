using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyProject.Scripts
{
    public class StartScreen : MonoBehaviour
    {
        [SerializeField] private Button launchButton;
        [SerializeField] private TMP_InputField objectCountField;
        [SerializeField] private GameController gameController;

        private int objectCount;
        void Awake()
        {
            launchButton.onClick.AddListener(OpenPopup);
            launchButton.interactable = false;
            objectCountField.onValueChanged.AddListener(UpdateButtonState);
        }

        private void OpenPopup()
        {
            gameController.StartGame(objectCount);
        }

        private void UpdateButtonState(string inputText)
        {
            if (Int32.TryParse(inputText, out objectCount))
            {
                objectCount = Mathf.Clamp(objectCount, 3, 6);
                launchButton.interactable = true;
            }
            else
            {
                launchButton.interactable = false;
            }
        }

        private void OnDestroy()
        {
            launchButton.onClick.RemoveListener(OpenPopup);
            objectCountField.onValueChanged.RemoveListener(UpdateButtonState);
        }
    }
}