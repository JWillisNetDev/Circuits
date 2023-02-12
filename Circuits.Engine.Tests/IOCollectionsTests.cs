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
		public void InputCollection_AddAndTryGet_ReturnsObject()
		{
			const int value = 1337;
			Guid id;
			object output;
			bool success;

			id = Inputs.Add(value);
			success = Inputs.TryGetValue(id, out output);

			Assert.IsTrue(success);
			Assert.AreEqual<int>(value, (int) output);
		}

		[TestMethod]
		public void InputCollection_AddAndTryGetValue_ReturnsGeneric()
		{
			const int value = 42;
			Guid id;
			int output;
			bool success;

			id = Inputs.Add(value);
			success = Inputs.TryGetValue<int>(id, out output);

			Assert.IsTrue(success);
			Assert.AreEqual<int>(value, output);
		}

		[TestMethod]
		public void InputCollection_AddAndGetValue_ReturnsGeneric()
		{
			const int value = 42; 
			Guid id;
			int output;

			id = Inputs.Add(value);
			output = Inputs.GetValue<int>(id);

			Assert.AreEqual<int>(value, output);
		}

		[TestMethod]
		public void InputCollection_GetValue_StoresManyDifferentTypes()
		{
			const int intVal = 42;
			const char charVal = 'E';
			const string stringVal = "Hello, world!";
			Guid guidVal = Guid.NewGuid();
			Guid intId, charId, stringId, guidId;

			intId = Inputs.Add(intVal);
			charId = Inputs.Add(charVal);
			stringId = Inputs.Add(stringVal);
			guidId = Inputs.Add(guidVal);

			Assert.AreEqual<int>(Inputs.GetValue<int>(intId), intVal);
			Assert.AreEqual<char>(Inputs.GetValue<char>(charId), charVal);
			Assert.AreEqual<string>(Inputs.GetValue<string>(stringId), stringVal);
			Assert.AreEqual<Guid>(Inputs.GetValue<Guid>(guidId), guidVal);
		}

		[TestMethod]
		public void InputCollection_GetValueOrDefault_ReturnsValue()
		{
			const int value = 42;
			int? output = null;
			Guid id;

			id = Inputs.Add(value);
			output = Inputs.GetValueOrDefault<int>(id);

			Assert.IsTrue(output.HasValue);
			Assert.AreEqual<int>(output.Value, value);
		}

		[TestMethod]
		public void InputCollection_GetValueOrDefault_ReturnsDefault()
		{
			int? output = null;
			Guid id = Guid.NewGuid();

			output = Inputs.GetValueOrDefault<int?>(id);

			Assert.IsNull(output);
		}

		[TestMethod]
		public void InputCollection_GetValueOrDefault_ReturnsOverrideDefault()
		{
			const int defaultValue = 1234;
			int output;
			Guid id = Guid.NewGuid();

			output = Inputs.GetValueOrDefault<int>(id, defaultValue);

			Assert.AreEqual<int>(output, defaultValue);
		}

		[TestMethod]
		public void InputCollection_ContainsId_ReturnsTrue()
		{
			const int value = 420;
			Guid id;
			bool exists = false;

			id = Inputs.Add(value);
			exists = Inputs.Contains(id);

			Assert.IsTrue(exists);
		}

		[TestMethod]
		public void InputCollection_ContainsId_ReturnsFalse()
		{
			Guid id = Guid.NewGuid();
			bool exists = true;

			exists = Inputs.Contains(id);

			Assert.IsFalse(exists);
		}

		[TestMethod]
		public void InputCollection_GetActualInput_ReturnsInput()
		{
			string value = "Hello, world!";
			Guid id;
			Input<string>? input = null;

			id = Inputs.Add(value);
			input = Inputs.GetInput<Input<string>>(id);

			Assert.IsNotNull(input);
			Assert.AreEqual<string>(value, input.Value);
		}

		[TestMethod]
		public void InputCollection_RemoveInput_ReturnsTrue()
		{

		}
	}
}