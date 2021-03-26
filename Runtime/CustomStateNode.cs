using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace KStateMachine
{
	[CreateNodeMenu( "Create state node" )]
	public class CustomStateNode : StateNode
	{
		[Input( ShowBackingValue.Never ), SerializeField] private Transitions toTransitions = new Transitions();
		[Output( ShowBackingValue.Always, ConnectionType.Override ), SerializeField] private Transitions fromTransitions = new Transitions();

		protected override void Reset()
		{
			base.Reset();
			toTransitions.Clear();
			fromTransitions.Clear();
		}

		public override void OnRemoveConnection( NodePort port )
		{
			base.OnRemoveConnection( port );
		}

		protected override void OnCreateTransition( Transition transition )
		{
			base.OnCreateTransition( transition );

			if( transition.From == this )
			{
				fromTransitions.Add( transition );
			}
			else if( transition.To == this )
			{
				toTransitions.Add( transition );
			}
		}

		protected override void OnRemoveTransition( Transition transition )
		{
			base.OnRemoveTransition( transition );

			if( transition.From == this )
			{
				fromTransitions.Remove( transition );
			}
			else if( transition.To == this )
			{
				toTransitions.Remove( transition );
			}
		}
	}
}
