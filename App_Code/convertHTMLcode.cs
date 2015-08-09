using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;


public class convertHTMLcode
{

    // one more possibility to comment
    // var re = new Regex("<(?<tag>img.+?)>", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
    // var str = re.Replace("text <img src='some'> text", "[${tag}]");


	public string convertHTMLtext(string messs)
	{

        messs = Regex.Replace(messs, "&amp;", "&", RegexOptions.IgnoreCase);
        messs = Regex.Replace(messs, "&quot;", "\"", RegexOptions.IgnoreCase);

        messs = createHTML(messs, "&lt;br /&gt;");
        messs = createHTML(messs, "&lt;br[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/br&gt;");

        messs = createHTML(messs, "&lt;em[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/em&gt;");
        messs = createHTML(messs, "&lt;strong[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/strong&gt;");
        messs = createHTML(messs, "&lt;b[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/b&gt;");
        messs = createHTML(messs, "&lt;i[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/i&gt;");
        messs = createHTML(messs, "&lt;u[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/u&gt;");

        messs = createHTML(messs, "&lt;div[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/div&gt;");

        messs = createHTML(messs, "&lt;p[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/p&gt;");
        messs = createHTML(messs, "&lt;span[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/span&gt;");
        messs = createHTML(messs, "&lt;a[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/a&gt;");

        messs = createHTML(messs, "&lt;img[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");


        messs = createHTML(messs, "&lt;h1[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/h1&gt;");
        messs = createHTML(messs, "&lt;h2[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/h2&gt;");
        messs = createHTML(messs, "&lt;h3[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/h3&gt;");
        messs = createHTML(messs, "&lt;h4[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/h4&gt;");
        messs = createHTML(messs, "&lt;h5[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/h5&gt;");
        messs = createHTML(messs, "&lt;h6[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/h6&gt;");

        messs = createHTML(messs, "&lt;font[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/font&gt;");


        messs = createHTML(messs, "&lt;blockquote[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/blockquote&gt;");
        messs = createHTML(messs, "&lt;pre*&gt;");
        messs = createHTML(messs, "&lt;/pre&gt;");
        messs = createHTML(messs, "&lt;tt[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/tt&gt;");
        messs = createHTML(messs, "&lt;ol[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/ol&gt;");
        messs = createHTML(messs, "&lt;ul[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/ul&gt;");
        messs = createHTML(messs, "&lt;li[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/li&gt;");


        messs = createHTML(messs, "&lt;table[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/table&gt;");
        messs = createHTML(messs, "&lt;tr[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/tr&gt;");
        messs = createHTML(messs, "&lt;td[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/td&gt;");
        messs = createHTML(messs, "&lt;thead[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/thead&gt;");
        messs = createHTML(messs, "&lt;caption[a-zA-Z0-9\t\n -_.:;=\"/]*?&gt;");
        messs = createHTML(messs, "&lt;/caption&gt;");



        messs = Regex.Replace(messs, "&#39;", "'", RegexOptions.IgnoreCase);
        messs = Regex.Replace(messs, "&#34;", "\"", RegexOptions.IgnoreCase);

        messs = Regex.Replace(messs, "link", "'link", RegexOptions.IgnoreCase);
        messs = Regex.Replace(messs, "meta", "'meta", RegexOptions.IgnoreCase);
        messs = Regex.Replace(messs, "embed", "'embed", RegexOptions.IgnoreCase);

        return messs;
	}


   string createHTML(string mes,string pattern){
       string res;

       res = Regex.Replace(mes, @pattern, delegate(Match match)
       {
           string v = match.ToString();
           return "<" + v.Substring(4, v.Length - 8) + ">";

       },RegexOptions.IgnoreCase);

       return res;

    }



}