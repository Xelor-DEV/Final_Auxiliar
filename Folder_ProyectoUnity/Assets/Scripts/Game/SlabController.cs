using UnityEngine;
using UnityEngine.UI;
public class SlabController : MonoBehaviour
{
    [SerializeField] private int xIndex;
    [SerializeField] private int yIndex;
    [SerializeField] private GameGrid gameGrid;
    private Button button;
    public int XIndex
    {
        get
        {
            return xIndex;
        }
        set
        {
            xIndex = value;
        }
    }
    public int YIndex
    {
        get
        {
            return yIndex;
        }
        set
        {
            yIndex = value;
        }
    }
    public GameGrid GameGrid
    {
        get
        {
            return gameGrid;
        }
        set
        {
            gameGrid = value;
        }
    }
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    private void OnEnable()
    {
        if(button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }
    private void OnClick()
    {
        gameGrid.PlaceRobotAt(xIndex, yIndex);
    }
}
