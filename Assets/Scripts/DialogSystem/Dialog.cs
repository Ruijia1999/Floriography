using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Dialog
{
    string s_ID;
    public string s_NPCname;
    public DialogNode curNode;

    public Dialog(string ID, string NPCname)
    {
        s_ID = ID;
        s_NPCname = NPCname;
        DialogNode tempNode = new DialogNode();
        string xmlfile = "C:/Users/rjhua/Desktop/DialogAsset/" + NPCname + ".xml";
        XmlDocument doc = new XmlDocument();
        doc.Load(xmlfile);
       
        XmlNode xn = doc.SelectSingleNode("root");
        XmlNodeList xnl = xn.ChildNodes;

        foreach (XmlNode xn1 in xnl)
        {
            
            XmlElement xe1 = (XmlElement)xn1;
            if (xe1.SelectSingleNode("title").InnerText == ID)
            {
                XmlNodeList xnl2 = xe1.SelectSingleNode("dialogNode").ChildNodes;
                tempNode = new DialogNode();
                foreach (XmlNode xn2 in xnl2)
                {
                    XmlElement xe2 = (XmlElement)xn2;
                    if (xe2.Name == "line")
                    {
                        tempNode.lst_lines.Add(xe2.InnerText);
                    }
                }
                if (curNode == null)
                {
                    curNode = tempNode;
                }
                break; 
            }

        }
    }
}
