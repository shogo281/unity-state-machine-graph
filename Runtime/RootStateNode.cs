using System.Collections;
using System.Collections.Generic;
using KStateMachine;
using UnityEngine;
using XNode;

namespace KStateMachine
{
	[CreateNodeMenu( "" )]
	public sealed class RootStateNode : StateNode
	{
		[Output( ShowBackingValue.Always, ConnectionType.Override ), SerializeField] private Transitions fromTransitions = new Transitions();

		protected override void Reset()
		{
			base.Reset();
			State = new RootState();
		}

		public override object GetValue( NodePort port )
		{
			return this;
		}

		protected override void OnCreateTransition( Transition transition )
		{
			base.OnCreateTransition( transition );

			if( transition.From == this )
			{
				fromTransitions.Add( transition );
			}
		}

		protected override void OnRemoveTransition( Transition transition )
		{
			base.OnRemoveTransition( transition );
			fromTransitions.Remove( transition );
		}
	}
}
