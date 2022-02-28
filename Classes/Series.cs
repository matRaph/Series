using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series
{
    public class Series : MainEntity
    {
        private Genre Genre { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        private bool Excluded { get; set; }

        public Series (int ID, Genre Genre, string Title, string Description, int Year)
        {
            this.ID = ID;
            this.Genre = Genre;
            this.Title = Title;
            this.Description = Description;
            this.Year = Year;
            this.Excluded = false;
        }

        public override string ToString()
        {
            string returnVar = "";
            returnVar += "Genre: " + this.Genre + Environment.NewLine;
            returnVar += "Title: " + this.Title + Environment.NewLine;
            returnVar += "Description: " + this.Description + Environment.NewLine;
            returnVar += "Year: " + this.Year;
            return returnVar;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnID()
        {
            return this.ID;
        }

        public void Delete()
        {
            this.Excluded = true;
        }
    }
}
