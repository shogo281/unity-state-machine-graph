using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace KStateMachine
{
	[CreateNodeMenu( "" )]
	public class ExitStateNode : StateNode
	{
		[Input( ShowBackingValue.Never ), SerializeField] private Transitions toTransitions = new Transitions();

		protected override void Reset()
		{
			base.Reset();
			State = new ExitState();
		}

		protected override void OnCreateTransition( Transition transition )
		{
			base.OnCreateTransition( transition );

			if( transition.To == this )
			{
				toTransitions.Add( transition );
			}
		}

		protected override void OnRemoveTransition( Transition transition )
		{
			base.OnRemoveTransition( transition );
			toTransitions.Remove( transition );
		}
	}
}
