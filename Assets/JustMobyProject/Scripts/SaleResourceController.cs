using System;
using UnityEngine;

namespace JustMobyProject.Scripts
{
	public class SaleResourceController 
	{
		private IconsData iconsData;
		private PopupSaleResourceView view;
		private PopupSaleResourceModel model;

		private const int MAX_AMOUNT_OF_OBJECT = 6;
		private const int MIN_AMOUNT_OF_OBJECT = 3;
		
		public SaleResourceController(
			PopupSaleResourceView view,
			PopupSaleResourceModel model)
		{
			this.view = view;
			this.model = model;
		}

		public void Initialize()
		{
			view.ClearItems();
			
			view.SetTitle(model.title);
			view.SetDescription(model.description);
			view.SetPrice(model.price, model.discount);
			view.SetMainIcon(model.mainIcon);
			view.OnBuyButtonClicked += BuyButtonClicked;
			
			if (model.itemModels.Count > MAX_AMOUNT_OF_OBJECT || 
			    model.itemModels.Count < MIN_AMOUNT_OF_OBJECT)
				throw new Exception("Count of item at sale resource popup incorrect");
			
			view.AddItems(model.itemModels);
		}

		private void BuyButtonClicked()
		{
			Debug.LogError("BuyButtonClicked");
		}

		public void Dispose()
		{
			view.OnBuyButtonClicked -= BuyButtonClicked;
		}
	}
}