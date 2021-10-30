using System;
using System.Collections.Generic;
using GameBoard.Tile;
using UnityEngine;
using Utils.DataStructures;
using Utils.Enums;

namespace GameBoard
{
    public class GameBoardController : MonoBehaviour
    {
        public GoodTileController goodTilePrefab;
        public BadTileController badTilePrefab;
        public float offset = 1f;
        public Puzzle puzzle;
        public Vector2 baseSize = new Vector2(10, 10);

        public readonly List<List<TileBase>> TileMatrix = new List<List<TileBase>>();

        public void Populate(IsSelectedDelegate onSelection)
        {
            float calculatedSizeX = (baseSize.x - (puzzle.SizeX() - 1) * offset) / puzzle.SizeX();
            float calculatedSizeY = (baseSize.y - (puzzle.SizeY() - 1) * offset) / puzzle.SizeY();
            for (var i = 0; i < puzzle.SizeX(); i++)
            {
                TileMatrix.Add(new List<TileBase>());
                for (var j = 0; j < puzzle.SizeY(); j++)
                {
                    var position = new Vector3(
                        i * calculatedSizeX + i * offset,
                        j * calculatedSizeY + j * offset,
                        this.transform.position.z);
                    
                    if (puzzle.PuzzleMatrix[i][j] >= 0 && (int)puzzle.PuzzleMatrix[i][j] <= 5)
                    {
                        BadTileController tile = Instantiate(badTilePrefab, Vector3.zero, Quaternion.identity);
                        tile.MyNumber = (int) puzzle.PuzzleMatrix[i][j];
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
            for (var i = 0; i < puzzle.SizeX(); i++)
            for (var j = 0; j < puzzle.SizeY(); j++)
            {
                if(i + 1 < puzzle.SizeX())
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) ((i + 1) % puzzle.SizeX())][(int) (j % puzzle.SizeY())]);
                
                if (j + 1 < puzzle.SizeY()) 
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) (i % puzzle.SizeX())][(int) ((j + 1) % puzzle.SizeY())]);
                
                if (i-1 >= 0)
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) (Math.Abs(i - 1) % puzzle.SizeX())][(int) (j % puzzle.SizeY())]);
                
                if (j-1 >= 0)
                    TileMatrix[i][j].Neighbours
                        .Add(TileMatrix[(int) (i % puzzle.SizeX())][(int) (Math.Abs(j - 1) % puzzle.SizeY())]);
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
                if (!isStop[0] && baseX + 1 + index < puzzle.SizeX())
                {
                    if (!TileMatrix[baseX + 1 + index][baseY].LightOn())
                        isStop[0] = true;
                }
                else isStop[0] = true;

                if (!isStop[1] && baseY + 1 + index < puzzle.SizeY())
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
                if (!flags[0] && baseX + 1 + index < puzzle.SizeX())
                {
                    if (!TileMatrix[baseX + 1 + index][baseY].LightOff()) flags[0] = true;
                }
                else flags[0] = true;

                if (!flags[1] && baseY + 1 + index < puzzle.SizeY())
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