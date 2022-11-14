using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceBase : MonoBehaviour
{
    public string str_name;

    GameObject go_container;
    FixedBag container;

    [SerializeField]
    private int i_row;
    [SerializeField]
    private int i_column;
    
   
    [HideInInspector]
    public bool b_isOpen;
    bool b_isWorking;
    bool b_isWorkingEnded;
    Animator animator;


    string str_productname;
    // Start is called before the first frame update
    void Start()
    {
        str_productname = "Red Firework";
        b_isWorking = false;
        b_isWorkingEnded = false;
        go_container = transform.Find("container").gameObject;
        container = go_container.GetComponent<FixedBag>();
        container.Init(false, true, i_row*i_column, i_row);
        b_isOpen = false;
        animator = GetComponent<Animator>();
    }

    public void OnRightClick()
    {
        if (b_isWorking)
        {
            return;
        }

        if (b_isOpen)
        {
            CloseContainer();
            b_isOpen = false;
        }else
        {
            if (b_isWorkingEnded)
            {
                //Get something
                GetItem();
                b_isWorkingEnded = false;
            }
            else
            {
                OpenContainer();
                b_isOpen = true;
            }

        }
    }
    public void OpenContainer()
    {
        go_container.SetActive(true);
    }

    public virtual void CloseContainer()
    {
        if (IsFull())
        {
            StartCoroutine(StartWorking());
        }
        go_container.SetActive(false);
    }

    public bool PutItemIn(string itemName, GameObject item)
    {
        foreach(var grid in container.lst_bagGrids)
        {
            if(Vector3.Distance(item.transform.position, grid.transform.position)< grid.GetComponent<RectTransform>().rect.width / 2)
            {
                item.SetActive(false);
                grid.AddItem(itemName, 1);
                return true;
            }
        }
        return false;
    }

    bool IsFull()
    {
        foreach(var grid in container.lst_bagGrids)
        {
            if (grid.s_itemName == "")
            {
                return false;
            }
        }
        
        return true;
    }

    IEnumerator StartWorking()
    {
        b_isWorking = true;
        animator.SetTrigger("StartWorking");
        yield return new WaitForSeconds(5);
    
        StartCoroutine(EndWorking());
    }

    IEnumerator EndWorking()
    {

        animator.SetTrigger("EndWorking");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        b_isWorking = false;
        b_isWorkingEnded = true;
    }

    void GetItem()
    {
        object[] args = { (object)"You got the "+str_productname, (object)"Texture2D/GameItem/"+str_productname };
        UIManager.Instance.GetUI<FireworkMakingUI>().AddMaterial(str_productname, 1);
        UIManager.Instance.OpenUI<TipUI>("UIPrefabs/TipUI",args);
    }
}
