public class Pack
{
	public int MaxItems { get; private set; }
	public int TotalItems { get; private set; } = 0;
	public float InventoryMass { get; private set; }
	public float InventoryVolume { get; private set; }
	public float MassMax { get; private set; }
	public float VolumeMax { get; private set; }

	public InventoryItem[] Items {  get; private set; }

	public Pack(int maxItems, float maxMass, float maxVol)
	{
		MaxItems = maxItems;
		MassMax = maxMass;
		VolumeMax = maxVol;

		Items = new InventoryItem[MaxItems];
	}

	public bool AddInventoryItem(InventoryItem item)
	{
		float itemMass = item.Mass;
		float itemVol = item.Volume;

		if (InventoryMass + itemMass > MassMax)
		{
			return false;
		}
		if (InventoryVolume + itemVol > VolumeMax)
		{
			return false;
		}

		for (int i = 0; i < Items.Length; i++)
		{
			if (Items[i] == null)
			{
				Items[i] = item;
				InventoryMass += itemMass;
				InventoryVolume += itemVol;

				TotalItems += 1;

				return true;
			}
		}

		return false;
	}
}
