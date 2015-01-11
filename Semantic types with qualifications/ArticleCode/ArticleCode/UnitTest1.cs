using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using SemanticTypes;

namespace ArticleCode
{

    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {

    }
}

namespace ArticleCode2
{
    public class DatabaseId : SemanticType<int, DatabaseId>
    {
        // Database ids must be greater than 0.
        static DatabaseId() { IsValid = v => v > 0; }

        public DatabaseId(int id) : base(id) { }
    }

    // Ids now use semantic type DatabaseId

    public class Book
    {
        public DatabaseId BookId { get; set; }
        public string Title { get; set; }
        public DatabaseId AuthorId { get; set; }
    }

    public class Author
    {
        public DatabaseId AuthorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }


    [TestClass]
    public class UnitTest2
    {
        public DatabaseId getAuthorIdByName(string authorName)
        {
            return null;
        }

        public Book getBookByBookId(DatabaseId bookId)
        {
            return null;
        }

        public void f()
        {
            DatabaseId unclearVariableName = getAuthorIdByName("Ernest Hemingway");

            // ... some code in some method far far away ...

            // Passing an author id to a method that expects a book id
            Book book = getBookByBookId(unclearVariableName);
        }
    }
}

namespace ArticleCode3
{
    public class DatabaseId<Q> : SemanticType<int, DatabaseId<Q>>
    {
        // Database ids must be greater than 0.
        static DatabaseId() { IsValid = v => v > 0; }

        public DatabaseId(int id) : base(id) { }
    }

    // Ids now use semantic type DatabaseId

    public class Book
    {
        public DatabaseId<Book> BookId { get; set; }
        public string Title { get; set; }
        public DatabaseId<Author> AuthorId { get; set; }
    }

    public class Author
    {
        public DatabaseId<Author> AuthorId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }


    [TestClass]
    public class UnitTest2
    {
        public DatabaseId<Author> getAuthorIdByName(string authorName)
        {
            return null;
        }

        public Book getBookByBookId(DatabaseId<Book> bookId)
        {
            return null;
        }

        public void f()
        {
            DatabaseId<Author> unclearVariableName = getAuthorIdByName("Ernest Hemingway");

            // ... some code in some method far far away ...

            // NO LONGER COMPILES, because trying to pass a DatabaseId<Author> to a DatabaseId<Book>
            Book book = getBookByBookId(unclearVariableName);
        }
    }
}



