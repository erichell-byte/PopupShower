using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyProject.Scripts
{
	public class PopupSaleResourceView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI titleText;
		[SerializeField] private TextMeshProUGUI descriptionText;
		[SerializeField] private TextMeshProUGUI newPriceText;
		[SerializeField] private TextMeshProUGUI oldPriceText;
		[SerializeField] private TextMeshProUGUI discountText;
		[SerializeField] private GameObject discountBackground;
		[SerializeField] private Image mainIcon;
		[SerializeField] private Button buyButton;
		[SerializeField] private ItemView itemPrefab;
		[SerializeField] private Transform itemsContainer;

		public Action OnBuyButtonClicked;

		private void Awake()
		{
			buyButton.onClick.AddListener(BuyButtonClick);
		}

		public void SetTitle(string title)
		{
			titleText.text = title;
		}

		public void SetDescription(string description)
		{
			descriptionText.text = description;
		}

		public void SetPrice(float price, int discountAtPercent)
		{
			bool hasDiscount = discountAtPercent > 0;
			
			oldPriceText.gameObject.SetActive(hasDiscount);
			discountText.gameObject.SetActive(hasDiscount);
			discountBackground.SetActive(hasDiscount);
			
			if (hasDiscount)
			{
				var newPrice = price - (price * (discountAtPercent / 100f));
					
				oldPriceText.text = price.ToString("C2");
				discountText.text = $"-{discountAtPercent}%";
				newPriceText.text = newPrice.ToString("C2");
			}
			else
			{
				newPriceText.text = price.ToString("C2");
			}
		}

		public void SetMainIcon(Sprite icon)
		{
			mainIcon.sprite = icon;
		}
		
		public void ClearItems()
		{
			foreach (Transform child in itemsContainer)
			{
				Destroy(child.gameObject);
			}
		}

		private void AddItem(int count, Sprite icon)
		{
			ItemView itemView = Instantiate(itemPrefab, itemsContainer);
			itemView.UpdateView(count, icon);
		}

		public void AddItems(List<ItemModel> itemModels)
		{
			foreach (var item in itemModels)
			{
				AddItem(item.count, item.icon);
			}
		}

		private void BuyButtonClick()
		{
			OnBuyButtonClicked?.Invoke();
		}

		private void OnDestroy()
		{
			buyButton.onClick.RemoveListener(BuyButtonClick);
		}
	}
}