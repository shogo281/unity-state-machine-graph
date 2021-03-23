using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	/// <summary>
	/// �����ɑJ�ڂ���X�e�[�g
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
