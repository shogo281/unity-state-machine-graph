using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace KStateMachine
{
	[CreateNodeMenu( "" )]
	public class StateNode : Node
	{
		[SerializeReference] private State state = null;

		/// <summary>
		/// ステートのインスタンス
		/// </summary>
		public State State
		{
			get => state;
#if UNITY_EDITOR

			set
			{
				if( value != null )
				{
					name = value.GetType().Name;
				}
				else
				{
					name = "None";
				}

				state = value;
			}

#endif
		}

		/// <summary>
		/// エディター
		/// </summary>
		protected virtual void Reset()
		{
			name = "None";
		}

		/// <summary>
		/// エディター
		/// </summary>
		protected virtual void OnValidate()
		{

		}
	}
}
