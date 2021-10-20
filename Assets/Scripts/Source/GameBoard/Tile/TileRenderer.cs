using UnityEngine;

namespace Source.GameBoard.Tile
{
    [RequireComponent(
        typeof(MeshRenderer), 
        typeof(Animator))]
    public class TileRenderer : MonoBehaviour
    {
        private MeshRenderer _renderer;
        private Animator _animator;
        private TextMesh _textMesh;
        private static readonly int Color1 = Shader.PropertyToID("_Color");

        public void SetUp()
        {
            _renderer = GetComponent<MeshRenderer>();
            _animator = GetComponent<Animator>();
            _textMesh = GetComponentInChildren<TextMesh>();
        }

        public void NotAllowed()
        {
            _textMesh.color = Color.red;
        }
        
        public void Allowed()
        {
            _textMesh.color = Color.blue;
        }

        public void AddSelection()
        {
            _textMesh.text = "P";
        }
        
        public void RemoveSelection()
        {
            _textMesh.text = "";
        }
        
        public void TurnOn()
        {
            _renderer.material.SetColor(Color1, Color.yellow);
        }
        
        public void TurnOff()
        {
            _renderer.material.SetColor(Color1, Color.white);
        }

        public void SetNumber(int value)
        {
            _textMesh.text = value.ToString();
        }
    }
}