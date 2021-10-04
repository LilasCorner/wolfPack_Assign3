/***************************************************************
CSCI 473      Assignment 3     Fall 2021

Programmer: Lila & Harshith

ZIDS: Z1838117 & Z1891464

Section: 01

Date Due: 9/9/21
***************************************************************/

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace wolfPack_Assign3
{
    public class Post : IEnumerable, IComparable
    {
        private bool locked;
        private readonly uint id;
        private string title;
        private uint authorId;
        private string postContent;
        private readonly uint subHome;
        private uint upVotes;
        private uint downVotes;
        private uint weight;
        private readonly DateTime timeStamp = new DateTime();
        private int[] awards = new int[3];


        private Post[] _post;

        private List<Comment> postComments = new List<Comment>();

        public Post()
        {
            locked = false;
            id = wolfPack_Assign3.genId();
            Title = "";
            authorId = wolfPack_Assign3.genId();
            PostContent = "";
            subHome = wolfPack_Assign3.genId();
            timeStamp = DateTime.Now;
            UpVotes = 1;
            DownVotes = 0;
            Weight = 0;
            this[0] = 0; //silver
            this[1] = 0; //gold
            this[2] = 0; //plat
        }

        public Post(string _title, uint _authorId, string _postContent, uint _subHome)
        {
            locked = false;
            id = wolfPack_Assign3.genId();
            Title = _title;
            authorId = _authorId;
            PostContent = _postContent;
            subHome = _subHome;
            timeStamp = DateTime.Now;
            UpVotes = 1;
            DownVotes = 0;
            Weight = 0;

            this[0] = 0; //silver
            this[1] = 0; //gold
            this[2] = 0; //plat
        }

        public Post(params string[] tokens)
        {
            if (Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 18]) == 1)
            {
                locked = true;
            }
            else
            {
                locked = false;
            }
            if (!wolfPack_Assign3.UniqueId(Convert.ToUInt32(tokens[wolfPack_Assign3.POST_INDEX - 17])))
            {
                id = wolfPack_Assign3.genId();
            }
            else
            {
                id = Convert.ToUInt32(tokens[wolfPack_Assign3.POST_INDEX - 17]);
            }


            authorId = Convert.ToUInt32(tokens[wolfPack_Assign3.POST_INDEX - 16]);


            title = tokens[wolfPack_Assign3.POST_INDEX - 15];


            PostContent = tokens[wolfPack_Assign3.POST_INDEX - 14];


            subHome = Convert.ToUInt32(tokens[wolfPack_Assign3.POST_INDEX - 13]);


            UpVotes = Convert.ToUInt32(tokens[wolfPack_Assign3.POST_INDEX - 12]);

            DownVotes = Convert.ToUInt32(tokens[wolfPack_Assign3.POST_INDEX - 11]);


            Weight = Convert.ToUInt32(tokens[wolfPack_Assign3.POST_INDEX - 10]);

            timeStamp = new DateTime(Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 9]), Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 8]), Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 7]), Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 6]), Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 5]), Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 4]));


            this[0] = Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 3]); //silver
            this[1] = Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 2]); //gold
            this[2] = Convert.ToInt32(tokens[wolfPack_Assign3.POST_INDEX - 1]); //plat

        }


        //properties
        public int this[int index]
        {
            get { return awards[index]; }
            set { awards[index] = value; }
        }

        public uint Id
        {
            get { return id; }
        }

        public DateTime TimeStamp
        {
            get { return timeStamp; }
        }

        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        public double Score => Convert.ToInt32(UpVotes) - Convert.ToInt32(DownVotes);
        public string Title
        {
            get { return title; }
            set
            {
                if (wolfPack_Assign3.validateName(value, 1, 100) && !wolfPack_Assign3.findBadWords(value))
                {
                    title = value;
                }
                else
                {
                    title = "";
                }
            }
        }

        public List<Comment> PostComments
        {
            get { return postComments; }
        }

        public uint AuthorId
        {
            get { return authorId; }


        }
        // public string PostContent

        //properties

        public void addComment(Comment newCom)
        {
            postComments.Add(newCom);
        }

        public string PostContent
        {

            get { return postContent; }
            set
            {
                if (wolfPack_Assign3.validateName(value, 1, 1000) && !wolfPack_Assign3.findBadWords(value))
                {
                    postContent = value;
                }
                else
                {
                    postContent = "";
                }
            }
        }


        public uint SubHome
        {
            get { return subHome; }
        }

        public uint UpVotes
        {
            get { return upVotes; }
            set
            {
                upVotes = value;
            }
        }

        public uint DownVotes
        {
            get { return downVotes; }
            set
            {
                downVotes = value;
            }
        }

        public uint Weight
        {
            get { return weight; }
            set
            {
                weight = value;
            }
        }
        public double PostRating
        {
            get
            {
                if (Weight == 0)
                {
                    return Score;
                }
                else if (Weight == 1)
                {
                    return Score * .66;
                }

                return 0.0;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public PostEnum GetEnumerator()
        {
            return new PostEnum(_post);
        }

        public int CompareTo(Object alpha)
        {
            if (alpha == null) throw new ArgumentNullException(); // Always... check for null values

            Post rightOp = alpha as Post;

            if (rightOp != null) // Protect against a failed typecasting
                return PostRating.CompareTo(rightOp.PostRating);
            else
                throw new ArgumentException("[Post]:CompareTo argument is not a Post");
        }
        public override string ToString()
        {
            return "<" + Id + ">" + " [" + wolfPack_Assign3.subMap[SubHome].Name + "] " + "(" + Score + ") " + Title + " : " + PostContent + " - " + " |" + timeStamp + "| \n";
        }

        public string toStringTiny()
        {
            string shortTitle = "";
            string dash = "--";


            if (Title.Length > 35)
            {
                shortTitle = Title.Substring(0, 35);
            }
            else
            {
                shortTitle = Title;
            }


            return String.Format("{0, 40} {1,5} {2, 10}", shortTitle, dash, Score);
            
        }

        public string ToStringShort()
        {
            string shortTitle = "";
            string locked = "";

            if (Title.Length > 35)
            {
                shortTitle = Title.Substring(0, 35) + "...";
            }
            else
            {
                shortTitle = Title;
            }

            if (Locked)
            {
                locked = "**LOCKED**";
            }

            return "<" + Id + ">" + " [" + wolfPack_Assign3.subMap[SubHome].Name + "] " + "(" + Score + ") " + shortTitle + " " + locked + " - " + wolfPack_Assign3.usersMap[authorId].Name + " |" + timeStamp + "| \n";
        }


        
    }
    public class PostEnum : IEnumerator
    {
        public Post[] _post;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public PostEnum(Post[] list)
        {
            _post = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _post.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Post Current
        {
            get
            {
                try
                {
                    return _post[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}









