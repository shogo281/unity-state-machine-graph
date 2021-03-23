using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	/// <summary>
	///�X�e�[�g�}�V��
	/// </summary>
	public class StateMachine
	{
		private bool isInitialized = false;

		/// <summary>
		/// ������������
		/// </summary>
		public bool IsInitialized => isInitialized;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		private StateMachine()
		{

		}

		public StateMachine( StateGraph stateGraph )
		{
			foreach( var stateNode in stateGraph.GetStateNodeArray() )
			{
#if UNITY_EDITOR

				if( stateNode.State == null )
				{
					stateNode.State = new ImmediateExitState();
				}

#endif

				var state = stateNode.State;

				if( state == null )
				{
					continue;
				}

				state.InitializeState( this );
			}
		}

		public void Update()
		{

		}

		public void LateUpdate()
		{

		}
	}
}
