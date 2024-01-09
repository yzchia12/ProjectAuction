using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ProjectBid.UI
{
    public abstract class Panel<T> : MonoBehaviour where T : Panel<T>
    {
        public static T Instance { get; private set; }

        public GameObject MainPanel;
        public Animator Animator;

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("A instance already exists");
                //Detroy(this); //Or GameObject as appropriate
                return;
            }

            Instance = this as T;
        }

        public virtual void Show(bool isShow)
        {            
            if (MainPanel && !Animator)
            {
                MainPanel.SetActive(isShow);
            }            

            if (Animator)
            {
                Animator.SetBool("Show", isShow);
            }            
        }    

        public virtual void ForceResetLayout(GameObject layout)
        {
            Canvas.ForceUpdateCanvases();           

            RectTransform rectTransform = layout.GetComponent<RectTransform>();
            rectTransform.sizeDelta = Vector2.one;            
        }        

        public virtual IEnumerator RebuildLayout(RectTransform rectTransform)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
            yield return new WaitForEndOfFrame();
            LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        }

        public void RebuildLayout()
        {
            /*VerticalLayoutGroup layoutGroup = MainPanel.GetComponent<VerticalLayoutGroup>();

            if (layoutGroup)
            {
                layoutGroup.CalculateLayoutInputVertical();
                layoutGroup.CalculateLayoutInputHorizontal();
                layoutGroup.SetLayoutVertical();
                layoutGroup.SetLayoutHorizontal();
            }            

            LayoutRebuilder.ForceRebuildLayoutImmediate(MainPanel.GetComponent<RectTransform>());*/

            MainPanel.SetActive(false);
            
            Invoke("EnableLayout", 0.02f);
        }

        void EnableLayout()
        {
            MainPanel.SetActive(true);
        }

        public List<TMP_Dropdown.OptionData> GetOptionDataLists(string[] names)
        {
            List<TMP_Dropdown.OptionData> optionDataList = new List<TMP_Dropdown.OptionData>();

            for (int i = 0; i < names.Length; i++)
            {
                TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData();
                optionData.text = names[i];

                optionDataList.Add(optionData);
            }

            return optionDataList;
        }
    }
}