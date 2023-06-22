using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskNS.Domain.Constants;

public static class ErrorMessages
{
    // MAIN
    public const string IdRequired = "Id is required";
    public const string IdIncorrect = "Id is incorrect";

    // TITLE
    public const string TitleTooShort = "Title is too short";
    public const string TitleTooLong = "Title is too long";
    public const string TitleRequired = "Title is required";

    // Description
    public const string DescriptionTooShort = "Description is too short";
    public const string DescriptionTooLong = "Description is too long";
    public const string DescriptionRequired = "Description is required";

    // Author name
    public const string AuthorNameTooShort = "Author name is too short";
    public const string AuthorNameTooLong = "Author name is too long";
    public const string AuthorNameRequired = "Author name is required";

    // Author email
    public const string AuthorEmailRequired = "Author email is required";
}
