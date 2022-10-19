using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNode
{
    public List<string> lst_lines;
    public List<DialogNode> lst_nextNodes;
    public int i_curLine;

    public DialogNode()
    {
        lst_lines = new List<string>();
    }
}
