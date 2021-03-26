using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace KStateMachine
{
	[CreateNodeMenu( "" )]
	public class ExitStateNode : StateNode
	{
		[Input( ShowBackingValue.Never ), SerializeField] private StateNode input = null;

		protected override void Reset()
		{
			base.Reset();
			State = new ExitState();
		}
	}
}
