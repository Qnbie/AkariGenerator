using System.Collections.Generic;
using UnityEngine;

namespace GameBoard.Tile
{
    [RequireComponent(
        typeof(MeshRenderer), 
        typeof(Animator))]
    public class TileRenderer : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private Animator _animator;
        private static readonly int Color1 = Shader.PropertyToID("_Color");

        public void SetUp()
        {
            _renderer = GetComponent<MeshRenderer>();
            _animator = GetComponent<Animator>();
        }

        public void WrongAnim()
        {
            Debug.Log("meh");
        }

        public void TurnOn()
        {
            _renderer.material.SetColor(Color1, Color.yellow);
        }
        
        public void TurnOff()
        {
            _renderer.material.SetColor(Color1, Color.white);
        }
    }
}