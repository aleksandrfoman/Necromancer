using DG.Tweening;
using TMPro;
using UnityEngine;
namespace Content.Scripts.UI
{
    public class ArmyCounter : MonoBehaviour
    {
        [SerializeField] private GameObject iconPanel;
        [SerializeField] private TMP_Text amountText;

        public void Init(int curAmount,int maxAmount)
        {
            amountText.text = curAmount + "/" + maxAmount;
        }
    
        public void UpdateInfo(int curAmount,int maxAmount)
        {
            Anim();
            amountText.text = curAmount + "/" + maxAmount;
        }
    
        private void Anim()
        {
            iconPanel.transform.localScale = Vector3.one * 1.1f;
            iconPanel.transform.DOScale(Vector3.one, 0.35f).SetEase(Ease.OutBack);
            
            amountText.transform.localScale = Vector3.one * 1.1f;
            amountText.transform.DOScale(Vector3.one, 0.35f).SetEase(Ease.OutBack);
        }
    }
}
