using System;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Collections;

namespace NovelDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        string chapterURL;
        string bookName;
        string folder = "";
        ArrayList subURL;
        ArrayList checkedList; 

        private void btnGetChapter_Click(object sender, EventArgs e)
        {
            if (subURL != null)
                subURL = null;
            clbChapter.Items.Clear();
            if (tbURL.Text.IndexOf("https://www.piaotian.com/html/") != -1)
            {
                chapterURL = tbURL.Text;
                buildBookChapter(chapterURL);
                tbLog.Text = "來源：" + "飄天 (www.piaotian.com)" + "\r\n";
                tbLog.Text += "書名：" + bookName + "\r\n";
            }

        }

        public void buildBookChapter(string url)
        {
            string content;
            int index;
            WebClient client = new WebClient();
            client.Encoding = Encoding.GetEncoding("gb2312");
            string webStr = client.DownloadString(url);

            bookName = webStr.Substring(webStr.IndexOf("<title>") + 7);
            bookName = bookName.Substring(0, bookName.IndexOf("最新章节"));
            bookName = SimpTradChinese.ToTraditional(bookName);

            content = webStr;
            index = content.IndexOf("<ul>");
            if (index == -1)
                return;
            content = content.Substring(index);

            index = content.IndexOf("bottom");
            content = content.Substring(0, index);

            content = content.Replace("</ul>", "");
            content = content.Replace("<ul>", "");
            content = content.Replace("</li>", "");
            content = content.Replace("<li>", "");
            content = content.Replace("<a href=\"", "@");
            content = content.Replace("\">", "$");
            content = content.Replace("</a>", "%");
            index = 0;
            int head;
            int tail;
            string chapterName;
            subURL = new ArrayList();
            while (content.IndexOf("@", index) != -1)
            {
                head = content.IndexOf("@", index) + 1;
                index = head;
                tail = content.IndexOf("$", index);
                subURL.Add(content.Substring(head, tail - head));

                head = tail + 1;
                index = head;
                tail = content.IndexOf("%", index);
                index = tail;
                chapterName = content.Substring(head, tail - head);
                chapterName = SimpTradChinese.ToTraditional(chapterName);
                clbChapter.Items.Add(chapterName);
            }
        }


        public string getContent(string url)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.GetEncoding("gb2312");
            string webStr = client.DownloadString(url);
            return parseTitle(webStr) + "\r\n" + parseContent(webStr);
        }

        public string parseTitle(string webStr)
        {
            string content;
            int index;

            content = webStr;
            index = content.IndexOf("<title>") + 7;
            content = content.Substring(index);

            index = content.IndexOf("</title>");
            content = content.Substring(0, index);

            index = content.IndexOf("最新章节,") + 5;
            content = content.Substring(index);

            index = content.IndexOf(",飘天文学");
            content = content.Substring(0, index);

            content = content.Replace("正文 ", "");
            content = content.Replace("作品相关 ", "");

            return content;
        }

        public string parseContent(string webStr)
        {
            string content;
            int index;

            content = webStr;
            //++ 2018/2/23
            //index = content.IndexOf("style4") + 64;            
            index = content.IndexOf("返回书页");
            index = content.IndexOf("&nbsp;", index);
            //--
            content = content.Substring(index);
            index = content.IndexOf("</div>");
            content = content.Substring(0, index);
            content = content.Replace(";", "");
            content = content.Replace("&nbsp&nbsp", "\r\n");
            content = content.Replace("&nbsp", "");
            content = content.Replace("<br />", "");
            //++ 2018/3/25
            //remove unknow string "bpbpbpbp"
            content = content.Replace("bpbpbpbp", "");
            //--
            return content;
        }

        public void writeText(string fileName, string text)
        {
            fileName = folder + fileName;
            FileStream myFile = File.Open(fileName, FileMode.Append, FileAccess.Write, FileShare.None);
            StreamWriter myWriter = new StreamWriter(myFile, Encoding.GetEncoding("big5"));          
            myWriter.Write(text);
            myWriter.WriteLine("");
            myWriter.Dispose();
            myFile.Dispose();
        }

        private void btnSetectAllChapter_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbChapter.Items.Count; i++) 
            {
                clbChapter.SetItemChecked(i, true);
            }
        }

        private void btnDownloadSelected_Click(object sender, EventArgs e)
        {
            if (checkedList != null)
                checkedList = null;
            checkedList = new ArrayList();

            for (int i = 0; i < clbChapter.Items.Count; i++)
            {
                if (clbChapter.GetItemChecked(i) == true) 
                {
                    checkedList.Add(i);
                }
            }

            string webContent;
            for (int i = 0; i < checkedList.Count; i++) 
            {                
                webContent = getContent(chapterURL + subURL[(int)checkedList[i]]);
                webContent = SimpTradChinese.ToTraditional(webContent);
                writeText(bookName + ".txt", webContent);
            }
            tbLog.Text = checkedList.Count + " Chapter Download OK";
        }

        private void btnClearSelectedChapter_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbChapter.Items.Count; i++)
            {
                clbChapter.SetItemChecked(i, false);
            }
        }

        private void clbChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(clbChapter.SelectedItems.Count > 0)
            {
                tbLog.Text = clbChapter.SelectedValue + "";
            }
        }

        private void btnSticky_Click(object sender, EventArgs e)
        {
            int start = 0;
            int end = clbChapter.Items.Count - 1;

            for (int i = 0; i < clbChapter.Items.Count; i++)
            {
                if (clbChapter.GetItemChecked(i) == true)
                {
                    start = i;
                    break;
                }
            }

            for (int i = clbChapter.Items.Count - 1; i >= 0; i--)
            {
                if (clbChapter.GetItemChecked(i) == true)
                {
                    end = i;
                    break;
                }
            }

            for (int i = start; i < end; i++)
            {
                clbChapter.SetItemChecked(i, true);
            }
        }

        /*
        新飄天

        string frontURL = "http://tw.piaotian.cc";

        public string parseTitle(string webStr)
        {
            string content;
            int index;

            content = webStr;
            index = content.IndexOf("novel_title") + 14;
            content = content.Substring(index);
            index = content.IndexOf("</h1>");
            content = content.Substring(0, index);

            return content;
        }

        public string parseContent(string webStr)
        {
            string content;
            int index;

            content = webStr;
            index = content.IndexOf("novel_content") + 101;
            content = content.Substring(index);
            index = content.IndexOf("</div>");
            content = content.Substring(0, index);
            content = content.Replace(";", "");
            content = content.Replace("&nbsp", "");
            content = content.Replace("<br />", "");
            return content;
        }        
         */
    }
}
