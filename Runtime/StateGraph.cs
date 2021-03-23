using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace KStateMachine
{
	[CreateAssetMenu( fileName = "state_graph", menuName = "KState/Graph" ), RequireNode( typeof( RootStateNode ), typeof( ExitStateNode ) )]
	public class StateGraph : NodeGraph
	{
		[SerializeField, HideInInspector] private RootStateNode rootStateNode = null;

		public override Node AddNode( Type type )
		{
			var node = base.AddNode( type );

			if( type == typeof( RootStateNode ) && node is RootStateNode root )
			{
				rootStateNode = root;
			}

			return node;
		}

		public StateNode[] GetStateNodeArray()
		{
			return nodes.Select( n => n as StateNode ).Where( n => n != null ).ToArray();
		}
	}
}
