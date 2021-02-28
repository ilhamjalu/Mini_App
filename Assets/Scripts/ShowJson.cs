using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class Json_Data
{
    public string name;
    public string email;
}

public class ShowJson : MonoBehaviour
{
    Json_Data json_data = new Json_Data();

    public Text nama, email;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        string url = "https://5e510330f2c0d300147c034c.mockapi.io/users";
        WWW www = new WWW(url);
        yield return www;

        if (www.error == null)
            ReadJson(www.text.ToString());
        else
            Debug.Log("ERROR: " + www.error);
    }

    void ReadJson(string data)
    {
        JsonData jdata = JsonMapper.ToObject(data);

        for (int i = 0; i < jdata.Count; i++)
        {
            if (jdata[i]["id"].ToString() == "11")
            {
                json_data.name = jdata[i]["name"].ToString();
                json_data.email = jdata[i]["email"].ToString();
                return;
            }
        }
        
    }

    private void Update()
    {
        nama.text = "Name : " + json_data.name;
        email.text = "Email : " + json_data.email;
    }
}
