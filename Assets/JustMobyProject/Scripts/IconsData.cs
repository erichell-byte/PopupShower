using System.Collections.Generic;
using UnityEngine;

namespace JustMobyProject.Scripts
{
	[CreateAssetMenu(fileName = "IconsData", menuName = "ScriptableObjects/IconsData")]
	public class IconsData : ScriptableObject
	{
		public List<IconItem> icons;
	}
}