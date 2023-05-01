using System;
using System.Collections.Generic;
using EnigmaSimulator.Components;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnigmaSimulator.Test.Components
{
	[TestClass]
	public class PlugBoardTest
	{

        [TestMethod]
        public void Constructor_Works_Okay()
        {
	        var alphabets = new List<char> { 'A', 'B' };
	        var wireMax = 10;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        Assert.IsNotNull(plugBoard);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Process_InvalidAlphabet_RaiseInvalidDataException()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 1;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        plugBoard.Process('C');
        }

        [TestMethod]
        public void Process_UnwiredAlphabet_ReturnsItself()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 1;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        Assert.Equals('A', plugBoard.Process('A'));
        }

        [TestMethod]
        public void Process_WiredAlphabet_ReturnsCorrectValue()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 1;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        plugBoard.Wire('A','B');
	        Assert.Equals('A', plugBoard.Process('B'));
	        Assert.Equals('B', plugBoard.Process('A'));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Wire_InvalidAlphabet_RaiseInvalidDataException()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 1;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        plugBoard.Wire('C','D');
        }
        
        [TestMethod]
        public void Wire_ExactlySameWire_AllowForMultipleTimes()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 10;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        plugBoard.Wire('C','D');
	        plugBoard.Wire('D','C');
	        Assert.Equals('C', plugBoard.Process('D'));
	        Assert.Equals('D', plugBoard.Process('C'));
        }
        
        [TestMethod]
        public void Wire_ExactlySameWireMultipleTimes_DoesNotTriggerMaxWireCheck()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 1;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        plugBoard.Wire('C','D');
	        plugBoard.Wire('D','C');
	        Assert.Equals('C', plugBoard.Process('D'));
	        Assert.Equals('D', plugBoard.Process('C'));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Wire_ExceedsMaxWires_RaiseInvalidDataException()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 1;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        plugBoard.Wire('A','B');
	        plugBoard.Wire('Z','X');
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void Wire_DuplicateWires_RaiseInvalidDataException()
        {
	        var alphabets = new List<char> { 'A', 'B', 'Z', 'X'};
	        var wireMax = 5;
	        var plugBoard = new PlugBoard(alphabets, wireMax);
	        plugBoard.Wire('A', 'B');
	        plugBoard.Wire('A', 'Z');
        }
    }
}

