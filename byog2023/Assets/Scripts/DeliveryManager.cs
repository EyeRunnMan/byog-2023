using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance;

    [SerializeField]
    Tray TrayPrefab;

    [SerializeField]
    Transform FlipperRefrence;

    [SerializeField]
    Transform TrayTransformParent;

    Tray _trayRefrence;

    bool isLookingForward;

    [ContextMenu("Flip player")]
    public void FlipDeliveryManager()
    {
        if (isLookingForward)
        {
            transform.forward = FlipperRefrence.forward;
        }
        else
        {
            transform.forward = -FlipperRefrence.forward;
        }

        isLookingForward = !isLookingForward;
    }

    private void Awake()
    {
        ResetFlip();
        Instance = this;
    }

    private void ResetFlip()
    {
        transform.forward = FlipperRefrence.forward;
        isLookingForward = true;
    }

    public void AddToTray(FoodItem foodItem)
    {
        if(_trayRefrence == null)
        {
            return;
        }

        if (ResourceManager.Instance.FoodItemSO.GetGameObject(foodItem) != null)
        {
            _trayRefrence.AddToTray(ResourceManager.Instance.FoodItemSO.GetGameObject(foodItem),foodItem);
        }
    }

    [ContextMenu("spawn new Tray")]
    public void GetNewTrayInHand()
    {
        _trayRefrence = Instantiate(TrayPrefab, TrayTransformParent);
        _trayRefrence.transform.localPosition = Vector3.zero;
    }

}
