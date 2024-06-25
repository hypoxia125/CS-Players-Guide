public class InventoryItem
{
	public float Mass {  get; private set; }
	public float Volume { get; private set; }

	public InventoryItem(float mass, float volume)
	{
		Mass = mass;
		Volume = volume;
	}
}
