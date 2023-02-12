namespace Circuits.Engine;

public interface IEntity
{
	public Guid Id { get; }
}

public abstract class Entity : IEntity
{
	private readonly Guid _id;
	public Guid Id => _id;

	protected Entity()
	{
		_id = Guid.NewGuid();
	}
}