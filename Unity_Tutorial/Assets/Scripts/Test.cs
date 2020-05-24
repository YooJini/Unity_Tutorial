using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialog
{
    [TextArea]
    public string dialog;
    public Sprite cg;

}
public class Test : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite_StandingCG;
    [SerializeField] private SpriteRenderer sprite_DialogBox;
    [SerializeField] private Text txt_Dialog;

    private bool isDialog = false;

    private int count = 0;

    [SerializeField] private Dialog[] dialog;

    private void OnOff(bool _flag)
    {
        sprite_DialogBox.gameObject.SetActive(_flag);
        sprite_StandingCG.gameObject.SetActive(_flag);
        txt_Dialog.gameObject.SetActive(_flag);
        isDialog = _flag;
    }

    public void ShowDialog()
    {
        OnOff(true);
        count = 0;
        NextDialog();
    }

    private void NextDialog()
    {
        txt_Dialog.text = dialog[count].dialog;
        sprite_StandingCG.sprite = dialog[count].cg;
        count++;
    }

    

    private void Update()
    {
        if(isDialog)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (count < dialog.Length)
                    NextDialog();
                else
                    OnOff(false);
            }
        }
    }
}
