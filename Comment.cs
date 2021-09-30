/***************************************************************
CSCI 473      Assignment 3     Fall 2021

Programmer: Lila & Harshith

ZIDS: Z1838117 & Z1891464

Section: 01

Date Due: 9/9/21
***************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace wolfPack_Assign3
{
    public class Comment : IEnumerable, IComparable
    {
        public Comment[] _comment;
        readonly uint id; //— a unique identifier for this Comment.
        readonly uint authorID; //— corresponding ID of the User that posted this.
        string content;//— screen for vulgarities.
        readonly uint parentID; //— corresponding ID of either the Post or Comment this replies to.
        uint upVotes;
        uint downVotes;
        uint indent;
        readonly DateTime timeStamp = new DateTime();
        List<Comment> commentReplies = new List<Comment>();
        private int[] awards = new int[3];


        //default constructor
        public Comment()
        {
            id = wolfPack_Assign3.genId();
            authorID = wolfPack_Assign3.genId();
            Content = "";
            parentID = wolfPack_Assign3.genId();
            UpVotes = 1;
            DownVotes = 0;
            timeStamp = DateTime.Now;
            indent = 0;
            awards[0] = 0; //silver
            awards[1] = 0; //gold
            awards[2] = 0; //plat
        }


        //alt constructor
        public Comment(params string[] tokens)
        {

            id = Convert.ToUInt32(tokens[wolfPack_Assign3.COM_INDEX - 15]);

            authorID = Convert.ToUInt32(tokens[wolfPack_Assign3.COM_INDEX - 14]);

            Content = tokens[wolfPack_Assign3.COM_INDEX - 13];

            parentID = Convert.ToUInt32(tokens[wolfPack_Assign3.COM_INDEX - 12]);

            UpVotes = Convert.ToUInt32(tokens[wolfPack_Assign3.COM_INDEX - 11]);
            DownVotes = Convert.ToUInt32(tokens[wolfPack_Assign3.COM_INDEX - 10]);
            timeStamp = new DateTime(Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 9]), Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 8]), Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 7]), Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 6]), Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 5]), Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 4]));

            this[0] = Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 3]); //silver
            this[1] = Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 2]); //gold
            this[2] = Convert.ToInt32(tokens[wolfPack_Assign3.COM_INDEX - 1]); //plat
        }

        //new comment constructor

        public Comment(string _content, uint _authorId, uint _parentId)
        {

            id = wolfPack_Assign3.genId();
            authorID = _authorId;
            Content = _content;
            parentID = _parentId;
            UpVotes = 1;
            DownVotes = 0;
            timeStamp = DateTime.Now;
            this[0] = 0; //silver
            this[1] = 0; //gold
            this[2] = 0; //plat
        }

        //adds new comment to commentReplies List
        public void addComment(Comment newCom)
        {
            commentReplies.Add(newCom);
        }

        //properties below

        public int this[int index]
        {
            get { return awards[index]; }
            set { awards[index] = value; }
        }



        public uint Id
        {
            get { return id; }

        }

        public uint AuthorId
        {
            get { return authorID; }

        }

        public List<Comment> CommentReplies
        {
            get { return commentReplies; }
        }

        public string Content
        {
            get { return content; }
            set
            {
                if (wolfPack_Assign3.findBadWords(value))
                {
                    content = "";
                    throw new FoulLanguageException();
                }
                else
                {
                    content = value;
                }
            }
        }

        public uint Indent
        {
            get { return indent; }
            set { indent = value; }
        }

        public uint ParentId
        {
            get { return parentID; }
        }

        public uint UpVotes
        {
            get { return upVotes; }
            set { upVotes = value; }
        }

        public uint DownVotes
        {
            get { return downVotes; }
            set { downVotes = value; }
        }

        public DateTime TimeStamp
        {
            get { return timeStamp; }
        }

        public int Score => Convert.ToInt32(UpVotes) - Convert.ToInt32(DownVotes);

        public int CompareTo(object com)
        {
            if (com == null) throw new ArgumentNullException();

            Comment rightOp = com as Comment;

            if (rightOp != null) // Protect against a failed typecasting
                return Score.CompareTo(rightOp.Score);
            else
                throw new ArgumentException("[Comment]:CompareTo argument is not a Comment");
        }

        // Implementation for the GetEnumerator method.
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public CommentEnum GetEnumerator()
        {
            return new CommentEnum(_comment);
        }

        public override string ToString()
        {
            return "<" + Id + ">" + " (" + Score + ") " + Content + " - " + wolfPack_Assign3.usersMap[AuthorId].Name + " |" + TimeStamp + "| \n\n";

        }

        public string toStringTiny()
        {
            string shortTitle = "";


            if (Content.Length > 35)
            {
                shortTitle = Content.Substring(0, 35);
            }
            else
            {
                shortTitle = Content;
            }


            return String.Format("{0, 60} -- {1, 10}", shortTitle, Score);
        }

    }

    // When you implement IEnumerable, you must also implement IEnumerator.
    public class CommentEnum : IEnumerator
    {
        public Comment[] _comment;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public CommentEnum(Comment[] list)
        {
            _comment = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < _comment.Length);
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

        public Comment Current
        {
            get
            {
                try
                {
                    return _comment[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
