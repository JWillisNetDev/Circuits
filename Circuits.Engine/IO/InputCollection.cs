using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;

namespace Circuits.Engine.IO;

public class InputCollection : PortCollectionBase<IInput>
{
	public InputCollection() : base()
	{
	}

	public override Input<TValue?> CreatePort<TValue>(TValue? defaultValue = default)
		where TValue : default
	{
		Input<TValue?> input = new(defaultValue);
		Add(input);
		return input;
	}

	public override Input<TValue> GetPort<TValue>(IEntity entity)
		=> (Input<TValue>)this[entity];

	public override TValue GetValue<TValue>(IEntity entity)
	{
		Input<TValue> input = (Input<TValue>)GetPort(entity);
		return input.Value;
	}
}

/// <summary>
///		Agnostic-type Input Collection
/// </summary>
/*
public class InputCollection
{
	private readonly Dictionary<Guid, IInput> _inputs;

	public InputCollection()
	{
		_inputs = new Dictionary<Guid, IInput>();
	}

	public Guid Add<TValue>(TValue defaultValue)
	{
		Input<TValue> newInput = new(defaultValue);
		_inputs.Add(newInput.Id, newInput);
		return newInput.Id;
	}

	public bool Remove(Guid id)
		=> _inputs.Remove(id);

	public void Clear()
		=> _inputs.Clear();

	public bool Contains(Guid id)
		=> _inputs.ContainsKey(id);

	public bool Contains<TInput>(TInput input)
		where TInput : IInput
		=> _inputs.ContainsValue(input);

	internal IInput GetInput(Guid id)
		=> _inputs[id];

	public TInput GetInput<TInput>(Guid id)
		where TInput : IInput
	{
		return (TInput) _inputs[id];
	}

	public bool TryGetValue(Guid id, [MaybeNullWhen(false)] out object? value)
	{
		value = null;

		if (!_inputs.ContainsKey(id))
			return false;

		value = _inputs[id].Value;
		return true;
	}

	public bool TryGetValue<TValue>(Guid id, [MaybeNullWhen(false)] out TValue? value)
	{
		value = default;

		if (!_inputs.ContainsKey(id))
			return false;

		Input<TValue>? input = _inputs[id] as Input<TValue>;
		if (input is null)
			return false;

		value = input.Value;
		return true;
	}

	public TValue GetValue<TValue>(Guid id)
	{
		Input<TValue> input = (Input<TValue>) _inputs[id];
		return input.Value;
	}

	public TValue? GetValueOrDefault<TValue>(Guid id, TValue defaultValue = default)
	{
		bool success = TryGetValue(id, out TValue? value);
		return success ? value : defaultValue;
	}
}
*/