using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	/// <summary>
	/// ステート基底クラス
	/// </summary>
	[IgnoreCreateStateDropdown, Serializable]
	public abstract class State
	{
		private bool isInitialized = false;
		private StateMachine StateMachine = null;

		/// <summary>
		/// 初期化したか
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
		/// 初期化
		/// </summary>
		protected virtual void OnInitialize()
		{

		}

		/// <summary>
		/// 更新開始
		/// </summary>
		protected virtual void OnEnter()
		{

		}

		/// <summary>
		/// 更新中
		/// </summary>
		protected virtual void OnUpdate()
		{

		}

		/// <summary>
		/// Updateの後
		/// </summary>
		protected virtual void OnLateUpdate()
		{

		}

		/// <summary>
		/// 更新終了
		/// </summary>
		protected virtual void OnExit()
		{

		}

		/// <summary>
		/// 終了
		/// </summary>
		protected virtual void OnFinalize()
		{

		}
	}
}
