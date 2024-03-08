using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindle_Vocabulary.Entities
{
    internal class Vocabulary : IComparable
    {
        public String Word { get; set; }
        public String Book {  get; set; }
        public DateTime AddedOn { get; set; }

        public override bool Equals(object? obj)
        {
            if(!(obj is Vocabulary)|| obj==null) return false;
            Vocabulary other = obj as Vocabulary;
            return Word.Equals(other.Word);
        }

        public override int GetHashCode()
        {
            return Word.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Word:{Word}\n");
            sb.Append($"Book:{Book}\n");
            sb.Append($"AddedOn: {AddedOn}\n");
            return sb.ToString();
        }

        public int CompareTo(object? obj)
        {
            return Word.CompareTo(obj);
        }

        public Vocabulary(string word, string book, DateTime addedOn)
        {
            Word = word;
            Book = book;
            AddedOn = addedOn;
        }
    }
}
