using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	/// <summary>
	///ステートマシン
	/// </summary>
	public class StateMachine
	{
		private bool isInitialized = false;

		/// <summary>
		/// 初期化したか
		/// </summary>
		public bool IsInitialized => isInitialized;

		/// <summary>
		/// コンストラクタ
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
