using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Content.Scripts.PlayerScripts
{
    [Serializable]
    public class PlayerBar 
    {
        [SerializeField] private Image radiusCircle;
        
        public void ChangeCircleRange(float radius)
        {
            Vector3 scale = Vector3.one * 2.1875f * radius;
            radiusCircle.transform.DOScale(scale, 0.5f);
        }
    }
}
