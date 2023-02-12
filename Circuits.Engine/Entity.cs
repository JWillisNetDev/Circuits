namespace Circuits.Engine;

public abstract class Entity
{
	private readonly Guid _id;
	public Guid Id => _id;

	protected Entity()
	{
		_id = Guid.NewGuid();
	}
}