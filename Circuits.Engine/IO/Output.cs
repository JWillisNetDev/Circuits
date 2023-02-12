using Circuits.Engine.Internal;

namespace Circuits.Engine.IO;

public interface IOutput
{
	object? Value { get; }
}

public class Output<TValue> : Entity, IOutput, IUpdateable
{
	public TValue Value { get; protected set; }

	private readonly List<Input<TValue>> _connectedInputs;
	public IReadOnlyList<Input<TValue>> ConnectedInputs => _connectedInputs;

	object? IOutput.Value => Value;

	public Output(TValue defaultValue) : base()
	{
		Value = defaultValue;
		_connectedInputs = new List<Input<TValue>>();
	}

	public void Attach(Input<TValue> input)
	{
	}

	public void DetatchAll()
	{
	}

	public void Detatch(Input<TValue> input)
	{
	}

	void IUpdateable.Update()
	{
	}
}