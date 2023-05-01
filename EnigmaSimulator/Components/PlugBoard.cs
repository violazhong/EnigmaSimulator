using System;
using System.Collections.Generic;
using System.Linq;

namespace EnigmaSimulator.Components
{
	public class PlugBoard
	{
		public List<char> Alphabets;
		private readonly int MaxWireNums;
		private Dictionary<char, char> WireMap;

		public PlugBoard(List<char> alphabets, int maxWireNums)
		{
			Alphabets = alphabets;
			MaxWireNums = maxWireNums;
			WireMap = new Dictionary<char, char>();
		}

        public char Process(char alphabet)
        {
	        if (!Alphabets.Contains(alphabet))
	        {
		        throw new InvalidDataException($"Invalid input not included in alphabets: {alphabet}");
	        }
	        if (WireMap.TryGetValue(alphabet, out var result))
	        {
		        return result;
	        }

	        return alphabet;
        }

		public void Wire(char char1, char char2)
		{
			if (!Alphabets.Contains(char1) || !Alphabets.Contains(char2))
			{
				throw new InvalidDataException($"Invalid input not included in alphabets: {char1}, {char2}");
			}

			if (!ValidateWire(char1, char2))
			{
				throw new InvalidDataException($"Invalid wire operation: {char1}, {char2}");
			}

			WireMap.Add(char1, char2);
			WireMap.Add(char2, char1);

		}

		private bool ValidateWire(char char1, char char2)
		{
			if (char1.Equals(char2))
			{
				return false; // a char can't be wired to itself
			}

			if (WireMap.ContainsKey(char1) && WireMap.ContainsKey(char2))
			{
				return WireMap[char1].Equals(char2) && WireMap[char2].Equals(char1); // allows for the exact same wire
			}
			
			if (WireMap.Keys.Count >= 2 * MaxWireNums)
			{
				return false; // max wire numbers, when same wire is triggered twice, it won't check maxWires
			}

			return !WireMap.ContainsKey(char1) || !WireMap.ContainsKey(char2); // no char could be wired twice
		}
    }
}

