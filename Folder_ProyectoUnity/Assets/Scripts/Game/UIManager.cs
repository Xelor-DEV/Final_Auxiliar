using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private GameObject robotCardPrefab;
    private void OnEnable()
    {
        playerInventory.OnInventoryUpdated += UpdateDisplayedRobots;
    }
    private void OnDisable()
    {
        playerInventory.OnInventoryUpdated -= UpdateDisplayedRobots;
    }
    private void UpdateDisplayedRobots(int start)
    {
        for (int i = 0; i < gridLayoutGroup.transform.childCount; ++i)
        {
            GameObject child = gridLayoutGroup.transform.GetChild(i).gameObject;
            Destroy(child);
        }
        for (int i = 0; i < playerInventory.DisplayedRobots.Length; ++i)
        {
            RobotCard robot = playerInventory.DisplayedRobots[i];
            if (robot != null)
            {
                GameObject robotCard = Instantiate(robotCardPrefab, gridLayoutGroup.transform);
                RobotCardController robotCardController = robotCard.GetComponent<RobotCardController>();
                robotCardController.SetData(robot, start + i);
            }
        }
    }
}