using System.Collections.Generic;
using UnityEngine;

namespace JustMobyProject.Scripts
{
	[CreateAssetMenu(menuName = "Data/PopupResourceData", fileName = "PopupSaleResourceData")]
	public class PopupSaleResourceData : ScriptableObject
	{
		public string Title;
		public string Description;
		public List<ItemInfo> Items;
		public float Price;
		public int DiscountAtPercent;
		public string MainIconName;
	}
}