using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using XNodeEditor;

namespace KStateMachine
{
	[CustomNodeEditor( typeof( CustomStateNode ) )]
	public class CustomStateNodeEditor : NodeEditor
	{
		private class StateClassNameDropdown : AdvancedDropdown
		{
			public event Action<string> onceItemSelected = null;
			private string[] typeNameArray = null;

			public StateClassNameDropdown( AdvancedDropdownState state, IEnumerable<string> typeNames ) : base( state )
			{
				typeNameArray = typeNames.ToArray();
			}

			protected override AdvancedDropdownItem BuildRoot()
			{
				var item = new AdvancedDropdownItem( "Scripts" );

				foreach( var typeName in typeNameArray )
				{
					item.AddChild( new AdvancedDropdownItem( typeName ) );
				}

				return item;
			}

			protected override void ItemSelected( AdvancedDropdownItem item )
			{
				base.ItemSelected( item );
				onceItemSelected?.Invoke( item.name );
				onceItemSelected = null;
			}
		}

		private static Dictionary<string, string> stateTypeNameDictionary = null;

		[InitializeOnLoadMethod]
		private static void Init()
		{

			stateTypeNameDictionary = new Dictionary<string, string>();

			foreach( var type in TypeCache.GetTypesDerivedFrom( typeof( State ) ) )
			{
				if( type.IsDefined( typeof( IgnoreCreateStateDropdownAttribute ), false ) )
				{
					continue;
				}

				string typeName = type.Name;

				var assemblyQualifiedName = type.AssemblyQualifiedName;

				stateTypeNameDictionary.Add( typeName, assemblyQualifiedName );
			}
		}

		public override void OnBodyGUI()
		{
			base.OnBodyGUI();
			var stateNode = target as CustomStateNode;

			if( stateNode == null )
			{
				return;
			}

			if( stateNode.State == null )
			{
				if( GUILayout.Button( "Create state" ) )
				{
					var dropdown = new StateClassNameDropdown( new AdvancedDropdownState(), stateTypeNameDictionary.Keys );
					dropdown.Show( GUILayoutUtility.GetRect( GetWidth(), 100 ) );

					dropdown.onceItemSelected += name =>
					{
						var type = Type.GetType( stateTypeNameDictionary[name] );
						var instance = Activator.CreateInstance( type ) as State;

						if( instance == null )
						{
							return;
						}

						Undo.RecordObject( stateNode, "create state" );
						stateNode.State = instance;
					};
				}
			}
			else
			{
				if( GUILayout.Button( "Destroy state" ) )
				{
					Undo.RecordObject( stateNode, "destroy state" );
					stateNode.State = null;
				}
			}
		}
	}
}
