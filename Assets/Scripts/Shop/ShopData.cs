using System.Collections;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// Shop data operation.
/// Author: Mingxi Yang 104563133
/// </summary>

public class ShopData {

    public List<ShopItem> shopList = new List<ShopItem>(); //An entity List used for saving XML data.

    /// <summary>
    /// Using specific path to load xml file.
    /// </summary>
    /// <param name="path"></param>
    public void ReadXmlByPath(string path)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(path);
        XmlNode root = doc.SelectSingleNode("Shop");
        XmlNodeList nodeList = root.ChildNodes;

        foreach (XmlNode node in nodeList)
        {
            string speed = node.ChildNodes[0].InnerText;
            string rotate = node.ChildNodes[1].InnerText;
            string model = node.ChildNodes[2].InnerText;
            string price = node.ChildNodes[3].InnerText;

            //Print all items information.
            //string info = string.Format("speed:{0}, rotate:{1}, model:{2}, price:{3}.", speed, rotate, model, price);
            //Debug.Log(info);

            //Save to List
            ShopItem item = new ShopItem(speed, rotate, model, price);
            shopList.Add(item);
        }
    }

}
