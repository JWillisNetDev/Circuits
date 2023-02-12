using Circuits.Engine.IO;

namespace Circuits.Engine.Tests
{
	[TestClass]
	public class IOCollectionsTests
	{
		public InputCollection Inputs;
		public OutputCollection Outputs;
		
		[TestInitialize]
		public void TestInit()
		{
			Inputs = new InputCollection();
			Outputs = new OutputCollection();
		}

		[TestMethod]
		public void InputCollection_AddAndGetPort_ReturnsPort()
		{
			const int value = 42;
			Input<int> inputCreate, inputGet;

			inputCreate = Inputs.CreatePort<int>(value);
			inputGet = Inputs.GetPort<int>(inputCreate);

			Assert.AreEqual<Input<int>>(inputCreate, inputGet);
		}

		[TestMethod]
		public void InputCollection_AddAndGetValue_ReturnsValue()
		{
			const int value = 1337;
			Input<int> inputCreate;
			int inputGet;

			inputCreate = Inputs.CreatePort<int>(value);
			inputGet = Inputs.GetValue<int>(inputCreate);

			Assert.AreEqual(inputGet, value);
		}
	}
}