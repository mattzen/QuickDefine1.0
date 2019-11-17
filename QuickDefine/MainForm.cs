using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using QuickDefine.controller;
using QuickDefine.models;
using System.Data.Entity;
using System.Threading;
using System.Text.RegularExpressions;
using Nest;
using System.Speech.Synthesis;

namespace QuickDefine
{

    partial class MainForm : Form
    {
        public string current;
        public int curx;
        // private Label label1;

        public int cury;
        public int sx = 285;
        public int sy = 245;
        public int wx;
        public int wy;

        List<string> google_history;
        List<string> pol_history;
        List<string> dictref_history;
        List<string> meriamweb_history;
        List<string> hist_words;

        List<string> list;


        public MainForm()
        {
            InitializeComponent();

            google_history = new List<string>();
            pol_history = new List<string>();
            dictref_history = new List<string>();
            meriamweb_history = new List<string>();
            hist_words = new List<string>();

        }

        void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        public void findDef(string keyword)
        {
            label1.Text = "Definitions for " + keyword;

            string ret = "";
            string ret2 = "";
            string ret3 = "";
            string ret4 = "";

            WordController cont = new WordController();

            if (google_check.Checked)
            {
                ret = cont.filter_google(keyword);
                ret = "Definitions for " + keyword + "\n\n" + ret;
                google_textbox.Text = ret;
            }

            if (dictref_check.Checked)
            {
                ret2 = cont.filter_dictref(keyword);
                ret2 = "Definitions for " + keyword + "\n\n" + ret2;
                dictref_textbox.Text = ret2;
            }

            if (meriamweb_check.Checked)
            {
                ret3 = cont.filter_merriam_web(keyword);
                ret3 = "Definitions for " + keyword + "\n\n" + ret3;
                meriamweb_textbox.Text = ret3;
            }

            if (pol_check.Checked)
            {
                ret4 = cont.filter_babla(keyword);
                ret4 = "Tlumaczenie " + keyword + ":\n\n" + ret4;
                pol_texbox.Text = ret4;
            }


            google_history.Add(ret);

            pol_history.Add(ret4);


            dictref_history.Add(ret2);


            meriamweb_history.Add(ret3);

            hist_words.Add(keyword);
            stayontopbox.Items.Add(keyword);

            inputBox.Text = "";
            stayontopbox.SelectedIndex = 0;

            if (google_textbox.Text == "" || pol_texbox.Text == "" || (meriamweb_textbox.Text == "") || (dictref_textbox.Text == ""))
            {
                google_textbox.Text = "No Definition found";
                pol_texbox.Text = "No Definition found";
                meriamweb_textbox.Text = "No Definition found";
                dictref_textbox.Text = "No Definition found";
            }



        }

        private void search_online_btn_Click(object sender, EventArgs e)
        {
            findDef(inputBox.Text.ToString());




        }

        private void get_history_btn_Click(object sender, EventArgs e)
        {


            int ind = stayontopbox.SelectedIndex;

            label1.Text = "Definition for: " + hist_words[ind];
            google_textbox.Text = google_history[ind];
            pol_texbox.Text = pol_history[ind];
            dictref_textbox.Text = dictref_history[ind];
            meriamweb_textbox.Text = meriamweb_history[ind];

        }

        private void ontop_CheckedChanged(object sender, EventArgs e)
        {
            if (ontop_check.Checked)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        private void search_localbtn_Click(object sender, EventArgs e)
        {

            WordController cont = new WordController();

            google_textbox.Text = cont.ret_from_db(inputBox.Text.ToString());

        }



        public class Sentence
        {
            List<string> words;

            public Sentence(){

                words = new List<string>();
            }
            
        }

        public class WordContext
        {
            public List<Sentence> sentences;
            public string word { get; set; }

            public WordContext()
            {
                sentences = new List<Sentence>();
            }
            
        }

        public List<string> getSentencesContains(List<string> words)
        {
            string list = File.ReadAllText("Cosmos - Carl Sagan.txt");
            Dictionary<string, int> listOfWords = File.ReadLines("totallist.txt").ToDictionary(x => x, y => 0);
            var sentCollection = getSentences(list);
            List<string> newsent = new List<string>();
            var ctr = 0;
            var counter_contains = 0;
            foreach (var sentence in sentCollection)
            {
                counter_contains = 0;
                foreach (var word in words)
                {
                    if (sentence.ToLower().Contains(word.ToLower()))
                    {
                        counter_contains++;
                    }
                        
                }
               
                if(counter_contains==words.Count)
                    newsent.Add(sentence + " [" + ctr + "]");
                ctr++;
            }

            return newsent;
        }

        public List<string> getSentencesContains(string word)
        {
            string list = System.IO.File.ReadAllText("Cosmos - Carl Sagan.txt");
            Dictionary<string, int> listOfWords = System.IO.File.ReadLines("totallist.txt").ToDictionary(x => x, y => 0);
            var sentCollection = getSentences(list);
            List<string> newsent = new List<string>();
            var ctr = 0;
            bool contains_all = false;
            foreach (var sentence in sentCollection)
            {
               
                    if (sentence.ToLower().Contains(word.ToLower()))
                    {

                    }
                    newsent.Add(sentence + " [" + ctr + "]");
                

                ctr++;
            }

            return newsent;
        }

 

        public List<string> get_keywords_from_phrase(string phrase)
        {
           return phrase.Split(' ').ToList();
        }

        public class SentenceRaw
        {
            public string text { get; set; }
            public string book { get; set; }
            public string sentenceIndex { get; set; }


        }
     
        private void genSentence_Click(object sender, EventArgs e)
        {
            //var form = new Form();
            //form.Height = 500;
            //form.Width = 1000;
            //var label = new Label();


            var textInput = textBox1.Text;


            var node = new Uri("http://localhost:9200/");

            var settings = new ConnectionSettings(node);

            var client = new ElasticClient(settings);

            var sentence = new SentenceRaw();
            sentence.text = textInput;
            //  var index = client.Index(word, x=>x.Index("home") );

            



            //string list = System.IO.File.ReadAllText("Meditations-by-Marcus-Aurelius.txt");
            traverse("D:\\zC\\pulpit\\Projects\\!c#\\QuickDefine\\QuickDefine\\bin\\Debug\\books");

            var files = _files;

            foreach (var file in files)
            {
                string list = System.IO.File.ReadAllText(file);
                var sentCollection = getSentences(list);

                var ctr = 0;
                foreach (var item in sentCollection)
                {
                    sentence = new SentenceRaw();
                    sentence.text = item;
                    sentence.sentenceIndex = ctr++.ToString();
                    sentence.book = file.Substring(file.LastIndexOf('\\'), file.Length- file.LastIndexOf('\\')).Replace("-", " ").Replace("\\", "");
                    client.Index(sentence, x => x.Index("selfhelp"));
                }
            }

           


            //var sent = getSentencesContains(get_keywords_from_phrase(textBox1.Text));
            //sententebox.Text = sent.Count.ToString() + "\n";


            //foreach (var item in sent)
            //{
            //    sententebox.Text += item + "\n";
            //}


            //label.Text = sent.Count.ToString();
            //form.Controls.Add(label);
            //form.Show();

        }
        string currentPathLocation = "";
        List<string> _files = new List<string>();
        private void traverse(string path)
        {

            currentPathLocation += path + "/";
            if (Directory.Exists(path))
            {
                var directories = Directory.GetDirectories(path).ToList();
                var files = Directory.GetFiles(path).ToList();
                _files.AddRange(files);

                foreach (var item in directories)
                {
                    traverse(item);
                }
            }
            else
            {
                _files.Add(path);
            }
        }
        private string getNextWord(string word)
        {



            return string.Empty;
        }


        private Dictionary<string, int> GetContextCount(List<string> sentences, Dictionary<string, int> listOfWords, string tword)
        {
            Dictionary<string, int> counts = listOfWords;
            Regex words = new Regex(@"/\W+/");
            string testword = tword;

            foreach (var item in sentences)
            {
                foreach (var word in item.Split(' '))
                {
                    if (counts.ContainsKey(word.ToString()))
                        counts[word.ToString()]++;
                }
            }
            return counts;

        }

        private Dictionary<string, int> GetWordCount(List<string> sentences, Dictionary<string, int> listOfWords)
        {
            Dictionary<string, int> counts = listOfWords;
            Regex words = new Regex(@"/\W+/");

            foreach (var item in sentences)
            {      
                foreach (var word in item.Split(' '))
                {
                    if(counts.ContainsKey(word))
                        counts[word]++;
                }              
            }         
            return counts;
        }


        private List<string> getSentences(string str)
        {
            List<string> list = new List<string>();

            Regex ex = new Regex(@"(\S.+?[.!?])(?=\s+|$)");

            var match = ex.Matches(str);

            foreach (var item in match)
	        {
                list.Add(item.ToString());
	        }

            list.RemoveAll(new Predicate<string>(x=>x==". ."));
            return list;
        }



        public int getval(string s)
        {
            int a = 0;

            for (int i = 0; i < s.Length; i++)
            {
                a += (int)s[i];
            }


            return a;

        }

        public double getScore(string keyword, string testword)
        {
            int score = 0;
            int count = 0;

            for (int i = 0; i < keyword.Length; i++)
            {
                for (int j = count; j < testword.Length; j++)
                {
                    if (keyword[i] == testword[j])
                    {
                        score = score + 2;
                        count = j;
                        break;
                    }

                }

            }

            if (keyword.Length == testword.Length)
                score += 1;

            if (keyword[0] == testword[0] && keyword[keyword.Length - 1] == testword[testword.Length - 1])
                score += 1;
            else
                score -= 1;

            if (testword.Length > keyword.Length)
                score -= (testword.Length - keyword.Length) / 2;

            if (testword.Length < keyword.Length)
                score -= (keyword.Length - testword.Length) / 2;
            
            return score;
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string word;
            List<double> list_scores;
            List<string> list_now = new List<string>(list);
            word = inputBox.Text.ToString();

            if (word.Length > 0)
            {

                list_scores = new List<double>();
                int index;
                string val1;
                double max;
                google_textbox.Text = ""; 

                for (int i = 0; i < list.Count; i++)
                {

                    list_scores.Add(getScore(word, list_now[i]));

                }
    

                for (int i = 0; i < 10; i++)
                {
                    max = list_scores.Max();
                    index = list_scores.IndexOf(max);
                    val1 = list_now[index];
                    list_scores.RemoveAt(index);
                    list_now.RemoveAt(index);
                    google_textbox.Text += val1 + " " + max.ToString() + "\n";
                }

            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            list = System.IO.File.ReadLines("totallist.txt").ToList();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 3)
            {
                sententebox.Text = "";
                var sent = getSentencesContains(get_keywords_from_phrase(textBox1.Text));
                sententebox.Text = sent.Count.ToString() + "\n";

                var ctr = 0;
                foreach (var item in sent)
                {
                    if (ctr < 5)
                    {
                        sententebox.Text += item + "\n";
                        ctr++;
                    }
                    else
                        break;
                   
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            WordController cont = new WordController();
            //.strip_google_local("test"); 
            cont.toDb(string.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {


            var node = new Uri("http://localhost:9200/");

            var settings = new ConnectionSettings(node);
            settings.DisableDirectStreaming();
            var client = new ElasticClient(settings);

            var searchQ = textBox1.Text.ToString();


            QueryStringQuery query = new QueryStringQuery();

            query.Query = searchQ;
            query.Name = "word";
           

            var searchRequest = new SearchRequest
            {
                From = 0,
                Size = 50,
                Query = query
                };


            var result = client.Search<Sentence>(searchRequest);


            var documents = result.Documents.ToList();

            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the audio output. 
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string.
            Task.Run(() => synth.Speak(string.Join(" ", documents.Select(x => x).Take(5))));



            elasticBox.Text = string.Join("\r\n", documents.Select(x=>x));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            WordController cont = new WordController();
            for (int i = 0; i < list.Count; i++)
            {
                cont.CrawlBabala(list[i]);
            }
            
        }
    }
}

