using System;
using System.Collections.Generic;
using GameBoard.Tile;
using Script.GameBoard;
using UnityEngine;

namespace GameBoard
{
    public class GameBoardController : MonoBehaviour
    {
        public GoodTileController goodTilePrefab;
        public BadTileController badTilePrefab;
        public float offset = 0.1f;
        public GameBoardStats gameBoardStats;
        public Vector2 baseSize;

        public readonly List<List<TileBase>> TileMatrix = new List<List<TileBase>>();

        public void Populate(IsSelectedDelegate selectionMethod)
        {
            float calculatedSizeX = (baseSize.x - (gameBoardStats.size.x - 1) * offset) / gameBoardStats.size.x;
            float calculatedSizeY = (baseSize.y - (gameBoardStats.size.y - 1) * offset) / gameBoardStats.size.y;
            for (var i = 0; i < gameBoardStats.size.x; i++)
            {
                TileMatrix.Add(new List<TileBase>());
                for (var j = 0; j < gameBoardStats.size.y; j++)
                {
                    var position = new Vector3(
                        i * calculatedSizeX + i * offset,
                        transform.position.y,
                        j * calculatedSizeY + j * offset);
                    
                    if (gameBoardStats.Board[i][j] >= 0)
                    {
                        BadTileController tile = Instantiate(badTilePrefab, Vector3.zero, Quaternion.identity);
                        tile.myNumber = gameBoardStats.Board[i][j];
                        tile.transform.position = position;
                        TileMatrix[i].Add(tile);
                        tile.name = "Tile " + i + " " + j;
                    }
                    else
                    {
                        GoodTileController tile = Instantiate(goodTilePrefab, Vector3.zero, Quaternion.identity);
                        tile.OnSelect += selectionMethod;
                        tile.transform.position = position;
                        TileMatrix[i].Add(tile);
                        tile.name = "Tile " + i + " " + j;
                    }
                }
            }

            CalculateNeighbours();
        }

        private void CalculateNeighbours()
        {
            for (var i = 0; i < gameBoardStats.size.x; i++)
            for (var j = 0; j < gameBoardStats.size.y; j++)
            {
                TileMatrix[i][j].neighbours
                    .Add(TileMatrix[(int) ((i + 1) % gameBoardStats.size.x)][(int) (j % gameBoardStats.size.y)]);
                TileMatrix[i][j].neighbours
                    .Add(TileMatrix[(int) (Math.Abs(i - 1) % gameBoardStats.size.x)][
                        (int) (j % gameBoardStats.size.y)]);
                TileMatrix[i][j].neighbours
                    .Add(TileMatrix[(int) (i % gameBoardStats.size.x)][
                        (int) (Math.Abs(j - 1) % gameBoardStats.size.y)]);
                TileMatrix[i][j].neighbours
                    .Add(TileMatrix[(int) (i % gameBoardStats.size.x)][(int) ((j + 1) % gameBoardStats.size.y)]);
            }
        }

        public void LightOnAt(Vector2 selectedTilePosition)
        {
            int baseX = (int) selectedTilePosition.x;
            int baseY = (int) selectedTilePosition.y;

            for (int x = baseX + 1; x <= gameBoardStats.size.x; x++)
                if (!TileMatrix[x][baseY].LightOn())
                    break;

            for (int x = baseX - 1; x >= 0; x--)
                if (!TileMatrix[x][baseY].LightOn())
                    break;

            for (int y = baseY + 1; y <= gameBoardStats.size.y; y++)
                if (!TileMatrix[baseX][y].LightOn())
                    break;

            for (int y = baseY - 1; y >= 0; y--)
                if (!TileMatrix[baseX][y].LightOn())
                    break;
        }

        public void LightOffAt(Vector2 selectedTilePosition)
        {
            int baseX = (int) selectedTilePosition.x;
            int baseY = (int) selectedTilePosition.y;

            for (int x = baseX + 1; x <= gameBoardStats.size.x; x++)
                if (!TileMatrix[x][baseY].LightOff())
                    break;

            for (int x = baseX - 1; x >= 0; x--)
                if (!TileMatrix[x][baseY].LightOff())
                    break;

            for (int y = baseY + 1; y <= gameBoardStats.size.y; y++)
                if (!TileMatrix[baseX][y].LightOff())
                    break;

            for (int y = baseY - 1; y >= 0; y--)
                if (!TileMatrix[baseX][y].LightOff())
                    break;
        }
    }
}