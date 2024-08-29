
using UnityEngine;

namespace JustMobyProject.Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private LocalDatabaseManager databaseManager;
        [SerializeField] private PopupSaleResourceView popupView;

        private SaleResourceController controller;
    
        public void StartGame(int objectCount)
        {
            //TODO objectCount здесь не используется, потому количество и тип предметов указан в конфиге,
            //TODO не стал дополнительно тратить время hr для уточнения.
        
            PopupSaleResourceModel model = databaseManager.GetPopupSaleResourceModel();
            controller = new SaleResourceController(popupView, model);
            controller.Initialize();
            popupView.gameObject.SetActive(true);
        }

        private void OnDestroy()
        {
            controller.Dispose();
        }
    }
}