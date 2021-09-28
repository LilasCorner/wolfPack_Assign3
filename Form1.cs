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
        }

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


    }

}
