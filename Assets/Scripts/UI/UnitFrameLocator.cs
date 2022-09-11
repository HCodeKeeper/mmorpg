using System;
using UnityEngine;
using UnityEngine.UI;
using World;

namespace UI
{
    public class UnitFrameLocator : MonoBehaviour
    {
        public GameObject UnitframePrefab;
        private GameObject unitframe;
        private Character charScript;
        public GameObject UI;

        private Text titleText;
        private Slider hpSlider;

        public void Locate(GameObject character)
        {
            if (character != null)
            {
                charScript = character.GetComponent<Character>();
                if (charScript == null)
                {
                    throw new NullReferenceException("Target's Character script wasn't found");
                }
                charScript.StatUpdate -= SetValues;
                charScript.StatUpdate += SetValues;
                if (IsInstantiated())
                {
                    Destroy(unitframe);
                }
                //this method is called only when we pick different target?
                unitframe = Instantiate(UnitframePrefab);
                unitframe.transform.SetParent(UI.transform, false);
                SetTitleComponent();
                SetHpComponent();
                SetValues();
            }
        }

        private void SetValues()
        {
            titleText.text = charScript.Name;
            hpSlider.value = charScript.GetRatio();
        }

        private void SetTitleComponent()
        {
            titleText = unitframe.transform.Find("Title").gameObject.GetComponent<Text>();
        }

        private void SetHpComponent()
        {
            hpSlider = unitframe.transform.Find("Health bar").gameObject.GetComponent<Slider>();
        }

        private bool IsInstantiated()
        {
            return unitframe != null;
        }
    }
}