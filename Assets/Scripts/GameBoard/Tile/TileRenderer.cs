using System.Collections.Generic;
using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(
        typeof(Renderer), 
        typeof(Animator))]
    public class TileRenderer : Component
    {
        private Renderer _renderer;
        private Animator _animator;
        private static readonly int Color1 = Shader.PropertyToID("_Color");

        public void SetUp()
        {
            _renderer = GetComponent<Renderer>();
            _animator = GetComponent<Animator>();
        }
        
        public void IsWall()
        {
            _renderer.material.SetColor(Color1, Color.black);
        }
        
        public void WrongAnim()
        {
            _renderer.material.SetColor(Color1, Color.red);
        }

        public void SwitchAnim()
        {
            _renderer.material.SetColor(Color1, Color.yellow);
        }
    }
}