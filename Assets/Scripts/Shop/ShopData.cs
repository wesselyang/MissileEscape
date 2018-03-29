using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

/// <summary>
/// Shop data operation.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ShopData : MonoBehaviour {

    public List<ShopItem> shopList = new List<ShopItem>(); //An entity List used for saving XML data.
    public List<int> shopStatus = new List<int>(); //A list of shop item purchase status.

    public int goldCount = 0;
    public int bestScore = 0;


    /// <summary>
    /// Using specific path to load xml file.
    /// </summary>
    /// <param name="path"></param>
    public void ReadXmlByPath(string content)
    {
        XmlDocument doc = new XmlDocument();
        //doc.Load(path);
        doc.LoadXml(content);   //Load the content from the variable.
        XmlNode root = doc.SelectSingleNode("Shop");
        XmlNodeList nodeList = root.ChildNodes;

        foreach (XmlNode node in nodeList)
        {
            string id = node.ChildNodes[0].InnerText;
            string speed = node.ChildNodes[1].InnerText;
            string rotate = node.ChildNodes[2].InnerText;
            string model = node.ChildNodes[3].InnerText;
            string price = node.ChildNodes[4].InnerText;

            //Print all items information.
            //string info = string.Format("speed:{0}, rotate:{1}, model:{2}, price:{3}.", speed, rotate, model, price);
            //Debug.Log(info);

            //Save to List
            ShopItem item = new ShopItem(id, speed, rotate, model, price);
            shopList.Add(item);
        }
    }

    /// <summary>
    /// Read the highest score and current reward the player has.
    /// </summary>
    /// <param name="path"></param>
    public void ReadPlayerInfo(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeList = root.ChildNodes;

        goldCount = int.Parse(nodeList[0].InnerText);
        bestScore = int.Parse(nodeList[1].InnerText); 

        for(int i = 2; i < 7; i++)
        {
            shopStatus.Add(int.Parse(nodeList[i].InnerText));
        }
    }


    /// <summary>
    /// Update (Write) player's highest score and current reward.
    /// </summary>
    public void UpdateXMLData(string path, string key, string value)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("SaveData");
        XmlNodeList nodeList = root.ChildNodes;

        foreach(XmlNode node in nodeList)
        {
            if(node.Name == key)
            {
                node.InnerText = value; //Update value which needs to change.
                doc.Save(path); //Save the operation in XML files.
            }
        }
    }
}
