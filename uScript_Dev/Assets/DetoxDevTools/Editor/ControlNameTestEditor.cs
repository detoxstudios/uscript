using UnityEditor;
using UnityEngine;

public class ControlNameTestEditor : EditorWindow
{
	static private ControlNameTestEditor _instance = null;

	static public ControlNameTestEditor Instance
	{
		get
		{
			if (null == _instance)
			{
				Init();
			}
			return _instance;
		}
	}
	
	[MenuItem ("Detox Tools/Internal/ControlName Test Editor &%c")]
	private static void Init()
	{
		_instance = (ControlNameTestEditor)EditorWindow.GetWindow(typeof(ControlNameTestEditor), false, "ControlName");
	}

	public int _gridIndex = 0;
	public string[] _gridOptions = new string[] {"A", "B", "C", "D"};
	private int _intField;
	private float _floatField;
	private string _textField;
	private Color _colorField;
	
	void OnGUI()
	{
		EditorGUILayout.BeginVertical(GUILayout.Width(256));
		{
			_gridIndex = GUILayout.SelectionGrid(_gridIndex, _gridOptions, 4);
		
			EditorGUILayout.Separator();

			EditorGUILayout.LabelField("Name of focused control:", "\"" + GUI.GetNameOfFocusedControl() + "\"");
			EditorGUILayout.LabelField("keyboardControl:", GUIUtility.keyboardControl.ToString());
			EditorGUILayout.LabelField("hotControl:", GUIUtility.hotControl.ToString());
		
			EditorGUILayout.Separator();
			
			EditorGUILayout.BeginVertical(GUI.skin.box);
			{
				switch (_gridIndex)
				{
					case 0:
						_intField = EditorGUILayout.IntField(ControlName("IntField"), _intField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_00"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_01"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_02"), _textField);
						break;
					case 1:
						_floatField = EditorGUILayout.FloatField(ControlName("FloatField"), _floatField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_03"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_04"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_05"), _textField);
						break;
					case 2:
						_colorField = EditorGUILayout.ColorField(ControlName("ColorField"), _colorField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_06"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_07"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_08"), _textField);
						break;
					case 3:
						_textField = EditorGUILayout.TextField(ControlName("TextField_09"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_0A"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_0B"), _textField);
						_textField = EditorGUILayout.TextField(ControlName("TextField_0C"), _textField);
						break;
				}
			}
			EditorGUILayout.EndVertical();

			EditorGUILayout.Separator();
			
			if (GUILayout.Button("keyboardControl = 0"))
			{
				GUIUtility.keyboardControl = 0;
			}
		}
		EditorGUILayout.EndVertical();
	}
					
	private string ControlName(string name)
	{
		string result = _gridOptions[_gridIndex] + "_" + name;
		GUI.SetNextControlName(result);
		return result;
	}
}
