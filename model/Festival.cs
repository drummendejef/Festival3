using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Festival.model
{
    class Festival
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }

        public static ObservableCollection<Festival> GetFestivals()
        {
            ObservableCollection<Festival> festivals = new ObservableCollection<Festival>();

            //Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load("Festivals.xml");
            //Create the list.
            XmlNodeList elemList = doc.GetElementsByTagName("festival");
            for (int i = 0; i < elemList.Count; i++)
            {
                Festival festival = new Festival();
                festival.Name = elemList[i]["naam"].InnerText;
                festival.StartDate = Convert.ToDateTime(elemList[i]["begin"].InnerText);
                festival.EndDate = Convert.ToDateTime(elemList[i]["eind"].InnerText);

                festivals.Add(festival);
            }
            return festivals;
        }

        
    }
}
