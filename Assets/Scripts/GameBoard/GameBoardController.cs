using System;
using System.Collections.Generic;
using GameBoard.Tile;
using Script.GameBoard;
using UnityEngine;

namespace GameBoard
{
    public class GameBoardController : MonoBehaviour
    {
        public GoodTileController tilePrefab;
        public float offset = 0.1f;
        public GameBoardStats gameBoardStats;

        public readonly List<List<GoodTileController>> TileMatrix = new List<List<GoodTileController>>();

        public void Populate(IsSelectedDelegate selectionMethod)
        {
            for (var i = 0; i < gameBoardStats.size.x; i++)
            {
                TileMatrix.Add(new List<GoodTileController>());
                for (var j = 0; j < gameBoardStats.size.y; j++)
                {
                    var tile = Instantiate(tilePrefab, Vector3.zero, Quaternion.identity);
                    var position = new Vector3(
                        i * tile.MyTileRender.size.x + i * offset,
                        transform.position.y,
                        j * tile.MyTileRender.size.z + j * offset);
                    tile.transform.position = position;
                    TileMatrix[i].Add(tile);
                    tile.name = "Tile " + i + " " + j;
                    tile.OnSelect += selectionMethod;
                }
            }

            CalculateNeighbours();
        }

        private void CalculateNeighbours()
        {
            for (var i = 0; i < gameBoardStats.size.x; i++)
            for (var j = 0; j < gameBoardStats.size.y; j++)
            {
                TileMatrix[i][j].Neighbours
                    .Add(TileMatrix[(int) ((i + 1) % gameBoardStats.size.x)][(int) (j % gameBoardStats.size.y)]);
                TileMatrix[i][j].Neighbours
                    .Add(TileMatrix[(int) (Math.Abs(i - 1) % gameBoardStats.size.x)][
                        (int) (j % gameBoardStats.size.y)]);
                TileMatrix[i][j].Neighbours
                    .Add(TileMatrix[(int) (i % gameBoardStats.size.x)][
                        (int) (Math.Abs(j - 1) % gameBoardStats.size.y)]);
                TileMatrix[i][j].Neighbours
                    .Add(TileMatrix[(int) (i % gameBoardStats.size.x)][(int) ((j + 1) % gameBoardStats.size.y)]);
            }
        }

        public void LightUpAt(Vector2 selectedTilePosition)
        {
            int baseX = (int) selectedTilePosition.x;
            int baseY = (int) selectedTilePosition.y;

            for (int x = baseX + 1; x <= gameBoardStats.size.x; x++)
            {
                if (TileMatrix[x][baseY].IsSelectable)
                    TileMatrix[x][baseY].LightOn();
                else
                    break;
            }

            for (int x = baseX - 1; x >= 0; x--)
            {
                if (TileMatrix[x][baseY].IsSelectable)
                    TileMatrix[x][baseY].LightOn();
                else
                    break;
            }

            for (int y = baseY + 1; y <= gameBoardStats.size.y; y++)
            {
                if (TileMatrix[baseX][y].IsSelectable)
                    TileMatrix[baseX][y].LightOn();
                else
                    break;
            }

            for (int y = baseY - 1; y >= 0; y--)
            {
                if (TileMatrix[baseX][y].IsSelectable)
                    TileMatrix[baseX][y].LightOn();
                else
                    break;
            }
        }
    }
}