using Circuits.Engine.Internal;

namespace Circuits.Engine.IO;

public interface IInput
{
	object? Value { get; }
}

public class Input<TValue> : Entity, IInput, IUpdateable
{
	public TValue Value { get; protected set; }

	public Output<TValue>? ConnectedOutput { get; protected set; }
	
	object? IInput.Value => Value;

	public Input(TValue defaultValue) : base()
	{
		Value = defaultValue;
		ConnectedOutput = null;
	}

	public void Attach(Output<TValue> output)
	{
	}

	public void Detatch()
	{
	}

	void IUpdateable.Update()
	{
	}
}