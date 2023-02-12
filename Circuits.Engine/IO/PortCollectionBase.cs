using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circuits.Engine.IO;

public interface IPort : IEntity
{
	object? Value { get; }
}
public interface IPort<out TValue> : IPort
{
	new TValue? Value { get; }
}

public abstract class PortCollectionBase<TPort> : ICollection<TPort>
	where TPort : IPort
{
	private readonly Dictionary<Guid, TPort> _portMap;

	public int Count => _portMap.Count;

	public bool IsReadOnly => false;

	protected PortCollectionBase()
	{
		_portMap = new Dictionary<Guid, TPort>();
	}

	public virtual TPort this[IEntity entity]
		=> GetPort(entity);

	public virtual IEnumerable<TPort> GetPorts()
		=> _portMap.Values;

	protected virtual TPort GetPort(IEntity entity)
		=> _portMap[entity.Id];

	#region Abstract Method Definitions
	public abstract IPort<TValue?> CreatePort<TValue>(TValue? defaultValue = default);
	public abstract IPort<TValue> GetPort<TValue>(IEntity entity);
	public abstract TValue GetValue<TValue>(IEntity entity);
	#endregion

	#region Implements ICollection Methods
	public virtual void Add(TPort item)
	{
		if (_portMap.ContainsKey(item.Id))
			throw new ArgumentException($"Attempted to add entity of duplicate ID key `{item.Id}` to PortCollection.");
		_portMap[item.Id] = item;
	}

	public virtual void Clear()
		=> _portMap.Clear();

	public virtual bool Contains(TPort item)
		=> _portMap.ContainsValue(item);

	public virtual void CopyTo(TPort[] array, int arrayIndex)
		=> _portMap.Values.CopyTo(array, arrayIndex);

	public virtual IEnumerator<TPort> GetEnumerator()
		=> _portMap.Values.GetEnumerator();

	public virtual bool Remove(TPort item)
		=> _portMap.Remove(item.Id);

	IEnumerator IEnumerable.GetEnumerator()
		=> ((IEnumerable)_portMap.Values).GetEnumerator();
	#endregion
}