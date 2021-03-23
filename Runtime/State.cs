using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	/// <summary>
	/// �X�e�[�g���N���X
	/// </summary>
	[IgnoreCreateStateDropdown, Serializable]
	public abstract class State
	{
		private bool isInitialized = false;
		private StateMachine StateMachine = null;

		/// <summary>
		/// ������������
		/// </summary>
		public bool IsInitialized => isInitialized;

		public void InitializeState( StateMachine stateMachine )
		{
			if( isInitialized == true )
			{
				return;
			}

			OnInitialize();
			isInitialized = true;
		}

		public void Enter()
		{
			OnEnter();
		}

		public void Update()
		{
			OnUpdate();
		}

		public void LateUpdate()
		{
			OnLateUpdate();
		}

		public void Exit()
		{
			OnExit();
		}

		public void FinalizeState()
		{
			if( isInitialized == false )
			{
				return;
			}

			OnFinalize();

			isInitialized = false;
		}

		/// <summary>
		/// ������
		/// </summary>
		protected virtual void OnInitialize()
		{

		}

		/// <summary>
		/// �X�V�J�n
		/// </summary>
		protected virtual void OnEnter()
		{

		}

		/// <summary>
		/// �X�V��
		/// </summary>
		protected virtual void OnUpdate()
		{

		}

		/// <summary>
		/// Update�̌�
		/// </summary>
		protected virtual void OnLateUpdate()
		{

		}

		/// <summary>
		/// �X�V�I��
		/// </summary>
		protected virtual void OnExit()
		{

		}

		/// <summary>
		/// �I��
		/// </summary>
		protected virtual void OnFinalize()
		{

		}
	}
}
