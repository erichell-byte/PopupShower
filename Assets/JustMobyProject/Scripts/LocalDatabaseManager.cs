using System.Collections.Generic;
using UnityEngine;

namespace JustMobyProject.Scripts
{
    public class LocalDatabaseManager : MonoBehaviour
    {
        [SerializeField] private PopupSaleResourceData popupSaleResourceData;
        [SerializeField] private IconsData iconsData;
    
        public PopupSaleResourceModel GetPopupSaleResourceModel()
        {
            PopupSaleResourceModel model = new PopupSaleResourceModel
            {
                title = popupSaleResourceData.Title,
                description = popupSaleResourceData.Description,
                price = popupSaleResourceData.Price,
                discount = popupSaleResourceData.DiscountAtPercent,
                mainIcon = GetIconByName(popupSaleResourceData.MainIconName)
            };

            List<ItemModel> itemModels = new List<ItemModel>();
            foreach (var item in popupSaleResourceData.Items)
            {
                var icon = GetIconByName(item.Name);
                if (icon == null)
                    continue;
            
                itemModels.Add(new ItemModel()
                {
                    count = item.Count,
                    icon = icon
                });
            }

            model.itemModels = itemModels;
        
            return model;
        }
    
        private Sprite GetIconByName(string name)
        {
            return iconsData.icons.Find(i => i.name == name)?.sprite;
        }
    }
}