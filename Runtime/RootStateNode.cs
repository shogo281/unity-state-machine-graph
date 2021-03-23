using System.Collections;
using System.Collections.Generic;
using KStateMachine;
using UnityEngine;
using XNode;

namespace KStateMachine
{
	[CreateNodeMenu( "" )]
	public class RootStateNode : StateNode
	{
		[Output( ShowBackingValue.Never, ConnectionType.Override ), SerializeField] private StateNode output = null;

		protected override void Reset()
		{
			base.Reset();
			output = this;
			State = new RootState();
		}

		public override object GetValue( NodePort port )
		{
			return this;
		}
	}
}
