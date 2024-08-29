using System.Collections.Generic;
using UnityEngine;

namespace JustMobyProject.Scripts
{
	public struct PopupSaleResourceModel
	{
		public string title;
		public string description;
		public float price;
		public int discount;
		public List<ItemModel> itemModels;
		public Sprite mainIcon;
	}
}