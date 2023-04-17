using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;


public class DateManger : singlton<DateManger>
{
    private HttpClient httpRequest;
    private string contents;

   
    public void Inite()
    {
        RSSdata("http://www.kma.go.kr/weather/forecast/mid-term-rss3.jsp?stnId=108");
    }

    private async Task RSSdata(string url)
    {
        httpRequest = new HttpClient();
        try
        {
            using (var response = await httpRequest.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Debug.Log("�������� ����");
                    contents = await response.Content.ReadAsStringAsync();
                    Debug.Log(contents);
                   
                }
            }
        }
        catch (HttpRequestException e)
        {
            Debug.Log($"ex.Message={e.Message}");
            Debug.Log($"ex.InnerException.Message = {e.InnerException.Message}");
            Debug.Log("���� ���� ���� ");
        }
    }
    public List<string> datalist(string city)
    {
        var list = new List<string>();
        var xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(contents);
        var nodeList = xmlDocument.SelectNodes("descendant::location");
        foreach (XmlNode x in nodeList)
        {
            var a = x.SelectSingleNode("province");
            var b = x.SelectSingleNode("city");
            if ( b.InnerText == city)
            {
                var datanode= x.SelectNodes("descendant::data");
                foreach (XmlNode g in datanode)
                {
                    var m = g.SelectSingleNode("wf");
                    var t1 = g.SelectSingleNode("tmn");
                    var t2 = g.SelectSingleNode("tmEf");
                    list.Add("���� :" + m.InnerText + "\n�µ� :" + t1.InnerText + "\n��¥" + t2.InnerText);
                    Debug.Log("���� :" + m.InnerText + "\n�µ� :" + t1.InnerText + "\n��¥" + t2.InnerText);

                }
                break;
            }
        }
        return list;
    }
  
}
