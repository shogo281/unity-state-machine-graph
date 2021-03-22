using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using XNodeEditor;
using UnityEngine.Scripting;

namespace KStateMachine
{
	[CustomNodeEditor( typeof( StateNode ) )]
	public class StateNodeEditor : NodeEditor
	{
		private static List<string> stateTypeList = null;

		[InitializeOnLoadMethod]
		private static void Init()
		{

			stateTypeList = new List<string>();

			foreach( var type in TypeCache.GetTypesDerivedFrom( typeof( State ) ) )
			{
				Debug.Log( type );
			}
		}

		public override void OnBodyGUI()
		{
			base.OnBodyGUI();
		}
	}
}
