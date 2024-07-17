using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace Content.Scripts
{
    public class MeshFlash : MonoBehaviour
    {
        [SerializeField] private Renderer[] renderers;
        [SerializeField] private Color color;
        [SerializeField] private int blinkCount;
        [SerializeField] private float blinkDelay;
        [SerializeField] private float blinkDuration;
    
        private bool _isBlink;
    
        private static readonly int s_Color = Shader.PropertyToID("_BaseColor");

        public void Blink()
        {
            if(_isBlink) return;
            
            StartCoroutine(BlinkCor());
        }

        private IEnumerator BlinkCor()
        {
            _isBlink = true;
            int temp = 0;
        
            while (temp<blinkCount)
            {
                for (int i = 0; i < renderers.Length; i++)
                {
                    for (int j = 0; j < renderers[i].materials.Length; j++)
                    {
                        renderers[i].materials[j].DOColor(color,s_Color,blinkDuration);
                    }
                }

                yield return new WaitForSeconds(blinkDelay+blinkDuration);
        
                for (int i = 0; i < renderers.Length; i++)
                {
                    for (int j = 0; j < renderers[i].materials.Length; j++)
                    {
                        renderers[i].materials[j].DOColor(Color.white, s_Color,blinkDuration);
                    }
                }
                temp++;
            }
            _isBlink = false;
        }
    }
}
