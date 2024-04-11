using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iss.Entity
{
    public class Template
    {
        private string title;
        private string description;
        private string theme;
        private string photo;
        //getters and setters
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Theme { get => theme; set => theme = value; }
        public string Photo { get => photo; set => photo = value; }
        //constructor
        public Template(string title, string description, string theme, string photo)
        {
            this.title = title;
            this.description = description;
            this.theme = theme;
            this.photo = photo;
        }

    }
}
