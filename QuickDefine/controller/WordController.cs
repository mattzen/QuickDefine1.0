using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickDefine.models;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace QuickDefine.controller
{
    public class WordController
    {

        private Word _word;

        public WordController(Word w)
        {

            _word = w;

        }
        
        public WordController()
        {

        }

        public class TupleList<T1, T2> : List<Tuple<T1, T2>>
        {
            public void Add(T1 item, T2 item2)
            {
                Add(new Tuple<T1, T2>(item, item2));
            }
        }

        public void updateType_insertPl()
        {
            string[] lines = System.IO.File.ReadAllLines("words.txt");
            WordController cont = new WordController();

            Word w = new Word();

            string word = "";
            List<string> s;

            string ty = "";
            Word ww;
            using (WordsDb db = new WordsDb())
            {

                for (int k = 0; k < lines.Length; k++)
                {

                    w.wordId = k;
                    word = lines[k];

                    ww = db.word.Find(w.wordId + 1);

                    if (ww != null)
                    {
                        if (ww.word == lines[k])
                        {
                            s = cont.strip_pol_local(word);



                            ty = cont.strip_type(word);
                            if (ty == "")
                            {
                                ww.type = null;
                            }
                            else
                            {
                                ww.type = ty;
                            }

                            ww.polwords = new List<PolishWords>();

                            for (int i = 1; i < s.Count; i++)
                            {
                                ww.polwords.Add(new PolishWords()
                                {
                                    word = s[i],
                                    type = s[0]
                                });

                            }

                            db.Entry(ww).CurrentValues.SetValues(ww);
                            db.SaveChanges();
                        }
                    }

                }


            }



        }

        public string toDb(string keyword)
        {
            string[] lines = System.IO.File.ReadAllLines("totallist.txt");
            string def = "";

            string result = "";


            for (int wi = 0; wi < 7; wi++)
            {


                string content = System.IO.File.ReadAllText("definitionsg/definitionsg/" + lines[wi] + ".html");

                //string content = System.IO.File.ReadAllText("definitionsg/mother.html");
                keyword = lines[wi];
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();



                content = content.Replace("<em>", "").Replace("</em>", "").Replace("<b>", "").Replace("</b>", "");


                document.LoadHtml(content);


                HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//div//ol/div//li//text()");

                List<Definition> defs = new List<Definition>();

                List<string> definitions = new List<string>();
                TupleList<int, string> examples = new TupleList<int, string>();

                var polwords = strip_pol_local(lines[wi]);

                var ruswords = strip_russian_local(lines[wi]);

                TupleList<string, List<string>> lists = new TupleList<string, List<string>>();


                int ctr = 1;


                if (collection != null)
                {
                    foreach (HtmlNode link in collection)
                    {
                        //string target = link.Attributes["href"].Value;

                        def = link.InnerText;
                        def = def.Replace("  ", "");
                        def = def.Replace("\n", "").Replace("&quot;", @"""");
                        def = def.Replace("\n\n", "");
                        def = def.Trim();

                        if (def != "" && ctr < 6)
                        {

                            if (def[0] == '-')
                            {
                                examples.Add(ctr, def.Substring(1));
                                result += "       -" + def + "\n";
                            }
                            else
                            {
                                definitions.Add(def);
                                result += ctr + ". " + def + "\n";

                                ctr++;
                            }
                        }
                    }
                }

                
            for (int i = 0; i < definitions.Count; i++)
            {
                defs.Add(new Definition() { definition = definitions[i], examples = new List<Example>() });
            }
            for (int i = 0; i < examples.Count; i++)
            {
                defs[examples[i].Item1 - 2].examples.Add(new Example() { example = examples[i].Item2 });
            }


            using (var context = new WordsDb())
            {
                Word w = new Word();
                w.word = keyword;

                w.definitions = new List<Definition>();

                w.polwords = new List<PolishWords>();

                //w.ruswords = new List<RussianWord>();

                foreach (var item in defs)
                {
                    w.definitions.Add(item);
                }

                for (int i = 1; i < polwords.Count; i++)
                {
                    w.polwords.Add(new PolishWords
                    {
                        wordId = wi,
                        word = polwords[i]
                    });
                }

                //for (int i = 1; i < polwords.Count; i++)
                //{
                //    w.ruswords.Add(new RussianWord()
                //    {
                //        wordId = wi,
                //        word = polwords[i]
                //    });
               // }
                
                context.word.Add(w);
                context.SaveChanges();
            }


            }

            return result;


        }

        public string ret_from_db(string keyword)
        {
            string ret = "";
            using (WordsDb db = new WordsDb())
            {
            
                var words = db.word;
                var examples = db.example;
                
                var definitions = words.Where(x => x.word == keyword).SelectMany(x=>x.definitions).ToList();

                foreach (var item in definitions)
                {
                    item.examples = examples.Where(x => x.definitionId == item.definitionId).ToList();
                }

                var polwords = words.Where(x => x.word == keyword).SelectMany(x => x.polwords).ToList();

                ret = keyword + "\n";
                int ctr = 1;
                foreach (var definition in definitions)
                {
                    ret += ctr++ + ": " + definition.definition + "\n";
                    foreach (var example in definition.examples)
                    {
                        ret +=  "   - " + example.example + "\n";
                    }
                }

                ret += "\n\n";

                foreach (var polword in polwords)
                {
                    ret += polword.word + " ";
                }
             

            }

            return ret;
        }

        public string ret_type_db(string keyword)
        {
             var ret = "";
                
             using (WordsDb db = new WordsDb())
             {
                 var re = db.word.Where(x => x.word == keyword).Select(x => x.type);
                
                 ret = re.FirstOrDefault();
             }


             return ret;

        }
        
        public void downloaddefs(string keyword)
        {

            string req3 = "http://www.google.com/dictionary/json?callback=dict_api.callbacks.id100&q=" + keyword + "&sl=en&tl=en&restrict=pr%2Cde&client=te";

            string ret = "";

            TextWriter tw = new StreamWriter("C:\\Projects_Segregated\\c#\\visual studio\\new goblets, ocr\\Projects\\QuickDefinitions Original_NEWETS4\\definitionsg\\0.html", true);

            string[] lines = System.IO.File.ReadAllLines(@"C:\\Projects_Segregated\\c#\\visual studio\\new goblets, ocr\\Projects\\QuickDefinitions Original_NEWETS4\\words.txt");



            keyword = lines[1];
            ret = filter_google(keyword);
            tw = new StreamWriter("C:\\Projects_Segregated\\c#\\visual studio\\new goblets, ocr\\Projects\\QuickDefinitions Original_NEWETS4\\definitionsg\\" + keyword + ".html", true);
            tw.WriteLine(ret);



            tw.Close();

            ret = "Definitions for " + keyword + "\n\n" + ret;

        }

        public void CrawlBabala(string keyword)
        {
            var url = "https://en.bab.la/dictionary/english-russian/" + keyword;

            var result = download_def(url);

            TextWriter tw = new StreamWriter("russian/" + keyword+".html", true);

            tw.Write(result);

            tw.Close();

        }

        public Word strip_google_local(string keyword)
        {

            Word rett = new Word();
            string ret = "";
            // string content = System.IO.File.ReadAllText("definitionsg/" + keyword + ".html");
            // HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            string content = System.IO.File.ReadAllText("definitionsg/mother.html");
            // keyword = lines[wi];
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            document.LoadHtml(content);

            string def = "";
            string result = "";

            HtmlNodeCollection types = document.DocumentNode.SelectNodes("//*[@id='forEmbed']/text()");
            HtmlNodeCollection defs = document.DocumentNode.SelectNodes("//*[@id='forEmbed']/div[@class='std']");
            HtmlNodeCollection webdefs = document.DocumentNode.SelectNodes("//*[@id='left_links']");

            List<string> listtype = new List<string>();
            List<string> listdefs = new List<string>();
            List<string> listwebdefs = new List<string>();

            List<List<Definition>> list1 = new List<List<Definition>>();


            if (types != null)
            {
                foreach (HtmlNode link in types)
                {
                    string t = link.InnerText.Replace("\n", "").Trim();
                    if (t != "")
                    {
                        listtype.Add(t);



                    }
                }
            }
            types = document.DocumentNode.SelectNodes("//*[@id='forEmbed']/b/text()");
            if (types != null)
            {
                foreach (HtmlNode link in types)
                {
                    string t = link.InnerText.Replace("\n", "").Trim();
                    if (t != "")
                    {
                        listtype.Add(t);

                    }
                }
            }


            int ctr = 0;
            int ctr2 = 0;
            if (defs != null)
            {
                foreach (var item in defs)
                {
                    string it = item.InnerText.Trim().Replace("  ", "");
                    List<string> ll = new List<string>();
                    string[] split = it.Split(new char[] { '\n' });
                    bool append = false;
                    ctr = 0;
                    list1.Add(new List<Definition>());
                    for (int i = 0; i < split.Length; i++)
                    {
                        if (split[i] != "" && split[i] != " ")
                        {

                            if (split[i] == "-")
                            {
                                append = true;
                            }
                            else
                            {

                                if (append)
                                {

                                    list1[ctr2][ctr - 1].examples.Add(new Example() { example = split[i] });
                                    ll.Add("-" + split[i]);
                                    append = false;
                                }
                                else
                                {
                                    list1[ctr2].Add(new Definition());
                                    list1[ctr2][ctr].examples = new List<Example>();
                                    list1[ctr2][ctr].definition = split[i];
                                    list1[ctr2][ctr].type = listtype[ctr2];
                                    ctr = ctr + 1;
                                    ll.Add(split[i]);

                                }


                            }
                        }
                    }
                    ctr2 = ctr2 + 1;


                    listdefs.Add(item.InnerText);

                }
            }

            if (webdefs != null)
            {
                //webdefs
                foreach (var item in webdefs)
                {
                    listwebdefs.Add(item.InnerText);
                    string webs = item.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                    string[] splits = webs.Split(new char[] { '\n' });
                    //listwebdefs.Add(item.NextSibling.NextSibling.NextSibling.NextSibling.InnerText);
                }

            }


            /*
                content = content.Replace("<em>", "").Replace("</em>", "").Replace("<b>", "").Replace("</b>", "");


                document.LoadHtml(content);


                HtmlNodeCollection collection2 = document.DocumentNode.SelectNodes("//div//ol/div//li//text()");

                List<Definition> defs = new List<Definition>();

                List<string> definitions = new List<string>();
                TupleList<int, string> examples = new TupleList<int, string>();


                TupleList<string, List<string>> lists = new TupleList<string, List<string>>();


                if (collection2 != null)
                {
                    foreach (HtmlNode link in collection2)
                    {
                        //string target = link.Attributes["href"].Value;

                        def = link.InnerText;
                        def = def.Replace("  ", "");
                        def = def.Replace("\n", "").Replace("&quot;", @"""");
                        def = def.Replace("\n\n", "");
                        def = def.Trim();

                        if (def != "" && ctr < 6)
                        {

                            if (def[0] == '-')
                            {
                                examples.Add(ctr, def.Substring(1));
                                result += "       -" + def + "\n";
                            }
                            else
                            {
                                definitions.Add(def);
                                result += ctr + ". " + def + "\n";

                                ctr++;
                            }
                        }
                    }
                }
 
            */


            return rett;

        }

        public void strip_meriam_local(string keyword)
        {
            string content = System.IO.File.ReadAllText("definitionsg/icelanders.html");
            // keyword = lines[wi];
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            document.LoadHtml(content);

            string def = "";
            string result = "";

            HtmlNodeCollection types = document.DocumentNode.SelectNodes("//*[@id='forEmbed']/text()");
            HtmlNodeCollection defs = document.DocumentNode.SelectNodes("//*[@id='forEmbed']/div[@class='std']");
            HtmlNodeCollection webdefs = document.DocumentNode.SelectNodes("//*[@id='left_links']");

            List<string> listtype = new List<string>();
            List<string> listdefs = new List<string>();
            List<string> listwebdefs = new List<string>();

            List<List<Definition>> list1 = new List<List<Definition>>();


        }

        public List<string> strip_pol_local(string keyword)
        {

            string content = System.IO.File.ReadAllText("defpols/defpols/" + keyword + ".html");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            document.LoadHtml(content);

            string def = "";
            string typ = "";
            string result = "";

            List<string> res = new List<string>();

            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//*[@id='main']/div[1]/div[1]/div[1]/div[1]/p[1]/a");

            HtmlNodeCollection collection2 = document.DocumentNode.SelectNodes("//*[@id='main']/div[1]/div[1]/div[1]/div[1]/p[1]/span[2]");
            int ctr = 0;


            if (collection2 != null)
            {
                foreach (var item in collection2)
                {
                    typ += item.InnerText.ToString();
                    if (typ.Length > 2)
                    {
                        res.Add(typ.Substring(1, typ.Length - 2).ToString());
                    }
                }

            }

            if (collection != null)
            {

                foreach (var item in collection)
                {
                    if (ctr < 5)
                    {
                        res.Add(item.InnerText.ToString());
                        def += item.InnerText.ToString() + ",";
                        ctr++;
                    }
                }
            }


            result += def + "\n";


            return res;

        }

        public List<string> strip_russian_local(string keyword)
        {

            string content = System.IO.File.ReadAllText("russian/" + keyword + ".html");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            document.LoadHtml(content);

            string def = "";
            string typ = "";
            string result = "";

            List<string> res = new List<string>();

            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//*[@id='main']/div[1]/div[1]/div[1]/div[1]/p[1]/a");

            HtmlNodeCollection collection2 = document.DocumentNode.SelectNodes("//*[@id='main']/div[1]/div[1]/div[1]/div[1]/p[1]/span[2]");
            int ctr = 0;


            if (collection2 != null)
            {
                foreach (var item in collection2)
                {
                    typ += item.InnerText.ToString();
                    if (typ.Length > 2)
                    {
                        res.Add(typ.Substring(1, typ.Length - 2).ToString());
                    }
                }

            }

            if (collection != null)
            {

                foreach (var item in collection)
                {
                    if (ctr < 5)
                    {
                        res.Add(item.InnerText.ToString());
                        def += item.InnerText.ToString() + ",";
                        ctr++;
                    }
                }
            }


            result += def + "\n";


            return res;

        }


        public string filter_google(string keyword)
        {

            string req = "http://google-dictionary.so8848.com/meaning?word=" + keyword;

            string ret = download_def(req);

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            ret = ret.Replace("<em>", "").Replace("</em>", "").Replace("<b>", "").Replace("</b>", "");

            document.LoadHtml(ret);

            string def = "";
            string result = "";

            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//div//ol/div//li//text()");

            int ctr = 1;

            if (collection != null)
            {
                foreach (HtmlNode link in collection)
                {
                    //string target = link.Attributes["href"].Value;

                    def = link.InnerText;
                    def = def.Replace("  ", "");
                    def = def.Replace("\n", "").Replace("&quot;", @"""");
                    def = def.Replace("\n\n", "");
                    def = def.Trim();

                    if (def != "")
                    {

                        if (def[0] == '-')
                        {
                            result += "       -" + def + "\n";
                        }
                        else
                        {
                            result += ctr + ". " + def + "\n";

                            ctr++;
                        }
                    }
                }



            }


            return ("source: " + req + "\n\n" + result);

        }
        public string filetr_wiki(string keyword)
        {
            string req = "https://en.wiktionary.org/wiki/" + keyword;
            string ret = "";

            ret = download_def(req);

            return ret;


        }
        public string filter_dictref(string keyword)
        {
            string req = "http://dictionary.reference.com/browse/" + keyword + "?s=t";
            string ret = "";


            ret = download_def(req);


            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            if (ret == null) return null; 
            document.LoadHtml(ret);

            string def = "";
            string result = "";
            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//html//body//div[3]//div[1]");
            int ctr = 1;

            if (collection != null)
            {
                foreach (HtmlNode link in collection)
                {
                    //string target = link.Attributes["href"].Value;



                    if (ctr > 11)
                    {
                        def = link.InnerText;


                        result += def + "\n\n";
                    }

                    ctr++;

                }

            }

            return ("source: " + req + "\n\n" + result);
        }
        public string filter_merriam_web(string keyword)
        {


            string req = "http://www.merriam-webster.com/dictionary/" + keyword;
            string ret = "";

            ret = download_def(req);


            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();

            document.LoadHtml(ret);

            string def = "";
            string result = "";
            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//div[@id='mwEntryData']//div//div//div//span//text()");
            int ctr = 1;

            if (collection != null)
            {
                foreach (HtmlNode link in collection)
                {
                    //string target = link.Attributes["href"].Value;


                    def = link.InnerText.Trim();

                    //def = def.Replace("\n", "");
                    //def = def.Replace("\n", "").Replace("&nbsp;&nbsp;", "");


                    def = def.Replace("&lt;", "; ").Replace("&gt;", "; ");


                    result += def;
                }

                result = result.Replace(":", "\n- ");

            }

            return (req + "\n\n" + result);


        }
        public string filter_babla(string keyword)
        {


            string req = "http://pl.bab.la/slownik/angielski-polski/" + keyword;

            string ret = "";

            ret = download_def(req);


            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();


            document.LoadHtml(ret);



            string def = "";
            string result = "";
            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//div//div//section");
            int ctr = 1;

            if (collection != null)
            {
                foreach (HtmlNode link in collection)
                {
                    //string target = link.Attributes["href"].Value;


                    def = link.InnerText.Trim();

                    //def = def.Replace("\n", "");
                    //def = def.Replace("\n", "").Replace("&nbsp;&nbsp;", "");

                    string rep = "<!-- div class=" + @"""" + "span2" + @"""" + "></div-->";

                    def = def.Replace(rep, "");
                    result += def;


                }


            }

            return ("source " + req + "\n\n" + result);

        }

        public string strip_type(string keyword)
        {
            string ret = "";
            string content = System.IO.File.ReadAllText("definitionsm/" + keyword + ".html");
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);

            HtmlNodeCollection collection = document.DocumentNode.SelectNodes("//*[@id='hw-attribute-0']/span[1]/em");
            int ctr = 0;
            List<string> list = new List<string>();
            if (collection != null)
            {
                foreach (HtmlNode link in collection)
                {
                    //string target = link.Attributes["href"].Value;

                    if (ctr < 3)
                    {
                        if (!list.Contains(link.InnerText.Trim()))
                        {
                            ret += link.InnerText.Trim() + ","; ;
                            list.Add(link.InnerText.Trim());
                            ctr++;
                        }


                    }
                }

            }
            if (ret.Length > 0)
            {
                ret = ret.Substring(0, ret.Length - 1);
            }
            else
            {

                ret = "";
            }
            return ret;
        }

        public string download_def(string url)
        {

            string req = url;
            string ret;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(req);

            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    ret = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                if (ex.Response == null)
                {
                    return null;
                }
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    String errorText = reader.ReadToEnd();
                }
                return null;
            }


            return ret;

        }

        public void get_new_list()
        {
            string[] first = System.IO.File.ReadAllLines("words.txt");
            string[] second = System.IO.File.ReadAllLines("wordsEn.txt");

            List<string> newList = new List<string>();

            for (int i = 0; i < second.Length; i++)
            {
                if (!first.Contains(second[i]))
                {

                    newList.Add(second[i]);
                }
            }
            System.IO.File.WriteAllLines("newlist.txt", newList);

        }

    }
}
