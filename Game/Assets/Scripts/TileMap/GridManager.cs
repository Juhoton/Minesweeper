using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridSize = 10;
    public int mineCount = 20;
    public GameObject tilePrefab;
    public Tile[,] grid;
    public Camera mainCamera;
    private bool isFirstClick = true;

    void Start()
    {
        GenerateGrid();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Tile tile = GetTileUnderCursor();
            if (tile != null)
            {
                HandleTileLeftClick(tile);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Tile tile = GetTileUnderCursor();
            if (tile != null)
            {
                HandleTileRightClick(tile);
            }
        }
    }

    public void GenerateGrid()
    {
        grid = new Tile[gridSize, gridSize];
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new Vector3(x - gridSize / 2, y - gridSize / 2, 0);
                GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity);
                Tile tile = tileObject.GetComponent<Tile>();

                tile.x = x;
                tile.y = y;

                grid[x, y] = tile;
            }
        }
    }

    // Random for now
    public void PlaceMines(int firstX, int firstY)
    {
        int placedMines = 0;

        while (placedMines < mineCount)
        {
            int x = Random.Range(0, gridSize);
            int y = Random.Range(0, gridSize);

            // Make tiles around first click safe
            if (Mathf.Abs(x - firstX) <= 1 && Mathf.Abs(y - firstY) <= 1)
                continue;

            if (!grid[x, y].isMine)
            {
                grid[x, y].isMine = true;
                placedMines++;
            }
        }
    }

    public int CountAdjacentMines(int x, int y)
    {
        int count = 0;

        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = x + dx;
                int ny = y + dy;

                if (dx == 0 && dy == 0)
                    continue;

                if (nx >= 0 && nx < gridSize && ny >= 0 && ny < gridSize)
                {
                    if (grid[nx, ny].isMine)
                        count++;
                }
            }
        }

        return count;
    }

    public void HandleTileLeftClick(Tile tile)
    {
        if (isFirstClick)
        {
            PlaceMines(tile.x, tile.y);
            isFirstClick = false;
            foreach (Tile gridTile in grid)
            {
                gridTile.adjacentMines = CountAdjacentMines(gridTile.x, gridTile.y);
            }
        }
        RevealTile(tile);
        foreach (Tile gridTile in grid)
        {
            ShowAdjacentMines(gridTile);
        }
    }

    public void RevealTile(Tile tile)
    {
        if (tile.isRevealed || tile.isFlagged)
            return;

        tile.Reveal();

        if (tile.adjacentMines == 0 && !tile.isMine)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = tile.x + dx;
                    int ny = tile.y + dy;

                    if (nx >= 0 && nx < gridSize && ny >= 0 && ny < gridSize)
                    {
                        RevealTile(grid[nx, ny]);
                    }
                }
            }
        }
    }

    public void HandleTileRightClick(Tile tile)
    {
        tile.Flag();
    }

    public Tile GetTileUnderCursor()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePos);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

        if (hit.collider != null)
        {
            return hit.collider.GetComponent<Tile>();
        }

        return null;
    }

    public void ShowAdjacentMines(Tile tile)
    {
        bool unrevealedTiles = false;
        for (int dx = -1; dx <= 1; dx++)
        {
            if (unrevealedTiles)
            {
                tile.ShowAdcjacentMines();
                return;
            }
            for (int dy = -1; dy <= 1; dy++)
            {
                int nx = tile.x + dx;
                int ny = tile.y + dy;

                if (dx == 0 && dy == 0)
                    continue;

                if (nx >= 0 && nx < gridSize && ny >= 0 && ny < gridSize)
                {
                    if (!grid[nx, ny].isRevealed && tile.isRevealed)
                    {
                        unrevealedTiles = true;
                    }
                }
            }
        }
        tile.HideAdjacentMines();
    }

}