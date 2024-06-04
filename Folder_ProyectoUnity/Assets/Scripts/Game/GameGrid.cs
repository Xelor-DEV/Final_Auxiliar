using UnityEngine;
public class GameGrid : MonoBehaviour
{
    [SerializeField] private GameObject slabPrefab;
    [SerializeField] private GameObject[,] slabs;
    [SerializeField] private Robot[,] robots;
    [SerializeField] private int length;
    [SerializeField] private int width;
    [SerializeField] private Transform startPosition;
    [SerializeField] private float spacingX;
    [SerializeField] private float spacingY;
    void Start()
    {
        InitializeGrid();
        GenerateSlabs();
    }
    void InitializeGrid()
    {
        slabs = new GameObject[length, width];
        robots = new Robot[length, width];
    }
    void GenerateSlabs()
    {
        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Vector3 position = new Vector3(startPosition.position.x + (spacingX * j), startPosition.position.y, startPosition.position.z + (spacingY * i));
                GameObject slab = Instantiate(slabPrefab, position, Quaternion.identity);
                SlabController slabComponent = slab.GetComponent<SlabController>();
                if (slabComponent != null)
                {
                    slabComponent.XIndex = i;
                    slabComponent.YIndex = j;
                    slabComponent.GameGrid = this;
                }
                slabs[i, j] = slab;
            }
        }
    }
    public void PlaceRobotAt(int xIndex, int yIndex)
    {
        if (robots[xIndex, yIndex] == null && PlayerController.Instance.Current != null)
        {
            Vector3 position = slabs[xIndex, yIndex].transform.position;
            GameObject robotGO = Instantiate(PlayerController.Instance.Current.RobotPrefab, position, Quaternion.identity);
            Robot robotComponent = robotGO.GetComponent<Robot>();
            robots[xIndex, yIndex] = robotComponent;
        }
    }

}
