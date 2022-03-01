using System;
using System.IO;
using mis321_pa2_cacook7;
using mis321_pa2_cacook7.Interfaces;

namespace mis321_pa2_cacook7
{
	public class Character
	{
		public string name {get; set;}
		public int characterType {get; set;}
		public double maxPower {get; set;}
		public double health {get; set;}
		public double attackPower {get; set;}
		public double defensivePower {get; set;}
		public bool Taken {get; set;}
		public IAttack attackBehavior {get; set;}
		
		public Character()
		
		{
			attackBehavior = new DistractAttack();
		}
		
		public override string ToString()
		
		{
			return $"{this.name} has a max power of {this.maxPower}, a health of {this.health}, an attack power of {this.attackPower}, and a defensive power of {this.defensivePower}";
		}
	}
}