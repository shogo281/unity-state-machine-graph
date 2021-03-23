using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	/// <summary>
	/// 即時に遷移するステート
	/// </summary>
	[IgnoreCreateStateDropdown]
	public class ImmediateExitState : State
	{
		protected override void OnEnter()
		{
			base.OnEnter();
			Exit();
		}
	}
}
