using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class EasingCurvesEditorWindow : EditorWindow {

	#region Class members
	#endregion

	#region Class overrides
	[MenuItem ("Tools/Tween/Easing Curves")]
	static void Init () {
		EasingCurvesEditorWindow window = (EasingCurvesEditorWindow) GetWindow (typeof (EasingCurvesEditorWindow));
		window.Show ();
	}

	private void OnGUI () {
		Rect rect = new Rect (5, 5, 400, 400);

		Rect[,] rects = GridRects (Vector2Int.one * 10, Vector2.one * 100, Vector2.one * 10);

		for (int x = 0; x < 10; x++) {
			for (int y = 0; y < 10; y++) {
				//DrawCurve (rects[x, y], (int) EasingCurves);
			}
		}


		//DrawCurve (rect, EasingCurves.easeOutBounce);
	}
	#endregion

	#region Class implementation
	private void DrawCurve (Rect rect, Func<float, float> curve) {
		float lenght = rect.width;
		float resolution = 100;

		Handles.BeginGUI ();

		GUI.Box (rect, "");
		GUILayout.BeginArea (rect);
		for (int i = 1; i < resolution; i++) {
			float prevPercent = (i > 0 ? i - 1 : i) / resolution;
			float percent = i / resolution;

			Vector2 prevPos = new Vector2 (lenght * prevPercent, lenght * curve (prevPercent));
			Vector2 pos = new Vector2 (lenght * percent, lenght * curve (percent));

			Handles.color = Color.red;
			Handles.DrawLine (prevPos, pos);
		}
		GUILayout.EndArea ();

		Handles.EndGUI ();
	}

	private Rect[,] GridRects (Vector2Int size, Vector2 cellSize, Vector2 cellSpacing) {
		Rect[,] rects = new Rect[size.x, size.y];

		for (int x = 0; x < size.x; x++) {
			for (int y = 0; y < size.y; y++) {
				Vector2 pos = new Vector2 (cellSize.x * x + cellSpacing.x * x, cellSize.y * y + cellSpacing.y * y);
				rects[x, y] = new Rect (pos, cellSize);
			}
		}

		return rects;
	}
	#endregion

	#region Interface implementation
	#endregion
}