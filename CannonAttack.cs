using mis321_pa2_cacook7.Interfaces;
using System;

namespace mis321_pa2_cacook7
{
	public class CannonAttack : IAttack
	{
		public string Attack()
		{
			return "You attacked with a canon fire!";
		}
	}
}