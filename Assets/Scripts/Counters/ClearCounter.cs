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
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    // Player is holding a Plate
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }
                }
                else
                {
                    // Player is not carrying Plate but something else
                    if (GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        // Counter is holding a Plate
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO())) 
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }
            }
            else
            {
                // Player not carrying anything
                base.GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
}
