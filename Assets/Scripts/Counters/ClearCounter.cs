using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            // Counter is empty

            if (player.HasKitchenObject())
            {
                // Player has KitchenObject

                player.GetKitchenObject().SetKitchenObjectParent(this); // Player puts KitchenObject on this Counter
            }
            else
            {
                // Player not carrying anything
            }
        }
        else
        {
            // There is KitchenObject here

            if (player.HasKitchenObject())
            {
                // Player has KitchenObject
            }
            else
            {
                // Player not carrying anything
                base.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
