using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using XNodeEditor;

namespace KStateMachine.Editor
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
				var item = new AdvancedDropdownItem( "State" );

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

		private void DisplayDropdown( CustomStateNode stateNode, Rect rect )
		{
			var dropdown = new StateClassNameDropdown( new AdvancedDropdownState(), stateTypeNameDictionary.Keys );

			dropdown.Show( rect );

			dropdown.onceItemSelected += name =>
			{
				var type = Type.GetType( stateTypeNameDictionary[name] );
				var instance = Activator.CreateInstance( type ) as State;

				if( instance == null )
				{
					return;
				}

				Undo.RecordObject( stateNode, "Create state" );
				stateNode.State = instance;
			};
		}

		private void DestroyState( CustomStateNode stateNode )
		{
			Undo.RecordObject( stateNode, "Destroy state" );
			stateNode.State = null;
		}

		public override void AddContextMenuItems( GenericMenu menu )
		{
			base.AddContextMenuItems( menu );
			var stateNode = target as CustomStateNode;

			if( stateNode == null )
			{
				return;
			}

			if( stateNode.State == null )
			{
				var rect = new Rect( Event.current.mousePosition, Vector2.zero );

				menu.AddItem( new GUIContent( "Create state" ), false, () =>
				{
					DisplayDropdown( stateNode, rect );
				} );

			}
			else if( stateNode.State != null )
			{
				menu.AddItem( new GUIContent( "Destroy state" ), false, () =>
				{
					DestroyState( stateNode );
				} );
			}
		}
	}
}
