﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DungeonMart.Characters.API.Models
{
	public class BaseCharacterViewModel
	{
		public Guid CharacterID { get; set; }
		public string CharacterName { get; set; }
		public GameSystem System { get; set; }
		public bool IsShared { get; set; }
	}

	public enum GameSystem
	{
		Dnd35,
		Dnd5
	}
}