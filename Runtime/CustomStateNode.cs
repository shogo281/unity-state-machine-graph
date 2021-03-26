using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	[CreateNodeMenu( "CustomState" )]
	public class CustomStateNode : StateNode
	{
		[Input( ShowBackingValue.Never ), SerializeField] private StateNode input = null;
		[Output( ShowBackingValue.Never, ConnectionType.Override ), SerializeField] private StateNode output = null;
	}
}
