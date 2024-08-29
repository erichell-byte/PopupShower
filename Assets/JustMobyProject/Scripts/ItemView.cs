using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JustMobyProject.Scripts
{
	public class ItemView : MonoBehaviour
	{
		[SerializeField] private Image icon;
		[SerializeField] private TextMeshProUGUI countText;

		public void UpdateView(int count, Sprite iconSprite)
		{
			countText.text = count.ToString();
			icon.sprite = iconSprite;
		}

	}
}