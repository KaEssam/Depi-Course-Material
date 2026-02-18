using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    internal class Book
    {
        //field => data storage

        public string title;
        //props => data controll
        public int Id { get; init; }

        //ctor 
        public Book(int id)
        {
            Id = id;
        }

        public Book(int id, string title):this(id)
        {
            this.title = title;
        }


        //private void SetId()
        //{
        //    Id = 1;
        //}

    }
}
