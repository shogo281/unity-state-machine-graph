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
		/// �X�e�[�g�̃C���X�^���X
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
		/// �G�f�B�^�[
		/// </summary>
		protected virtual void Reset()
		{
			name = "None";
		}

		/// <summary>
		/// �G�f�B�^�[
		/// </summary>
		protected virtual void OnValidate()
		{

		}
	}
}
