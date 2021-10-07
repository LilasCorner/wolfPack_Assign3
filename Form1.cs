/***************************************************************
CSCI 473      Assignment 3     Fall 2021

Programmer: Lila & Harshith

ZIDS: Z1838117 & Z1891464

Section: 01

Date Due: 10/7/21
***************************************************************/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization;

namespace wolfPack_Assign3
{
    public partial class wolfPack_Assign3 : Form
    {
        //global variables below
        protected static string selectedUser = "";
        protected static string selectedSub = "";
        protected static string selectedPost = "";
        protected static string selectedCom = "";

        public static SortedDictionary<uint, User> usersMap = new SortedDictionary<uint, User>();
        public static SortedDictionary<uint, Subreddit> subMap = new SortedDictionary<uint, Subreddit>();
        public static SortedDictionary<uint, Post> postMap = new SortedDictionary<uint, Post>();
        public static SortedDictionary<uint, Comment> comMap = new SortedDictionary<uint, Comment>();
        public static ArrayList globalIds = new ArrayList();

        public const int SUB_INDEX = 4;
        public const int POST_INDEX = 18;
        public const int COM_INDEX = 15;
        public const int USER_INDEX = 6;

        enum badWords
        {
            fudge,
            shoot,
            baddie,
            butthead
        }


        public wolfPack_Assign3()
        {
            InitializeComponent();
            readData();
            popComboBox();
        }


        // Method:  readData()
        // Purpose: reads the data from the text files provided, and stores them in their corresponding dictionaries
        // Params: N/A
        // Returns: N/A
        public void readData()
        {
            string lineRead = "";

            #region

            //validate users.txt exists!
            if (File.Exists("..//..//users.txt"))
            {
                //reading users.txt
                using (StreamReader inFile = new StreamReader("..//..//users.txt"))
                {
                    lineRead = inFile.ReadLine(); // prime read

                    while (lineRead != null)
                    {
                        string[] tokens = lineRead.Split('\t');
                        uint id = Convert.ToUInt32(tokens[0]);

                        //parse all tokens into dictionary + array of all ID's
                        usersMap[id] = new User(tokens);
                        globalIds.Add(id);

                        lineRead = inFile.ReadLine();
                    }
                }
            }

            #endregion


            #region

            //validate subreddits.txt exists!
            if (File.Exists("..//..//subreddits.txt"))
            {
                //reading users.txt
                using (StreamReader inFile = new StreamReader("..//..//subreddits.txt"))
                {
                    lineRead = inFile.ReadLine(); // prime read

                    while (lineRead != null)
                    {

                        string[] tokens = lineRead.Split('\t');

                        //parse all tokens into dictionary + array of all ID's
                        subMap[Convert.ToUInt32(tokens[0])] = new Subreddit(tokens);
                        globalIds.Add(Convert.ToUInt32(tokens[0]));

                        lineRead = inFile.ReadLine();
                    }
                }
            }

            #endregion


            #region

            //validate users.txt exists!
            if (File.Exists("..//..//posts.txt"))
            {
                //reading users.txt
                using (StreamReader inFile = new StreamReader("..//..//posts.txt"))
                {
                    lineRead = inFile.ReadLine(); // prime read

                    while (lineRead != null)
                    {
                        string[] tokens = lineRead.Split('\t');
                        uint id = Convert.ToUInt32(tokens[1]);

                        //parse all tokens into dictionary + array of all ID's
                        postMap[id] = new Post(tokens);
                        globalIds.Add(id);

                        lineRead = inFile.ReadLine();
                    }
                }
            }

            #endregion


            #region

            //validate users.txt exists!
            if (File.Exists("..//..//comments.txt"))
            {
                //reading users.txt
                using (StreamReader inFile = new StreamReader("..//..//comments.txt"))
                {
                    lineRead = inFile.ReadLine(); // prime read
                    uint id = 0;
                    uint parent = 0;

                    while (lineRead != null)
                    {

                        string[] tokens = lineRead.Split('\t');


                        id = Convert.ToUInt32(tokens[COM_INDEX - 15]);
                        parent = Convert.ToUInt32(tokens[COM_INDEX - 12]);
                        int what = whatAmI(parent);
                        Comment newCom = new Comment(tokens);
                        comMap[id] = newCom;


                        //parse all tokens into dictionary + array of all ID's
                        if (what == 2)//post
                        {
                            postMap[parent].addComment(newCom);
                        }
                        else if (what == 3)//comment reply
                        {
                            foreach (var item in postMap.Keys)
                            {
                                foreach (var index in postMap[item].PostComments)
                                {
                                    if (index.Id == parent)
                                    {
                                        index.addComment(newCom);
                                    }
                                }
                            }

                        }

                        globalIds.Add(id);

                        //read next line
                        lineRead = inFile.ReadLine();
                    }
                }
            }

            #endregion


        }

        // Method:  popComboBox()
        // Purpose: populates all the comboboxes on the form
        // Params: N/A
        // Returns: N/A
        public void popComboBox()
        {
            foreach(var item in usersMap.Keys)
            {
                userComboBox.Items.Add(usersMap[item].Name);
            }

            foreach (var item in subMap.Keys)
            {
                subComboBox.Items.Add(subMap[item]);
            }
        }

        // Method:  nameToId(string name, uint dictionary)
        // Purpose: converts a name to it's id counterpart from the dictonary provided
        // Params: string name that we want to convert, uint dictionary that we will search through
        // Returns: uint id that belongs to the name given
        public uint nameToId(string name, uint dictionary)
        {
            if (dictionary == 1)
            {

                foreach (var item in usersMap.Keys)
                {
                    if (usersMap[item].Name.Equals(name))
                    {
                        return item;
                    }
                }

            }
            else if (dictionary == 2)
            {
                foreach (var item in subMap.Keys)
                {
                    if (subMap[item].Name.Equals(name))
                    {
                        return item;
                    }
                }
            }


            return 0;
        }

        // Method:  whatAmI(uint id)
        // Purpose: identifies what map the id provided belongs to
        // Params: uint id, the id we want to identify
        // Returns: integer identifying the map associated with the id
        public static int whatAmI(uint id)
        {
            if (usersMap.ContainsKey(id)) //USER
            {
                return 0;
            }
            else if (subMap.ContainsKey(id)) // SUBREDDIT
            {
                return 1;
            }
            else if (postMap.ContainsKey(id)) //POST
            {
                return 2;
            }

            return 3; //COMMENT

        }

        // Method:  UniqueId(uint id)
        // Purpose: verifies given ID is completely unique across all classes
        // Params: uint id, the id we want to verify
        // Returns: true if id is unique, false if it is duplicate
        static public bool UniqueId(uint id)
        {
            //sort globalId array
            globalIds.Sort();
            int flag = globalIds.BinarySearch(id);

            //binary search array for duplicates -- if we got -1, id is good, positive number is bad!
            if (flag > 0)
            {
                return false;
            }

            return true;
        }

        // Method:  genId()
        // Purpose: generate completely unique ID if needed
        // Params: N/A
        // Returns: uint of new ID
        static public uint genId()
        {
            //create random num 0-9999
            Random random = new Random();

            uint id = Convert.ToUInt32(random.Next(0, 10000));

            //if id generated is invalid, loop until we generate a valid one
            while (UniqueId(id) == false)
            {
                id = Convert.ToUInt32(random.Next(0, 10000));
            }

            globalIds.Add(id);
            return id;
        }


        // Method:  validateName(string name)
        // Purpose: verifies given name is within criteria for reddit names
        // Params: string name, the name we're going to check
        // Returns: true if name is valid, false if it's bad
        public static bool validateName(string name, int min, int max)
        {
            //both these will = true if white space located, we want false value ideally
            bool first = char.IsWhiteSpace(name[0]);
            bool last = char.IsWhiteSpace(name[name.Length - 1]);

            //perform validation of name has to be char >5 && <21 && cannot begin/end with space characters

            if (name.Length < min || name.Length > max || first || last || findBadWords(name))
            {
                return false;
            }

            return true;
        }


        // Method:  findBadWords(string str)
        // Purpose: checks if given string has a bad word
        // Params: string str, the string we're going to check
        // Returns: throws exception if string has badword, false if no badword found
        public static bool findBadWords(string str)
        {

            foreach (string word in Enum.GetNames(typeof(badWords)))
            {
                if (str.Contains(word))
                {

                    throw new FoulLanguageException();

                }

            }

            return false;
        }

        // Method:  endQueryMsg()
        // Purpose: prints out the end of query results line
        // Params: N/A
        // Returns: N/A
        public void endQueryMsg()
        {
            outputBox.AppendText(Environment.NewLine);
            outputBox.AppendText("*************** END OF QUERY RESULTS ***************");
        }

        // Method:  endQueryMsg()
        // Purpose: prints out the end of query results line
        // Params: object sender, EventArgs e
        // Returns: N/A
        private void thresholdQuery_Click(object sender, EventArgs e)
        {

            outputBox.Clear();

            //queries below
            var greatPostQ =
               from N in postMap
               where N.Value.Score >= Convert.ToDouble(numericUpDown.Value)
               select N.Key;

            var greatTopComQ =
                from N in postMap.Values
                from M in N.PostComments
                where M.Score >= Convert.ToDouble(numericUpDown.Value)
                select M;


            var greatComQ =
                from N in postMap.Values
                from M in N.PostComments
                from L in M.CommentReplies
                where L.Score >= Convert.ToDouble(numericUpDown.Value)
                select L;

            var lowPostQ =
               from N in postMap
               where N.Value.Score <= Convert.ToDouble(numericUpDown.Value)
               select N.Key;

            var lowTopComQ =
                from N in postMap.Values
                from M in N.PostComments
                where M.Score <= Convert.ToDouble(numericUpDown.Value)
                select M;


            var lowComQ =
                from N in postMap.Values
                from M in N.PostComments
                from L in M.CommentReplies
                where L.Score <= Convert.ToDouble(numericUpDown.Value)
                select L;

            //make sure  a button is actually checked
            if ( (lessThanRadioButton.Checked || greaterThanRadioButton.Checked))
            {
               
                if (lessThanRadioButton.Checked)
                {
                    outputBox.AppendText("List of Posts/Comments with a Score Less than or Equal to " + numericUpDown.Value + ":" + Environment.NewLine);
                    outputBox.AppendText("--------------------------------------" + Environment.NewLine);
                    outputBox.AppendText("Posts:" + Environment.NewLine);

                    //print posts
                    foreach (var item in lowPostQ)
                    {
                        outputBox.AppendText(postMap[item].toStringTiny() + Environment.NewLine);
                    }

                    //print top comments
                    outputBox.AppendText(Environment.NewLine + "Top Level Comments:" + Environment.NewLine);
                    foreach (var item in lowTopComQ)
                    {
                        outputBox.AppendText(item.toStringTiny() + Environment.NewLine);
                    }

                    //print regular comments
                    outputBox.AppendText(Environment.NewLine + "Comment Replies:" + Environment.NewLine);
                    foreach (var item in lowComQ)
                    {
                        outputBox.AppendText(item.toStringTiny() + Environment.NewLine);
                    }

                }
                else //else the greater checkbox was clicked
                {

                    outputBox.AppendText("List of Posts/Comments with a Score Greater than or Equal to " + numericUpDown.Value + ":" + Environment.NewLine);
                    outputBox.AppendText("--------------------------------------" + Environment.NewLine);
                    outputBox.AppendText("Posts:" + Environment.NewLine);

                    //print posts
                    foreach (var item in greatPostQ)
                    {
                        outputBox.AppendText(postMap[item].toStringTiny() + Environment.NewLine);
                    }

                    //print top comments
                    outputBox.AppendText(Environment.NewLine + "Top Level Comments:" + Environment.NewLine);

                    foreach (var item in greatTopComQ)
                    {
                        outputBox.AppendText(item.toStringTiny() + Environment.NewLine);
                    }

                    //print regular comments
                    outputBox.AppendText(Environment.NewLine + "Comment Replies:" + Environment.NewLine);

                    foreach (var item in greatComQ)
                    {
                        outputBox.AppendText(item.toStringTiny() + Environment.NewLine);
                    }

                }
                    endQueryMsg();

            }
            else //else user didnt actually click anything, show error msg
            {
                outputBox.AppendText("Please make sure a radio button is selected.\n");
                return;
            }
        }

        // Method:  dateQuery_Click
        // Purpose: Handles the date query based on the date selected to show all posts from that specific date
        // Params: object sender, EventArgs e
        // Returns: N/A
        private void dateQuery_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
            string currentDate = Convert.ToDateTime(specificDatePicker.Value.Date).ToShortDateString();

            var dateSelected =
                from N in postMap.Values
                where N.TimeStamp.ToShortDateString() == currentDate
                select N;

            outputBox.AppendText("All posts from: " + currentDate + Environment.NewLine);
            outputBox.AppendText("----------------------------------------------" + Environment.NewLine);

            foreach (var item in dateSelected)
            {
                outputBox.AppendText(item.ToString() + Environment.NewLine);
            }

            var myQuery = (from Q in dateSelected select Q).ToList();


            if (myQuery.Count < 1)
            {
                outputBox.AppendText("Wow, such empty!");

            }
            else
            {

                endQueryMsg();
            }

        }

        // Method:  userPostQuery_Click
        // Purpose: queries for all the subreddits posted to by a specific user and displays the results
        // Params: object sender, EventArgs e
        // Returns: N/A
        private void userPostQuery_Click(object sender, EventArgs e)
        {
            outputBox.Clear();
         
            //make sure a user is actually selected, else error msg
            if(userComboBox.SelectedIndex != -1)
            {
                //queries below
                var subSelectedQ =
                    from N in postMap.Values
                    where N.AuthorId == nameToId(userComboBox.Items[userComboBox.SelectedIndex].ToString(), 1)
                    select N.SubHome;

                //keep running list of all subs so we don't store duplicates
                HashSet<uint> uniqueSubs = new HashSet<uint>();

                outputBox.AppendText("Subreddits Posted To By: "+ userComboBox.Items[userComboBox.SelectedIndex].ToString() + Environment.NewLine);
                outputBox.AppendText("--------------------------------------" + Environment.NewLine);
                var myQuery = (from Q in subSelectedQ select Q).ToList();

                //print subreddits
                foreach (var item in subSelectedQ)
                {
                    uniqueSubs.Add(item);
                }


                //if user hasnt posted in any subreddit, show empty msg
                if (myQuery.Count < 1)
                {
                    outputBox.Clear();
                    outputBox.AppendText("No entries for this specific user. " + Environment.NewLine);
                }
                else
                {   //print out all the subreddits they've posted in
                    foreach(var item in uniqueSubs.Reverse())
                    {
                        outputBox.AppendText(String.Format("{0, 30}", subMap[item].Name));
                        outputBox.AppendText(Environment.NewLine);
                    }

                    endQueryMsg();
                }
            }
            else //error msg 
            {
                outputBox.AppendText("Please select the user you would like to see subreddits for. " + Environment.NewLine);

            }
        }
        

        //awardQuery_Click
        //params: object sender, EventArgs e
        //purpose: handles award queries based on number of checkboxes selected to output the number of silver, gold, or platinum awards in a single subreddit
        //returns: N/A
        private void awardQuery_Click(object sender, EventArgs e)
        {
            outputBox.Clear();

            bool sflag = false;
            bool gflag = false;
            bool pflag = false;
            string intro = "";
           
            int print = 0; 

            //if no checkbox is selected or they forgot to select a subreddit, error msg
            if ((!silverAward.Checked && !goldAward.Checked && !platAward.Checked) || subComboBox.SelectedIndex == -1)
            {
                outputBox.AppendText("Please select an award type, and the subreddit you'd like to see results for. " + Environment.NewLine);
                return;
            }

            //determine how many check boxes selected and append it's award name to the intro
            if (silverAward.Checked)
            {
                print = 1;
                sflag = true;
                intro += "Silver";
                
            }
            if (goldAward.Checked)
            {
                gflag = true;
                if (sflag && !platAward.Checked)
                {
                    intro += ", and Gold";
                    print = 4;
                }
                else if (sflag && platAward.Checked)
                {
                    intro += ", Gold";
                }
                else
                {
                    print = 2;
                    intro += "Gold";
                }
            }
            if (platAward.Checked)
            {
            pflag = true;
                if (sflag || gflag)
                {
                    intro += ", and Platinum";
                    if(sflag && !gflag)
                    {
                        print = 5;
                    }
                    if (!sflag && gflag)
                    {
                        print = 6;
                    }
                }
                else
                {
                    intro += "Platinum";
                    print = 3;
                }
            }

            //if all checkboxes clicked case
            if(sflag && gflag && pflag)
            {
                print = 7;
            }

            uint sub = nameToId(subComboBox.Items[subComboBox.SelectedIndex].ToString(), 2);

            //print header line
            outputBox.AppendText(intro + " awards for the " + subMap[sub].Name + " Subreddit:" + Environment.NewLine);
            outputBox.AppendText("--------------------------------------" + Environment.NewLine);

            //switch case depending on num check boxes selected to print proper output
            switch (print) //switch based on how many checkboxes were checked
                {
                    case 1: //silver
                        {
                            printSilver();
                            break;
                        }
                    case 2: //gold
                        {
                            printGold();
                            break;
                        }
                    case 3:// plat
                        {
                            printPlat();
                            break;
                        }
                    case 4: //silver + gold
                        {
                            printSilver();
                            printGold();
                            break;
                        }
                    case 5:// silver + plat
                        {
                            printSilver();
                            printPlat();
                            break;
                        }
                    case 6: //gold + plat
                        {
                            printGold();
                            printPlat();
                            break;
                        }
                    case 7: //all
                    {
                        printSilver();
                        printGold();
                        printPlat();
                        break;
                    }

                }

            endQueryMsg();

        }


        //printSilver
        //params: N/A
        //purpose: handles silver queries based on the checkboxes selected to produce the number of silver awards granted to a subreddit
        //returns: N/A
        public void printSilver()
        {
            //storing subreddit into smaller variable for ease of reading
            uint sub = nameToId(subComboBox.Items[subComboBox.SelectedIndex].ToString(), 2);


            //queries below
            var sPostQ =
                    from N in postMap.Values
                    where N.SubHome == sub
                    select N[0];

            var sTopQ =
                from N in postMap.Values
                where N.SubHome == sub
                from M in N.PostComments
                select M[0];

            var sComQ =
                from N in postMap.Values
                where N.SubHome == sub
                from M in N.PostComments
                from L in M.CommentReplies
                select L[0];


            //if all subreddit selected, edit queries accordinly
            if (subMap[sub].Name.Equals("all"))
            {
                sPostQ =
                   from N in postMap.Values
                   select N[2];

                sTopQ =
                   from N in postMap.Values
                   from M in N.PostComments
                   select M[2];

                sComQ =
                   from N in postMap.Values
                   from M in N.PostComments
                   from L in M.CommentReplies
                   select L[2];
            }

            int totals = 0;

            //printing awards in posts
            foreach(var item in sPostQ)
            {
                totals += item;
            }

            outputBox.AppendText("\t Silver awards in Posts: " + totals + Environment.NewLine);
            totals = 0;

            //printing awards in top comments
            foreach (var item in sTopQ)
            {
                totals += item;
            }
            outputBox.AppendText("\t Silver awards in Top Comments: " + totals + Environment.NewLine);

            totals = 0;

            //printing awards in regular comments
            foreach (var item in sComQ)
            {
                totals += item;
            }
            outputBox.AppendText("\t Silver awards in Comments: " + totals + Environment.NewLine + Environment.NewLine);

        }

        //printGold
        //params: N/A
        //purpose: handles gold queries based on the checkboxes selected to produce the number of gold awards granted to a subreddit
        //returns: N/A
        public void printGold()
        {
            //storing subreddit's into smaller variable for ease of reading
            uint sub = nameToId(subComboBox.Items[subComboBox.SelectedIndex].ToString(), 2);

            //queries  below
            var gPostQ =
                from N in postMap.Values
                where N.SubHome == sub
                select N[1];

            var gTopQ =
                from N in postMap.Values
                where N.SubHome == sub
                from M in N.PostComments
                select M[1];

            var gComQ =
                from N in postMap.Values
                where N.SubHome == sub
                from M in N.PostComments
                from L in M.CommentReplies
                select L[1];

            //check if all subreddit selected, change queries accordingly
            if (subMap[sub].Name.Equals("all"))
            {
                gPostQ =
                   from N in postMap.Values
                   select N[2];

                gTopQ =
                   from N in postMap.Values
                   from M in N.PostComments
                   select M[2];

                gComQ =
                   from N in postMap.Values
                   from M in N.PostComments
                   from L in M.CommentReplies
                   select L[2];
            }

            int totals = 0;
            //print awards in posts
            foreach (var item in gPostQ)
            {
                totals += item;
            }

            outputBox.AppendText("\t Gold awards in Posts: " + totals + Environment.NewLine);
            totals = 0;

            //print awards for top comments
            foreach (var item in gTopQ)
            {
               
                totals += item;
            }
            outputBox.AppendText("\t Gold awards in Top Comments: " + totals + Environment.NewLine);

            totals = 0;

            //print awards for regular comments
            foreach (var item in gComQ)
            {
                totals += item;
            }
            outputBox.AppendText("\t Gold awards in Comments: " + totals + Environment.NewLine + Environment.NewLine);



        }

        //printPlat
        //params: N/A
        //purpose: handles platinum queries based on the checkboxes selected to produce the number of platinum awards granted to a subreddit
        //returns: N/A
        public void printPlat()
        {
            //store subreddit into smaller variable for ease of reading
            uint sub = nameToId(subComboBox.Items[subComboBox.SelectedIndex].ToString(), 2);

            //queries below
            var pPostQ =
                from N in postMap.Values
                where N.SubHome == sub
                select N[2];

            var pTopQ =
                from N in postMap.Values
                where N.SubHome == sub
                from M in N.PostComments
                select M[2];

            var pComQ =
                from N in postMap.Values
                where N.SubHome == sub
                from M in N.PostComments
                from L in M.CommentReplies
                select L[2];

            //check if all subreddits selected, change queries accordingly
            if (subMap[sub].Name.Equals("all"))
            {
                 pPostQ =
                    from N in postMap.Values
                    select N[2];

                 pTopQ =
                    from N in postMap.Values
                    from M in N.PostComments
                    select M[2];

                 pComQ =
                    from N in postMap.Values
                    from M in N.PostComments
                    from L in M.CommentReplies
                    select L[2];
            }

            int totals = 0;

            //print awards for posts
            foreach (var item in pPostQ)
            {
                totals += item;
            }

            outputBox.AppendText("\t Plat awards in Posts: " + totals + Environment.NewLine);
            totals = 0;

            //print awards for top comments
            foreach (var item in pTopQ)
            {
                totals += item;
            }
            outputBox.AppendText("\t Plat awards in Top Comments: " + totals + Environment.NewLine);

            totals = 0;

            //print awards for regular comments
            foreach (var item in pComQ)
            {
                totals += item;
            }
            outputBox.AppendText("\t Plat awards in Comments: " + totals + Environment.NewLine + Environment.NewLine);


        }


        //subQuery_Click
        //params: object sender, EventArgs e
        //purpose: handles query when user clicks the "Post score by Subreddit" button based on radio button selected
        //returns: N/A
        private void subQuery_Click(object sender, EventArgs e)
        {
            outputBox.Clear();

            //queries defined below
            var lowSubQuery =
                from N in postMap.Values
                group N by N.SubHome into subGroup
                orderby Name
                select new
                {
                    Name = subGroup.Key,
                    lowScore = subGroup.Min(x => x.Score),
                };

            var highSubQuery =
                from N in postMap.Values
                group N by N.SubHome into subGroup
                orderby Name
                select new
                {
                    Name = subGroup.Key,
                    highScore = subGroup.Max(x => x.Score),
                };

            var avgSubQuery =
                from N in postMap.Values
                group N by N.SubHome into subGroup
                orderby Name
                select new
                {
                    Name = subGroup.Key,
                    avgScore = subGroup.Average(x => x.Score),
                };

            //if no radio button clicked, error msg shown
            if (!lowSub.Checked && !highSub.Checked && !avgSub.Checked)
            {
                outputBox.AppendText("Please select an postScore range. " + Environment.NewLine);
                return;
            }

            //if low radio button checked
            if (lowSub.Checked)
            {
                outputBox.AppendText("Lowest Scored Posts For Each Subreddit:" + Environment.NewLine);
                outputBox.AppendText("----------------------------------------------------------" + Environment.NewLine);
                foreach(var item in lowSubQuery)
                {
                    outputBox.AppendText(subToStringTiny(subMap[item.Name].Name,Convert.ToInt32(item.lowScore)) + Environment.NewLine);
                }
            }

            //if high radio button checked
            if(highSub.Checked)
            {
                outputBox.AppendText("Highest Scored Posts For Each Subreddit:" + Environment.NewLine);
                outputBox.AppendText("----------------------------------------------------------" + Environment.NewLine);
                foreach (var item in highSubQuery)
                {
                    outputBox.AppendText(subToStringTiny(subMap[item.Name].Name,Convert.ToInt32(item.highScore)) + Environment.NewLine);
                }
            }


            //if avg radio button checked
            if(avgSub.Checked)
            {

                outputBox.AppendText("Average Scored Posts For Each Subreddit:" + Environment.NewLine);
                outputBox.AppendText("----------------------------------------------------------" + Environment.NewLine);

                string dash = "--";
                string output = "";


                foreach (var item in avgSubQuery)
                {
                    output = String.Format("{0, 30} {1,5} {2:0.00}", subMap[item.Name].Name, dash, Math.Round((Double)item.avgScore, 2));
                    outputBox.AppendText(output);
                    outputBox.AppendText(Environment.NewLine);
                }
            }

            endQueryMsg();


        }


        //subToStringTiny
        //params: string title: the subreddit title, int score: subreddits' score
        //purpose: formats the subreddits' score information in a concatenatated manner
        //returns: formatted string
        public string subToStringTiny(string title,int score)
        {
            string dash = "--";

            return String.Format("{0, 30} {1,5} {2, 10}", title, dash, score);
        }


        //userQuery_Click
        //params: object sender, EventArgs e
        //purpose: handles query when user clicks the "Post score by user" button based on radio button selected
        //returns: N/A
        private void userQuery_Click(object sender, EventArgs e)
        {
            outputBox.Clear();

            //queries defined below
            var lowPostQuery =
                from N in postMap.Values
                group N by N.AuthorId into postGroup
                orderby Name
                select new
                {
                    Name = postGroup.Key,
                    lowScore = postGroup.Min(x => x.Score),
            
                };

           var highPostQuery =
                from N in postMap.Values
                group N by N.AuthorId into postGroup
                orderby Name
            select new
            {
                Name = postGroup.Key,
                highScore= postGroup.Max(x => x.Score),

            };


            var avgPostQuery =
                from N in postMap.Values
                group N by N.AuthorId into postGroup
                orderby Name
            select new
            {
                Name = postGroup.Key,
                avgScore= postGroup.Average(x => x.Score),

             };

            //if no radio buttons clicked, send error message and quit
            if (!lowUser.Checked && !highUser.Checked && !avgUser.Checked)
            {
                outputBox.AppendText("Please select an postScore range. " + Environment.NewLine);
                return;
            }

            //lowest button checked
            if (lowUser.Checked)
            {
                outputBox.AppendText("Lowest Scored Posts For Each User:" + Environment.NewLine);
                outputBox.AppendText("----------------------------------------------------------" + Environment.NewLine);
                foreach (var item in lowPostQuery)
                {
                    outputBox.AppendText(usersToStringTiny(usersMap[Convert.ToUInt32(item.Name)].Name, Convert.ToInt32(item.lowScore)) + Environment.NewLine);
                }
                 endQueryMsg();

            }

            //highest button checked
            if (highUser.Checked)
            {
                outputBox.AppendText("Highest Scored Posts For Each User:" + Environment.NewLine);
                outputBox.AppendText("----------------------------------------------------------" + Environment.NewLine);
                foreach (var item in highPostQuery)
                {
                    outputBox.AppendText(usersToStringTiny(usersMap[Convert.ToUInt32(item.Name)].Name, Convert.ToInt32(item.highScore)) + Environment.NewLine);
                }
                endQueryMsg();
    
            }

            //average button checked
            if(avgUser.Checked)
            {
                string output = "";
                string dash = "--";

                outputBox.AppendText("Average Scored Posts For Each User:" + Environment.NewLine);
                outputBox.AppendText("----------------------------------------------------------" + Environment.NewLine);


                foreach (var item in avgPostQuery)
                {
                    output = String.Format("{0, 30} {1,5} {2:0.00}", usersMap[Convert.ToUInt32(item.Name)].Name, dash, Math.Round((Double)item.avgScore, 2));
                    outputBox.AppendText(output);
                    outputBox.AppendText(Environment.NewLine);
                }
                endQueryMsg();
            }



        }

        //usersToStringTiny
        //params: string title: the username, int score: user's score
        //purpose: formats the user's information in a concatenatated manner
        //returns: formatted string
        public string usersToStringTiny(string title, int score)
        {
            string dash = "--";

            return String.Format("{0, 30} {1,5} {2, 10}", title, dash, score);
        }
    }



}
