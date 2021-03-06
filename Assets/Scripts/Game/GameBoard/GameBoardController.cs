using System;
using System.Collections.Generic;
using Game.GameBoard.Tile;
using UnityEngine;
using Utils.DataStructures;

namespace Game.GameBoard
{
    public class GameBoardController : MonoBehaviour
    {
        public GoodTileController goodTilePrefab;
        public BadTileController badTilePrefab;
        public float offset = 1f;
        public Puzzle MyPuzzle;
        public Vector2 baseSize = new Vector2(10, 10);

        public readonly List<List<TileBase>> TileMatrix = new List<List<TileBase>>();

        public void Populate(Puzzle puzzle, IsSelectedDelegate onSelection)
        {
            
            float calculatedSizeX = (baseSize.x - (MyPuzzle.SizeX() - 1) * offset) / MyPuzzle.SizeX();
            float calculatedSizeY = (baseSize.y - (MyPuzzle.SizeY() - 1) * offset) / MyPuzzle.SizeY();
            for (var i = 0; i < MyPuzzle.SizeX(); i++)
            {
                TileMatrix.Add(new List<TileBase>());
                for (var j = 0; j < MyPuzzle.SizeY(); j++)
                {
                    var position = new Vector3(
                        i * calculatedSizeX + i * offset,
                        j * calculatedSizeY + j * offset,
                        transform.position.z);
                    
                    if (MyPuzzle.PuzzleMatrix[i][j] >= 0 && (int)MyPuzzle.PuzzleMatrix[i][j] <= 5)
                    {
                        BadTileController tile = Instantiate(badTilePrefab, Vector3.zero, Quaternion.identity);
                        tile.MyNumber = (int) MyPuzzle.PuzzleMatrix[i][j];
                        tile.transform.position = position;
                        tile.name = "Tile " + i + " " + j;
                        tile.position = new Vector2(i, j);
                        TileMatrix[i].Add(tile);
                    }
                    else
                    {
                        GoodTileController tile = Instantiate(goodTilePrefab, Vector3.zero, Quaternion.identity);
                        tile.OnSelect += onSelection;
                        tile.transform.position = position;
                        tile.name = "Tile " + i + " " + j;
                        tile.position = new Vector2(i, j);
                        TileMatrix[i].Add(tile);
                    }
                }
            }

            CalculateNeighbours();
        }

        private void CalculateNeighbours()
        {
            for (var i = 0; i < MyPuzzle.SizeX(); i++)
            for (var j = 0; j < MyPuzzle.SizeY(); j++)
            {
                if(i + 1 < MyPuzzle.SizeX())
                    TileMatrix[i][j].neighbours
                        .Add(TileMatrix[ (i + 1) % MyPuzzle.SizeX()][j % MyPuzzle.SizeY()]);
                
                if (j + 1 < MyPuzzle.SizeY()) 
                    TileMatrix[i][j].neighbours
                        .Add(TileMatrix[ i % MyPuzzle.SizeX()][(j + 1) % MyPuzzle.SizeY()]);
                
                if (i-1 >= 0)
                    TileMatrix[i][j].neighbours
                        .Add(TileMatrix[ Math.Abs(i - 1) % MyPuzzle.SizeX()][j % MyPuzzle.SizeY()]);
                
                if (j-1 >= 0)
                    TileMatrix[i][j].neighbours
                        .Add(TileMatrix[ i % MyPuzzle.SizeX()][Math.Abs(j - 1) % MyPuzzle.SizeY()]);
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
                if (!isStop[0] && baseX + 1 + index < MyPuzzle.SizeX())
                {
                    if (!TileMatrix[baseX + 1 + index][baseY].LightOn())
                        isStop[0] = true;
                }
                else isStop[0] = true;

                if (!isStop[1] && baseY + 1 + index < MyPuzzle.SizeY())
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
            var baseX = (int) selectedTilePosition.x;
            var baseY = (int) selectedTilePosition.y;
            var flags = new bool[4];
            var index = 0;
            while (!(flags[0] & flags[1] & flags[2] & flags[3]))
            {
                if (!flags[0] && baseX + 1 + index < MyPuzzle.SizeX())
                {
                    if (!TileMatrix[baseX + 1 + index][baseY].LightOff()) flags[0] = true;
                }
                else flags[0] = true;

                if (!flags[1] && baseY + 1 + index < MyPuzzle.SizeY())
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