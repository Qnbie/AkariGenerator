using System;
using System.Collections.Generic;
using Enums;
using GameBoard.Tile;
using Script.GameBoard;
using UnityEngine;

namespace GameBoard
{
    public class GameBoardController : MonoBehaviour
    {
        public GoodTileController goodTilePrefab;
        public BadTileController badTilePrefab;
        public float offset = 1f;
        public GameBoardStats gameBoardStats;
        public Vector2 baseSize = new Vector2(10, 10);

        public readonly List<List<TileBase>> TileMatrix = new List<List<TileBase>>();

        private void Awake()
        {
            gameBoardStats = new GameBoardStats();
        }

        public void Populate(IsSelectedDelegate onSelection)
        {
            float calculatedSizeX = (baseSize.x - (gameBoardStats.Size.x - 1) * offset) / gameBoardStats.Size.x;
            float calculatedSizeY = (baseSize.y - (gameBoardStats.Size.y - 1) * offset) / gameBoardStats.Size.y;
            for (var i = 0; i < gameBoardStats.Size.x; i++)
            {
                TileMatrix.Add(new List<TileBase>());
                for (var j = 0; j < gameBoardStats.Size.y; j++)
                {
                    var position = new Vector3(
                        i * calculatedSizeX + i * offset,
                        j * calculatedSizeY + j * offset,
                        this.transform.position.z);
                    
                    if (gameBoardStats.Board[i,j] >= 0 && gameBoardStats.Board[i,j] <= (TileStates) 4)
                    {
                        BadTileController tile = Instantiate(badTilePrefab, Vector3.zero, Quaternion.identity);
                        tile.MyNumber = (int) gameBoardStats.Board[i,j];
                        tile.transform.position = position;
                        tile.name = "Tile " + i + " " + j;
                        tile.Position = new Vector2(i, j);
                        TileMatrix[i].Add(tile);
                    }
                    else
                    {
                        GoodTileController tile = Instantiate(goodTilePrefab, Vector3.zero, Quaternion.identity);
                        tile.OnSelect += onSelection;
                        tile.transform.position = position;
                        tile.name = "Tile " + i + " " + j;
                        tile.Position = new Vector2(i, j);
                        TileMatrix[i].Add(tile);
                    }
                }
            }

            CalculateNeighbours();
        }

        private void CalculateNeighbours()
        {
            for (var i = 0; i < gameBoardStats.Size.x; i++)
            for (var j = 0; j < gameBoardStats.Size.y; j++)
            {
                if(i + 1 < gameBoardStats.Size.x)
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) ((i + 1) % gameBoardStats.Size.x)][(int) (j % gameBoardStats.Size.y)]);
                
                if (j + 1 < gameBoardStats.Size.y) 
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) (i % gameBoardStats.Size.x)][(int) ((j + 1) % gameBoardStats.Size.y)]);
                
                if (i-1 >= 0)
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) (Math.Abs(i - 1) % gameBoardStats.Size.x)][(int) (j % gameBoardStats.Size.y)]);
                
                if (j-1 >= 0)
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) (i % gameBoardStats.Size.x)][(int) (Math.Abs(j - 1) % gameBoardStats.Size.y)]);
            }
        }

        public void LightOnAt(Vector2 selectedTilePosition)
        {
            int baseX = (int) selectedTilePosition.x;
            int baseY = (int) selectedTilePosition.y;
            bool[] isStop = new bool[4];
            int index = 0;
            while (!(isStop[0] & isStop[1] & isStop[2] & isStop[3]))
            {
                if (!isStop[0] && baseX + 1 + index < gameBoardStats.Size.x)
                {
                    if (!TileMatrix[baseX + 1 + index][baseY].LightOn())
                        isStop[0] = true;
                }
                else isStop[0] = true;

                if (!isStop[1] && baseY + 1 + index < gameBoardStats.Size.y)
                {
                    if (!TileMatrix[baseX][baseY + 1 + index].LightOn()) 
                        isStop[1] = true;
                }
                else isStop[1] = true;

                if (!isStop[2] && baseX - 1 - index >= 0)
                {
                    if (!TileMatrix[baseX - 1 - index][baseY].LightOn())
                        isStop[2] = true;
                }
                else isStop[2] = true;

                if (!isStop[3] && baseY - 1 - index >= 0)
                {
                    if (!TileMatrix[baseX][baseY - 1 - index].LightOn())
                        isStop[3] = true;
                }
                else isStop[3] = true;
                index++;
            }
        }
        
        public void LightOffAt(Vector2 selectedTilePosition)
        {
            int baseX = (int) selectedTilePosition.x;
            int baseY = (int) selectedTilePosition.y;
            bool[] flags = new bool[4];
            int index = 0;
            while (!(flags[0] & flags[1] & flags[2] & flags[3]))
            {
                if (!flags[0] && baseX + 1 + index < gameBoardStats.Size.x)
                {
                    if (!TileMatrix[baseX + 1 + index][baseY].LightOff()) flags[0] = true;
                }
                else flags[0] = true;

                if (!flags[1] && baseY + 1 + index < gameBoardStats.Size.y)
                {
                    if (!TileMatrix[baseX][baseY + 1 + index].LightOff()) flags[1] = true;
                }
                else flags[1] = true;

                if (!flags[2] && baseX - 1 - index >= 0)
                {
                    if (!TileMatrix[baseX - 1 - index][baseY].LightOff())
                        flags[2] = true;
                }
                else flags[2] = true;

                if (!flags[3] && baseY - 1 - index >= 0)
                {
                    if (!TileMatrix[baseX][baseY - 1 - index].LightOff())
                        flags[3] = true;
                }
                else flags[3] = true;
                index++;
            }
        }
    }
}