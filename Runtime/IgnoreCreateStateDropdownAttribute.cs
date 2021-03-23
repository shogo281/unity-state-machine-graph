using System;

namespace KStateMachine
{
	/// <summary>
	/// Create stateのDropdownメニューに表示させないようにするアトリビュート
	/// </summary>
	[AttributeUsage( AttributeTargets.Class )]
	public class IgnoreCreateStateDropdownAttribute : Attribute
	{
	}
}
