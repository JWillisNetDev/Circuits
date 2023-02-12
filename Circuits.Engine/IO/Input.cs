using Circuits.Engine.Internal;

namespace Circuits.Engine.IO;

public interface IInput : IPort
{
}

public interface IInput<out TValue> : IInput, IPort<TValue>
{
}

public class Input<TValue> : Entity, IInput<TValue>, IUpdateable
{
	public TValue Value { get; protected set; }

	public Output<TValue>? ConnectedOutput { get; protected set; }
	
	object? IPort.Value => Value;

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