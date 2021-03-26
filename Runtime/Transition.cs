using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KStateMachine
{
	[Serializable]
	public class Transitions : IEnumerable<Transition>
	{
		[SerializeField] private List<Transition> transitionList = null;

		public Transition this[int index]
		{
			get
			{
				return transitionList[index];
			}
		}

		public Transitions()
		{
			transitionList = new List<Transition>();
		}

		public void Clear()
		{
			transitionList.Clear();
		}

		public void Add( Transition transition )
		{
			transitionList.Add( transition );
		}

		public void Remove( Transition transition )
		{
			transitionList.Remove( transition );
		}

		public int RemoveAll( Transition transition )
		{
			return RemoveAll( t => t.From == transition.From && t.To == transition.To );
		}

		public int RemoveAll( Predicate<Transition> match )
		{
			return transitionList.RemoveAll( match );
		}

		public IEnumerator<Transition> GetEnumerator()
		{
			return transitionList.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}

	/// <summary>
	/// ‘JˆÚ
	/// </summary>
	[Serializable]
	public class Transition
	{
		[SerializeField, HideInInspector] private StateNode from = null;
		[SerializeField, HideInInspector] private StateNode to = null;

		public StateNode From => @from;

		public StateNode To => to;

		public( StateNode from, StateNode to ) FromTo => ( @from, to );

		public Transition( StateNode from, StateNode to )
		{
			this.@from = from;
			this.to = to;
		}
	}
}
