using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetter_Free : MonoBehaviour
{
	[SerializeField] private Color color;
	[SerializeField] private List<string> exceptNames;
	[SerializeField] private List<GameObject> exceptObjects;
	
	[ContextMenu("Recolor")]
	private void Recolor()
	{
		Image[] children = GetComponentsInChildren<Image>(true);

		foreach (Image child in children)
		{
			if (exceptNames.Contains(child.gameObject.name))
			{
				continue;
			}

			if (exceptObjects.Contains(child.gameObject))
			{
				continue;
			}

			child.color = new Color(color.r, color.g, color.b, child.color.a);
			if (PrefabUtility.IsPartOfAnyPrefab(child.gameObject))
			{
				PrefabUtility.ApplyPrefabInstance(child.gameObject, InteractionMode.AutomatedAction);
			}
		}
	}
}
