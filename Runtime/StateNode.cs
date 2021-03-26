using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace KStateMachine
{
	[CreateNodeMenu( "" )]
	public class StateNode : Node
	{
		[SerializeReference] private State state = null;
		[SerializeField, HideInInspector] private Transitions connectedTransitions = new Transitions();

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
			connectedTransitions.Clear();
		}

		/// <summary>
		/// エディター
		/// </summary>
		protected virtual void OnValidate()
		{
		}

		public override void OnCreateConnection( NodePort @from, NodePort to )
		{
			base.OnCreateConnection( @from, to );

			var fromStateNode = from.node as StateNode;
			var toStateNode = to.node as StateNode;

			if( fromStateNode == null || toStateNode == null )
			{
				return;
			}

			var transition = new Transition( fromStateNode, toStateNode );

			OnCreateTransition( transition );
		}

		public override void OnRemoveConnection( NodePort port )
		{
			base.OnRemoveConnection( port );
			OnRemoveConnection();
		}

		private void OnRemoveConnection()
		{
			var checkFromToList = new Transitions();

			foreach( var nodePort in Ports )
			{
				var connection = nodePort.Connection;

				if( connection == null )
				{
					continue;
				}

				var other = connection.node as StateNode;

				if( other == null )
				{
					continue;
				}

				( StateNode from, StateNode to ) fromTo = ( null, null );

				switch( nodePort.Connection.direction )
				{
					case NodePort.IO.Input:
						fromTo = ( this, other );
						break;

					case NodePort.IO.Output:
						fromTo = ( other, this );
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				checkFromToList.Add( new Transition( fromTo.from, fromTo.to ) );

			}

			foreach( var connectedTransition in connectedTransitions )
			{

				if( connectedTransition.From != this )
				{
					connectedTransition.From.OnRemoveConnection();
				}

				if( connectedTransition.To != this )
				{
					connectedTransition.To.OnRemoveConnection();
				}
			}

			var i = connectedTransitions.RemoveAll( t => checkFromToList.Any( u => t.From == u.From && t.To == u.To ) == false );

			Debug.Log( i );
		}

		protected virtual void OnCreateTransition( Transition transition )
		{

		}

		protected virtual void OnRemoveTransition( Transition transition )
		{

		}
	}
}
