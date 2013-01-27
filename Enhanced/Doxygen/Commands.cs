namespace Enhanced.Doxygen
{
    using Enhanced.Classification;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides names for Doxygen commands <see cref="http://www.stack.nl/~dimitri/doxygen/manual/commands.html"/>.
    /// </summary>
    internal static class Commands
    {
        /// <summary>
        /// \addtogroup <name> [(title)]
        /// 
        /// Defines a group just like \defgroup, but in contrast to that command using the same <name> more than once
        /// will not result in a warning, but rather one group with a merged documentation and the first title found in
        /// any of the commands.
        /// 
        /// The title is optional, so this command can also be used to add a number of entities to an existing group
        /// using @{ and @} like this:
        /// 
        ///   /*! \addtogroup mygrp
        ///    *  Additional documentation for group 'mygrp'
        ///    *  @{
        ///    */
        /// 
        ///   /*!
        ///    *  A function
        ///    */
        ///   void func1()
        ///   {
        ///   }
        /// 
        ///   /*! Another function */
        ///   void func2()
        ///   {
        ///   }
        /// 
        ///   /*! @} */
        /// 
        /// See Also
        ///     page Grouping, sections \defgroup, \ingroup, and \weakgroup.
        /// 
        /// </summary>
        [Pattern(@"^*(?<" + FormatNames.DoxygenCommand +
                 @">[@\\]addtogroup)\s+(?<" + FormatNames.DoxygenGroupName +
                 @">\w+\b)?\s+(?<" + FormatNames.DoxygenGroupTitle +
                 @">\w+\b)?")]
        public const string Addtogroup = "addtogroup";

        /// <summary>
        /// \callgraph
        /// 
        /// When this command is put in a comment block of a function or method and HAVE_DOT is set to YES, then
        /// doxygen will generate a call graph for that function (provided the implementation of the function or method
        /// calls other documented functions). The call graph will be generated regardless of the value of CALL_GRAPH.
        /// 
        /// Note
        ///     The completeness (and correctness) of the call graph depends on the doxygen code parser which is not
        ///     perfect.
        /// 
        /// See Also
        ///     section \callergraph.
        /// 
        /// </summary>
        public const string Callgraph = "callgraph";

        /// <summary>
        /// \callergraph
        /// 
        /// When this command is put in a comment block of a function or method and HAVE_DOT is set to YES, then 
        /// doxygen will generate a caller graph for that function (provided the implementation of the function or 
        /// method calls other documented functions). The caller graph will be generated regardless of the value of 
        /// CALLER_GRAPH.
        /// 
        /// Note
        ///     The completeness (and correctness) of the caller graph depends on the doxygen code parser which is not 
        ///     perfect.
        /// 
        /// See Also
        ///     section \callgraph.
        /// 
        /// </summary>
        public const string Callergraph = "callergraph";

        /// <summary>
        /// \category <name> [<header-file>] [<header-name>]
        /// 
        /// For Objective-C only: Indicates that a comment block contains documentation for a class category with 
        /// name <name>. The arguments are equal to the \class command.
        /// 
        /// See Also
        ///     section \class.
        /// 
        /// </summary>
        public const string Category = "category";

        /// <summary>
        /// \class <name> [<header-file>] [<header-name>]
        /// 
        /// Indicates that a comment block contains documentation for a class with name <name>. Optionally a header 
        /// file and a header name can be specified. If the header-file is specified, a link to a verbatim copy of the 
        /// header will be included in the HTML documentation. The <header-name> argument can be used to overwrite the 
        /// name of the link that is used in the class documentation to something other than <header-file>. This can be
        /// useful if the include name is not located on the default include path (like <X11/X.h>). With 
        /// the <header-name> argument you can also specify how the include statement should look like, by adding 
        /// either quotes or sharp brackets around the name. Sharp brackets are used if just the name is given. Note
        /// that the last two arguments can also be specified using the \headerfile command.
        /// 
        /// Example:
        /// 
        ///     /* A dummy class */
        /// 
        ///     class Test
        ///     {
        ///     };
        /// 
        ///     /*! \class Test class.h "inc/class.h"
        ///      *  \brief This is a test class.
        ///      *
        ///      * Some details about the Test class
        ///      */
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// </summary>
        public const string Class = "class";

        /// <summary>
        /// \def <name>
        /// 
        /// Indicates that a comment block contains documentation for a #define macro.
        /// 
        /// Example:
        /// 
        ///     /*! \file define.h
        ///         \brief testing defines
        ///         
        ///         This is to test the documentation of defines.
        ///     */
        /// 
        ///     /*!
        ///       \def MAX(x,y)
        ///       Computes the maximum of \a x and \a y.
        ///     */
        /// 
        ///     /*! 
        ///        Computes the absolute value of its argument \a x.
        ///     */
        ///     #define ABS(x) (((x)>0)?(x):-(x))
        ///     #define MAX(x,y) ((x)>(y)?(x):(y))
        ///     #define MIN(x,y) ((x)>(y)?(y):(x)) 
        ///             /*!< Computes the minimum of \a x and \a y. */
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// </summary>
        public const string Def = "def";

        /// <summary>
        /// \defgroup <name> (group title)
        /// 
        /// Indicates that a comment block contains documentation for a group of classes, files or namespaces. This can
        /// be used to categorize classes, files or namespaces, and document those categories. You can also use groups
        /// as members of other groups, thus building a hierarchy of groups.
        /// 
        /// The <name> argument should be a single-word identifier.
        /// 
        /// See Also
        ///     page Grouping, sections \ingroup, \addtogroup, and \weakgroup.
        /// 
        /// </summary>
        public const string Defgroup = "defgroup";

        /// <summary>
        /// \dir [<path fragment>]
        /// 
        /// Indicates that a comment block contains documentation for a directory. The "path fragment" argument should
        /// include the directory name and enough of the path to be unique with respect to the other directories in the
        /// project. The STRIP_FROM_PATH option determines what is stripped from the full path before it appears in the
        /// output.
        /// </summary>
        public const string Dir = "dir";

        /// <summary>
        /// \enum <name>
        /// 
        /// Indicates that a comment block contains documentation for an enumeration, with name <name>. If the enum is
        /// a member of a class and the documentation block is located outside the class definition, the scope of the
        /// class should be specified as well. If a comment block is located directly in front of an enum declaration,
        /// the \enum comment may be omitted.
        /// 
        /// Note:
        ///     The type of an anonymous enum cannot be documented, but the values of an anonymous enum can.
        /// 
        /// Example:
        /// 
        ///     class Test
        ///     {
        ///       public:
        ///         enum TEnum { Val1, Val2 };
        /// 
        ///         /*! Another enum, with inline docs */
        ///         enum AnotherEnum 
        ///         { 
        ///           V1, /*!< value 1 */
        ///           V2  /*!< value 2 */
        ///         };
        ///     };
        /// 
        ///     /*! \class Test
        ///      * The class description.
        ///      */
        /// 
        ///     /*! \enum Test::TEnum
        ///      * A description of the enum type.
        ///      */
        /// 
        ///     /*! \var Test::TEnum Test::Val1
        ///      * The description of the first enum value.
        ///      */
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// </summary>
        public const string Enum = "enum";

        /// <summary>
        /// \example <file-name>
        /// 
        /// Indicates that a comment block contains documentation for a source code example. The name of the source
        /// file is <file-name>. The text of this file will be included in the documentation, just after the
        /// documentation contained in the comment block. All examples are placed in a list. The source code is scanned
        /// for documented members and classes. If any are found, the names are cross-referenced with the
        /// documentation. Source files or directories can be specified using the EXAMPLE_PATH tag of doxygen's
        /// configuration file.
        /// 
        /// If <file-name> itself is not unique for the set of example files specified by the EXAMPLE_PATH tag, you can
        /// include part of the absolute path to disambiguate it.
        /// 
        /// If more than one source file is needed for the example, the \include command can be used.
        /// 
        /// Example:
        /// 
        ///     /** A Test class.
        ///      *  More details about this class.
        ///      */
        /// 
        ///     class Test
        ///     {
        ///       public:
        ///         /** An example member function.
        ///          *  More details about this function.
        ///          */
        ///         void example();
        ///     };
        /// 
        ///     void Test::example() {}
        /// 
        ///     /** \example example_test.cpp
        ///      * This is an example of how to use the Test class.
        ///      * More details about this example.
        ///      */
        /// 
        ///     Where the example file example_test.cpp looks as follows:
        /// 
        ///     void main()
        ///     {
        ///       Test t;
        ///       t.example();
        ///     }
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// See Also
        ///     section \include.
        /// 
        /// </summary>
        public const string Example = "example";

        /// <summary>
        /// \endinternal
        /// 
        /// This command ends a documentation fragment that was started with a \internal command. The text between
        /// \internal and \endinternal will only be visible if INTERNAL_DOCS is set to YES.
        /// </summary>
        public const string Endinternal = "endinternal";

        /// <summary>
        /// \extends <name>
        /// 
        /// This command can be used to manually indicate an inheritance relation, when the programming language does
        /// not support this concept natively (e.g. C).
        /// 
        /// The file manual.c in the example directory shows how to use this command.
        /// Click here for the corresponding HTML documentation that is generated by doxygen.
        /// 
        /// See Also
        ///     section \implements and section \memberof
        /// 
        /// </summary>
        public const string Extends = "extends";

        /// <summary>
        /// \file [<name>]
        /// 
        /// Indicates that a comment block contains documentation for a source or header file with name <name>. The
        /// file name may include (part of) the path if the file-name alone is not unique. If the file name is omitted
        /// (i.e. the line after \file is left blank) then the documentation block that contains the \file command will
        /// belong to the file it is located in.
        /// 
        /// Important:
        ///     The documentation of global functions, variables, typedefs, and enums will only be included in the
        ///     output if the file they are in is documented as well.
        /// 
        /// Example:
        /// 
        ///     /** \file file.h
        ///      * A brief file description.
        ///      * A more elaborated file description.
        ///      */
        /// 
        ///     /**
        ///      * A global integer value.
        ///      * More details about this value.
        ///      */
        ///     extern int globalValue;
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// Note
        ///     In the above example JAVADOC_AUTOBRIEF has been set to YES in the configuration file.
        /// 
        /// </summary>
        public const string File = "file";

        /// <summary>
        /// \fn (function declaration)
        /// 
        /// Indicates that a comment block contains documentation for a function (either global or as a member of a
        /// class). This command is only needed if a comment block is not placed in front (or behind) the function
        /// declaration or definition.
        /// 
        /// If your comment block is in front of the function declaration or definition this command can (and to avoid
        /// redundancy should) be omitted.
        /// 
        /// A full function declaration including arguments should be specified after the \fn command on a single line,
        /// since the argument ends at the end of the line!
        /// 
        /// This command is equivalent to \var, \typedef, and \property.
        /// 
        /// Warning
        ///     Do not use this command if it is not absolutely needed, since it will lead to duplication of
        ///     information and thus to errors.
        /// 
        /// Example:
        /// 
        ///     class Test
        ///     {
        ///       public:
        ///         const char *member(char,int) throw(std::out_of_range);
        ///     };
        /// 
        ///     const char *Test::member(char c,int n) throw(std::out_of_range) {}
        /// 
        ///     /*! \class Test
        ///      * \brief Test class.
        ///      *
        ///      * Details about Test.
        ///      */
        /// 
        ///     /*! \fn const char *Test::member(char c,int n) 
        ///      *  \brief A member function.
        ///      *  \param c a character.
        ///      *  \param n an integer.
        ///      *  \exception std::out_of_range parameter is out of range.
        ///      *  \return a character pointer.
        ///      */
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// See Also
        ///     sections \var, \property, and \typedef.
        /// 
        /// </summary>
        public const string Fn = "fn";

        /// <summary>
        /// \headerfile <header-file> [<header-name>]
        /// 
        /// Intended to be used for class, struct, or union documentation, where the documentation is in front of the
        /// definition. The arguments of this command are the same as the second and third argument of \class.
        /// The <header-file> name refers to the file that should be included by the application to obtain the
        /// definition of the class, struct, or union. The <header-name> argument can be used to overwrite the name of
        /// the link that is used in the class documentation to something other than <header-file>. This can be useful
        /// if the include name is not located on the default include path (like <X11/X.h>).
        /// 
        /// With the <header-name> argument you can also specify how the include statement should look like, by adding
        /// either double quotes or sharp brackets around the name. By default sharp brackets are used if just the name
        /// is given.
        /// 
        /// If a pair of double quotes is given for either the <header-file> or <header-name> argument, the current
        /// file (in which the command was found) will be used but with quotes. So for a comment block with
        /// a \headerfile command inside a file test.h, the following three commands are equivalent:
        /// 
        ///   \headerfile test.h "test.h"
        ///   \headerfile test.h ""
        ///   \headerfile "" 
        /// 
        /// To get sharp brackets you do not need to specify anything, but if you want to be explicit you could use any
        /// of the following:
        /// 
        ///   \headerfile test.h <test.h>
        ///   \headerfile test.h <>
        ///   \headerfile <> 
        /// 
        /// To globally reverse the default include representation to local includes you can set FORCE_LOCAL_INCLUDES
        /// to YES.
        /// 
        /// To disable the include information altogether set SHOW_INCLUDE_FILES to NO.
        /// </summary>
        public const string Headerfile = "headerfile";

        /// <summary>
        /// \hideinitializer
        /// 
        /// By default the value of a define and the initializer of a variable are displayed unless they are longer
        /// than 30 lines. By putting this command in a comment block of a define or variable, the initializer is
        /// always hidden. The maximum number of initialization lines can be changed by means of the configuration
        /// parameter MAX_INITIALIZER_LINES, the default value is 30.
        /// 
        /// See Also
        ///     section \showinitializer.
        /// 
        /// </summary>
        public const string Hideinitializer = "hideinitializer";

        /// <summary>
        /// \implements <name>
        /// 
        /// This command can be used to manually indicate an inheritance relation, when the programming language does
        /// not support this concept natively (e.g. C).
        /// 
        /// The file manual.c in the example directory shows how to use this command.
        /// Click here for the corresponding HTML documentation that is generated by doxygen.
        /// 
        /// See Also
        ///     section \extends and section \memberof
        /// 
        /// </summary>
        public const string Implements = "implements";

        /// <summary>
        /// \ingroup (<groupname> [<groupname> <groupname>])
        /// 
        /// If the \ingroup command is placed in a comment block of a class, file or namespace, then it will be added
        /// to the group or groups identified by <groupname>.
        /// 
        /// See Also
        ///     page Grouping, sections \defgroup, \addtogroup, and \weakgroup
        /// 
        /// </summary>
        public const string Ingroup = "ingroup";

        /// <summary>
        /// \interface <name> [<header-file>] [<header-name>]
        /// 
        /// Indicates that a comment block contains documentation for an interface with name <name>. The arguments are
        /// equal to the arguments of the \class command.
        /// 
        /// See Also
        ///     section \class.
        /// 
        /// </summary>
        public const string Interface = "interface";

        /// <summary>
        /// \internal
        /// 
        /// This command starts a documentation fragment that is meant for internal use only. The fragment naturally
        /// ends at the end of the comment block. You can also force the internal section to end earlier by using
        /// the \endinternal command.
        /// 
        /// If the \internal command is put inside a section (see for example \section) all subsections after the
        /// command are considered to be internal as well. Only a new section at the same level will end the
        /// fragment that is considered internal.
        /// 
        /// You can use INTERNAL_DOCS in the config file to show (YES) or hide (NO) the internal documentation.
        /// 
        /// See Also
        ///     section \endinternal.
        /// 
        /// </summary>
        public const string Internal = "internal";

        /// <summary>
        /// \mainpage [(title)]
        /// 
        /// If the \mainpage command is placed in a comment block the block is used to customize the index page
        /// (in HTML) or the first chapter (in LaTeX).
        /// 
        /// The title argument is optional and replaces the default title that doxygen normally generates.
        /// If you do not want any title you can specify notitle as the argument of \mainpage.
        /// 
        /// Here is an example:
        /// 
        /// /*! \mainpage My Personal Index Page
        ///  *
        ///  * \section intro_sec Introduction
        ///  *
        ///  * This is the introduction.
        ///  *
        ///  * \section install_sec Installation
        ///  *
        ///  * \subsection step1 Step 1: Opening the box
        ///  *
        ///  * etc...
        ///  */
        /// 
        /// You can refer to the main page using \ref index.
        /// 
        /// See Also
        ///     section \section, section \subsection, and section \page.
        /// 
        /// </summary>
        public const string Mainpage = "mainpage";

        /// <summary>
        /// \memberof <name>
        /// 
        /// This command makes a function a member of a class in a similar way as \relates does, only with this command
        /// the function is represented as a real member of the class. This can be useful when the programming language
        /// does not support the concept of member functions natively (e.g. C).
        /// 
        /// It is also possible to use this command together with \public, \protected or \private.
        /// 
        /// The file manual.c in the example directory shows how to use this command.
        /// Click here for the corresponding HTML documentation that is generated by doxygen.
        /// 
        /// See Also
        ///     sections \extends, \implements, \public, \protected and \private.
        /// 
        /// </summary>
        public const string Memberof = "memberof";

        /// <summary>
        /// \name [(header)]
        /// 
        /// This command turns a comment block into a header definition of a member group. The comment block should be
        /// followed by a //@{ ... //@} block containing the members of the group.
        /// 
        /// See section Member Groups for an example.
        /// </summary>
        public const string Name = "name";

        /// <summary>
        /// \namespace <name>
        /// 
        /// Indicates that a comment block contains documentation for a namespace with name <name>.
        /// </summary>
        public const string Namespace = "namespace";

        /// <summary>
        /// \nosubgrouping
        /// 
        /// This command can be put in the documentation of a class. It can be used in combination with member grouping
        /// to avoid that doxygen puts a member group as a subgroup of a Public/Protected/Private/... section.
        /// 
        /// See Also
        ///     sections \publicsection, \protectedsection and \privatesection. 
        /// 
        /// </summary>
        public const string Nosubgrouping = "nosubgrouping";

        /// <summary>
        /// \overload [(function declaration)]
        /// 
        /// This command can be used to generate the following standard text for an overloaded member function:
        /// 
        ///     This is an overloaded member function, provided for convenience. It differs from the above function
        ///     only in what argument(s) it accepts.
        /// 
        /// If the documentation for the overloaded member function is not located in front of the function declaration
        /// or definition, the optional argument should be used to specify the correct function.
        /// 
        /// Any other documentation that is inside the documentation block will by appended after the generated
        /// message.
        /// 
        /// Note 1:
        ///     You are responsible that there is indeed an earlier documented member that is overloaded by this one.
        ///     To prevent that document reorders the documentation you should set SORT_MEMBER_DOCS to NO in this case. 
        /// 
        /// Note 2:
        ///     The \overload command does not work inside a one-line comment. 
        /// 
        /// Example:
        /// 
        ///     class Test 
        ///     {
        ///       public:
        ///         void drawRect(int,int,int,int);
        ///         void drawRect(const Rect &r);
        ///     };
        /// 
        ///     void Test::drawRect(int x,int y,int w,int h) {}
        ///     void Test::drawRect(const Rect &r) {}
        /// 
        ///     /*! \class Test
        ///      *  \brief A short description.
        ///      *   
        ///      *  More text.
        ///      */
        /// 
        ///     /*! \fn void Test::drawRect(int x,int y,int w,int h)
        ///      * This command draws a rectangle with a left upper corner at ( \a x , \a y ),
        ///      * width \a w and height \a h. 
        ///      */
        /// 
        ///     /*!
        ///      * \overload void Test::drawRect(const Rect &r)
        ///      */
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// </summary>
        public const string Overload = "overload";

        /// <summary>
        /// \package <name>
        /// 
        /// Indicates that a comment block contains documentation for a Java package with name <name>.
        /// </summary>
        public const string Package = "package";

        /// <summary>
        /// \page <name> (title)
        /// 
        /// Indicates that a comment block contains a piece of documentation that is not directly related to one
        /// specific class, file or member. The HTML generator creates a page containing the documentation. The LaTeX
        /// generator starts a new section in the chapter 'Page documentation'.
        /// 
        /// Example:
        /// 
        ///     /*! \page page1 A documentation page
        ///       \tableofcontents
        ///       Leading text.
        ///       \section sec An example section
        ///       This page contains the subsections \ref subsection1 and \ref subsection2.
        ///       For more info see page \ref page2.
        ///       \subsection subsection1 The first subsection
        ///       Text.
        ///       \subsection subsection2 The second subsection
        ///       More text.
        ///     */
        /// 
        ///     /*! \page page2 Another page
        ///       Even more info.
        ///     */
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// Note:
        ///     The <name> argument consists of a combination of letters and number digits. If you wish to use upper
        ///     case letters (e.g. MYPAGE1), or mixed case letters (e.g. MyPage1) in the <name> argument, you should
        ///     set CASE_SENSE_NAMES to YES. However, this is advisable only if your file system is case sensitive.
        ///     Otherwise (and for better portability) you should use all lower case letters (e.g. mypage1) for <name>
        ///     in all references to the page.
        /// 
        /// See Also
        ///     section \section, section \subsection, and section \ref.
        /// 
        /// </summary>
        public const string Page = "page";

        /// <summary>
        /// \private
        /// 
        /// Indicates that the member documented in the comment block is private, i.e., should only be accessed by
        /// other members in the same class.
        /// 
        /// Note that Doxygen automatically detects the protection level of members in object-oriented languages.
        /// This command is intended for use only when the language does not support the concept of protection level
        /// natively (e.g. C, PHP 4).
        /// 
        /// For starting a section of private members, in a way similar to the "private:" class marker in C++,
        /// use \privatesection.
        /// 
        /// See Also
        ///     sections \memberof, \public, \protected and \privatesection.
        /// 
        /// </summary>
        public const string Private = "private";

        /// <summary>
        /// \privatesection
        /// 
        /// Starting a section of private members, in a way similar to the "private:" class marker in C++. Indicates
        /// that the member documented in the comment block is private, i.e., should only be accessed by other members
        /// in the same class.
        /// 
        /// See Also
        ///     sections \memberof, \public, \protected and \private.
        /// 
        /// </summary>
        public const string Privatesection = "privatesection";

        /// <summary>
        /// \property (qualified property name)
        /// 
        /// Indicates that a comment block contains documentation for a property (either global or as a member
        /// of a class). This command is equivalent to \var, \typedef, and \fn.
        /// 
        /// See Also
        ///     sections \fn, \typedef, and \var.
        /// 
        /// </summary>
        public const string Property = "property";

        /// <summary>
        /// \protected
        /// 
        /// Indicates that the member documented in the comment block is protected, i.e., should only be accessed by
        /// other members in the same or derived classes.
        /// 
        /// Note that Doxygen automatically detects the protection level of members in object-oriented languages.
        /// This command is intended for use only when the language does not support the concept of protection level
        /// natively (e.g. C, PHP 4).
        /// 
        /// For starting a section of protected members, in a way similar to the "protected:" class marker in C++,
        /// use \protectedsection.
        /// 
        /// See Also
        ///     sections \memberof, \public, \private and \protectedsection.
        /// 
        /// </summary>
        public const string Protected = "protected";

        /// <summary>
        /// \protectedsection
        /// 
        /// Starting a section of protected members, in a way similar to the "protected:" class marker in C++.
        /// Indicates that the member documented in the comment block is protected, i.e., should only be accessed by
        /// other members in the same or derived classes.
        /// 
        /// See Also
        ///     sections \memberof, \public, \private and \protected.
        /// 
        /// </summary>
        public const string Protectedsection = "protectedsection";

        /// <summary>
        /// \protocol <name> [<header-file>] [<header-name>]
        /// 
        /// Indicates that a comment block contains documentation for a protocol in Objective-C with name <name>.
        /// The arguments are equal to the \class command.
        /// 
        /// See Also
        ///     section \class.
        /// 
        /// </summary>
        public const string Protocol = "protocol";

        /// <summary>
        /// \public
        /// 
        /// Indicates that the member documented in the comment block is public, i.e., can be accessed by any other
        /// class or function.
        /// 
        /// Note that Doxygen automatically detects the protection level of members in object-oriented languages.
        /// This command is intended for use only when the language does not support the concept of protection level
        /// natively (e.g. C, PHP 4).
        /// 
        /// For starting a section of public members, in a way similar to the "public:" class marker in C++,
        /// use \publicsection.
        /// 
        /// See Also
        ///     sections \memberof, \protected, \private and \publicsection.
        /// 
        /// </summary>
        public const string Public = "public";

        /// <summary>
        /// \publicsection
        /// 
        /// Starting a section of public members, in a way similar to the "public:" class marker in C++. Indicates that
        /// the member documented in the comment block is public, i.e., can be accessed by any other class or function.
        /// 
        /// See Also
        ///     sections \memberof, \protected, \private and \public.
        /// 
        /// </summary>
        public const string Publicsection = "publicsection";

        /// <summary>
        /// \relates <name>
        /// 
        /// This command can be used in the documentation of a non-member function <name>. It puts the function inside
        /// the 'related function' section of the class documentation. This command is useful for documenting
        /// non-friend functions that are nevertheless strongly coupled to a certain class. It prevents the need
        /// of having to document a file, but only works for functions.
        /// 
        /// Example:
        /// 
        ///     /*! 
        ///      * A String class.
        ///      */ 
        ///       
        ///     class String
        ///     {
        ///       friend int strcmp(const String &,const String &);
        ///     };
        /// 
        ///     /*! 
        ///      * Compares two strings.
        ///      */
        /// 
        ///     int strcmp(const String &s1,const String &s2)
        ///     {
        ///     }
        /// 
        ///     /*! \relates String
        ///      * A string debug function.
        ///      */
        ///     void stringDebug()
        ///     {
        ///     }
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// </summary>
        public const string Relates = "relates";

        /// <summary>
        /// \related <name>
        /// 
        /// Equivalent to \relates
        /// </summary>
        public const string Related = "related";

        /// <summary>
        /// \relatesalso <name>
        /// 
        /// This command can be used in the documentation of a non-member function <name>. It puts the function both
        /// inside the 'related function' section of the class documentation as well as leaving it at its normal file
        /// documentation location. This command is useful for documenting non-friend functions that are nevertheless
        /// strongly coupled to a certain class. It only works for functions.
        /// </summary>
        public const string Relatesalso = "relatesalso";

        /// <summary>
        /// \relatedalso <name>
        /// 
        /// Equivalent to \relatesalso
        /// </summary>
        public const string Relatedalso = "relatedalso";

        /// <summary>
        /// \showinitializer
        /// 
        /// By default the value of a define and the initializer of a variable are only displayed if they are less than
        /// 30 lines long. By putting this command in a comment block of a define or variable, the initializer is shown
        /// unconditionally. The maximum number of initialization lines can be changed by means of the configuration
        /// parameter MAX_INITIALIZER_LINES, the default value is 30.
        /// 
        /// See Also
        ///     section \hideinitializer.
        /// 
        /// </summary>
        public const string Showinitializer = "showinitializer";

        /// <summary>
        /// \struct <name> [<header-file>] [<header-name>]
        /// 
        /// Indicates that a comment block contains documentation for a struct with name <name>. The arguments
        /// are equal to the arguments of the \class command.
        /// 
        /// See Also
        ///     section \class.
        /// 
        /// </summary>
        public const string Struct = "struct";

        /// <summary>
        /// \typedef (typedef declaration)
        /// 
        /// Indicates that a comment block contains documentation for a typedef (either global or as a member of a
        /// class). This command is equivalent to \var, \property, and \fn.
        /// 
        /// See Also
        ///     section \fn, \property, and \var.
        /// 
        /// </summary>
        public const string Typedef = "typedef";

        /// <summary>
        /// \union <name> [<header-file>] [<header-name>]
        /// 
        /// Indicates that a comment block contains documentation for a union with name <name>. The arguments are equal
        /// to the arguments of the \class command.
        /// 
        /// See Also
        ///     section \class.
        /// 
        /// </summary>
        public const string Union = "union";

        /// <summary>
        /// \var (variable declaration)
        /// 
        /// Indicates that a comment block contains documentation for a variable or enum value (either global or as a
        /// member of a class). This command is equivalent to \typedef, \property, and \fn.
        /// 
        /// See Also
        ///     section \fn, \property, and \typedef.
        /// 
        /// </summary>
        public const string Var = "var";

        /// <summary>
        /// \vhdlflow [(title for the flow chart)]
        /// 
        /// This is a VHDL specific command, which can be put in the documentation of a process to produce a flow chart
        /// of the logic in the process. Optionally a title for the flow chart can be given.
        /// 
        /// Note
        ///     Currently the flow chart will only appear in the HTML output.
        /// 
        /// </summary>
        public const string Vhdlflow = "vhdlflow";

        /// <summary>
        /// \weakgroup <name> [(title)]
        /// 
        /// Can be used exactly like \addtogroup, but has a lower priority when it comes to resolving conflicting
        /// grouping definitions.
        /// 
        /// See Also
        ///     page Grouping and section \addtogroup.
        /// 
        /// </summary>
        public const string Weakgroup = "weakgroup";

        /// <summary>
        /// \attention { attention text }
        /// 
        /// Starts a paragraph where a message that needs attention may be entered. The paragraph will be indented.
        /// The text of the paragraph has no special internal structure. All visual enhancement commands may be used
        /// inside the paragraph. Multiple adjacent \attention commands will be joined into a single paragraph.
        /// The \attention command ends when a blank line or some other sectioning command is encountered.
        /// </summary>
        public const string Attention = "attention";

        /// <summary>
        /// \author { list of authors }
        /// 
        /// Starts a paragraph where one or more author names may be entered. The paragraph will be indented.
        /// The text of the paragraph has no special internal structure. All visual enhancement commands may be used
        /// inside the paragraph. Multiple adjacent \author commands will be joined into a single paragraph.
        /// Each author description will start a new line. Alternatively, one \author command may mention several
        /// authors. The \author command ends when a blank line or some other sectioning command is encountered.
        /// 
        /// Example:
        /// 
        ///     /*! 
        ///      *  \brief     Pretty nice class.
        ///      *  \details   This class is used to demonstrate a number of section commands.
        ///      *  \author    John Doe
        ///      *  \author    Jan Doe
        ///      *  \version   4.1a
        ///      *  \date      1990-2011
        ///      *  \pre       First initialize the system.
        ///      *  \bug       Not all memory is freed when deleting an object of this class.
        ///      *  \warning   Improper use can crash your application
        ///      *  \copyright GNU Public License.
        ///      */
        ///     class SomeNiceClass {};
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// </summary>
        public const string Author = "author";

        /// <summary>
        /// \authors { list of authors }
        /// 
        /// Equivalent to \author.
        /// </summary>
        public const string Authors = "authors";

        /// <summary>
        /// \brief { brief description }
        /// 
        /// Starts a paragraph that serves as a brief description. For classes and files the brief description will be
        /// used in lists and at the start of the documentation page. For class and file members, the brief description
        /// will be placed at the declaration of the member and prepended to the detailed description. A brief
        /// description may span several lines (although it is advised to keep it brief!). A brief description ends
        /// when a blank line or another sectioning command is encountered. If multiple \brief commands are present
        /// they will be joined. See section \author for an example.
        /// 
        /// Synonymous to \short.
        /// </summary>
        public const string Brief = "brief";

        /// <summary>
        /// \bug { bug description }
        /// 
        /// Starts a paragraph where one or more bugs may be reported. The paragraph will be indented. The text of
        /// the paragraph has no special internal structure. All visual enhancement commands may be used inside the 
        /// paragraph. Multiple adjacent \bug commands will be joined into a single paragraph. Each bug description 
        /// will start on a new line. Alternatively, one \bug command may mention several bugs. The \bug command ends 
        /// when a blank line or some other sectioning command is encountered. See section \author for an example.
        /// </summary>
        public const string Bug = "bug";

        /// <summary>
        /// \cond [(section-label)]
        /// 
        /// Starts a conditional section that ends with a corresponding \endcond command, which is typically found in
        /// another comment block. The main purpose of this pair of commands is to (conditionally) exclude part of a
        /// file from processing (in older version of doxygen this could only be achieved using C preprocessor
        /// commands).
        /// 
        /// The section between \cond and \endcond commands can be included by adding its section label to the 
        /// ENABLED_SECTIONS configuration option. If the section label is omitted, the section will be excluded from 
        /// processing unconditionally. The section label can be a logical expression build of section lavels, round
        /// brackets, && (AND), || (OR) and ! (NOT). If you use an expression you need to wrap it in round brackets,
        /// i.e \cond (!LABEL1 && LABEL2).
        /// 
        /// For conditional sections within a comment block one should use a \if ... \endif block.
        /// 
        /// Conditional sections can be nested. In this case a nested section will only be shown if it and its 
        /// containing section are included.
        /// 
        /// Here is an example showing the commands in action:
        /// 
        /// /** An interface */
        /// class Intf
        /// {
        ///   public:
        ///     /** A method */
        ///     virtual void func() = 0;
        /// 
        ///     /// @cond TEST
        /// 
        ///     /** A method used for testing */
        ///     virtual void test() = 0;
        /// 
        ///     /// @endcond
        /// };
        /// 
        /// /// @cond DEV
        /// /*
        ///  *  The implementation of the interface
        ///  */
        /// class Implementation : public Intf
        /// {
        ///   public:
        ///     void func();
        /// 
        ///     /// @cond TEST
        ///     void test();
        ///     /// @endcond
        /// 
        ///     /// @cond
        ///     /** This method is obsolete and does
        ///      *  not show up in the documentation.
        ///      */
        ///     void obsolete();
        ///     /// @endcond
        /// };
        /// 
        /// /// @endcond
        /// 
        /// The output will be different depending on whether or not ENABLED_SECTIONS contains TEST, or DEV
        /// 
        /// See Also
        ///     section \endcond.
        /// 
        /// </summary>
        public const string Cond = "cond";

        /// <summary>
        /// \copyright { copyright description }
        /// 
        /// Starts a paragraph where the copyright of an entity can be described. This paragraph will be indented. 
        /// The text of the paragraph has no special internal structure. See section \author for an example.
        /// </summary>
        public const string Copyright = "copyright";

        /// <summary>
        /// \date { date description }
        /// 
        /// Starts a paragraph where one or more dates may be entered. The paragraph will be indented. The text of the
        /// paragraph has no special internal structure. All visual enhancement commands may be used inside the
        /// paragraph. Multiple adjacent \date commands will be joined into a single paragraph. Each date description
        /// will start on a new line. Alternatively, one \date command may mention several dates. The \date command
        /// ends when a blank line or some other sectioning command is encountered. See section \author for an example.
        /// </summary>
        public const string Date = "date";

        /// <summary>
        /// \deprecated { description }
        /// 
        /// Starts a paragraph indicating that this documentation block belongs to a deprecated entity. Can be used to
        /// describe alternatives, expected life span, etc.
        /// </summary>
        public const string Deprecated = "deprecated";

        /// <summary>
        /// \details { detailed description }
        /// 
        /// Just like \brief starts a brief description, \details starts the detailed description. You can also start a
        /// new paragraph (blank line) then the \details command is not needed.
        /// </summary>
        public const string Details = "details";

        /// <summary>
        /// \else
        /// 
        /// Starts a conditional section if the previous conditional section was not enabled. The previous section
        /// should have been started with a \if, \ifnot, or \elseif command.
        /// 
        /// See Also
        ///     \if, \ifnot, \elseif, \endif.
        /// 
        /// </summary>
        public const string Else = "else";

        /// <summary>
        /// \elseif (section-label)
        /// 
        /// Starts a conditional documentation section if the previous section was not enabled. A conditional section
        /// is disabled by default. To enable it you must put the section-label after the ENABLED_SECTIONS tag in the
        /// configuration file. The section label can be a logical expression build of section names, round brackets,
        /// && (AND), || (OR) and ! (NOT). Conditional blocks can be nested. A nested section is only enabled if all
        /// enclosing sections are enabled as well.
        /// 
        /// See Also
        ///     sections \endif, \ifnot, \else, and \elseif.
        /// 
        /// </summary>
        public const string Elseif = "elseif";

        /// <summary>
        /// \endcond
        /// 
        /// Ends a conditional section that was started by \cond.
        /// 
        /// See Also
        ///     section \cond.
        /// 
        /// </summary>
        public const string Endcond = "endcond";

        /// <summary>
        /// \endif
        /// 
        /// Ends a conditional section that was started by \if or \ifnot For each \if or \ifnot one and only one
        /// matching \endif must follow.
        /// 
        /// See Also
        ///     sections \if and \ifnot.
        /// 
        /// </summary>
        public const string Endif = "endif";

        /// <summary>
        /// \exception <exception-object> { exception description }
        /// 
        /// Starts an exception description for an exception object with name <exception-object>. Followed by a
        /// description of the exception. The existence of the exception object is not checked. The text of the
        /// paragraph has no special internal structure. All visual enhancement commands may be used inside the
        /// paragraph. Multiple adjacent \exception commands will be joined into a single paragraph. Each exception
        /// description will start on a new line. The \exception description ends when a blank line or some other
        /// sectioning command is encountered. See section \fn for an example.
        /// </summary>
        public const string Exception = "exception";

        /// <summary>
        /// \if (section-label)
        /// 
        /// Starts a conditional documentation section. The section ends with a matching \endif command. A conditional
        /// section is disabled by default. To enable it you must put the section-label after the ENABLED_SECTIONS tag
        /// in the configuration file.
        /// 
        /// The section label can be a logical expression build of section names, round brackets, && (AND), || (OR)
        /// and ! (NOT). If you use an expression you need to wrap it in round brackets, i.e \cond (!LABEL1 && LABEL2).
        /// 
        /// Conditional blocks can be nested. A nested section is only enabled if all enclosing sections are enabled as
        /// well.
        /// 
        /// Example:
        /// 
        ///       /*! Unconditionally shown documentation.
        ///        *  \if Cond1
        ///        *    Only included if Cond1 is set.
        ///        *  \endif
        ///        *  \if Cond2
        ///        *    Only included if Cond2 is set.
        ///        *    \if Cond3
        ///        *      Only included if Cond2 and Cond3 are set.
        ///        *    \endif
        ///        *    More text.
        ///        *  \endif
        ///        *  Unconditional text.
        ///        */
        /// 
        /// You can also use conditional commands inside aliases. To document a class in two languages you could for
        /// instance use:
        /// 
        /// Example 2:
        /// 
        ///     /*! \english
        ///      *  This is English.
        ///      *  \endenglish
        ///      *  \dutch
        ///      *  Dit is Nederlands.
        ///      *  \enddutch
        ///      */
        ///     class Example
        ///     {
        ///     };
        /// 
        /// Where the following aliases are defined in the configuration file:
        /// 
        /// ALIASES  = "english=\if english" \
        ///            "endenglish=\endif" \
        ///            "dutch=\if dutch" \
        ///            "enddutch=\endif"
        /// 
        /// and ENABLED_SECTIONS can be used to enable either english or dutch.
        /// 
        /// See Also
        ///     sections \endif, \ifnot, \else, and \elseif.
        /// 
        /// </summary>
        public const string If = "if";

        /// <summary>
        /// \ifnot (section-label)
        /// 
        /// Starts a conditional documentation section. The section ends with a matching \endif command. This
        /// conditional section is enabled by default. To disable it you must put the section-label after the
        /// ENABLED_SECTIONS tag in the configuration file. The section label can be a logical expression build of
        /// section names, round brackets, && (AND), || (OR) and ! (NOT).
        /// 
        /// See Also
        ///     sections \endif, \if, \else, and \elseif.
        /// 
        /// </summary>
        public const string Ifnot = "ifnot";

        /// <summary>
        /// \invariant { description of invariant }
        /// 
        /// Starts a paragraph where the invariant of an entity can be described. The paragraph will be indented.
        /// The text of the paragraph has no special internal structure. All visual enhancement commands may be used
        /// inside the paragraph. Multiple adjacent \invariant commands will be joined into a single paragraph. Each
        /// invariant description will start on a new line. Alternatively, one \invariant command may mention several
        /// invariants. The \invariant command ends when a blank line or some other sectioning command is encountered.
        /// </summary>
        public const string Invariant = "invariant";

        /// <summary>
        /// \note { text }
        /// 
        /// Starts a paragraph where a note can be entered. The paragraph will be indented. The text of the paragraph
        /// has no special internal structure. All visual enhancement commands may be used inside the paragraph.
        /// Multiple adjacent \note commands will be joined into a single paragraph. Each note description will start
        /// on a new line. Alternatively, one \note command may mention several notes. The \note command ends when a
        /// blank line or some other sectioning command is encountered. See section \par for an example.
        /// </summary>
        public const string Note = "note";

        /// <summary>
        /// \par [(paragraph title)] { paragraph }
        /// 
        /// If a paragraph title is given this command starts a paragraph with a user defined heading. The heading
        /// extends until the end of the line. The paragraph following the command will be indented.
        /// 
        /// If no paragraph title is given this command will start a new paragraph. This will also work inside other
        /// paragraph commands (like \param or \warning) without ending that command.
        /// 
        /// The text of the paragraph has no special internal structure. All visual enhancement commands may be used
        /// inside the paragraph. The \par command ends when a blank line or some other sectioning command
        /// is encountered.
        /// 
        /// Example:
        /// 
        ///     /*! \class Test
        ///      * Normal text.
        ///      *
        ///      * \par User defined paragraph:
        ///      * Contents of the paragraph.
        ///      *
        ///      * \par
        ///      * New paragraph under the same heading.
        ///      *
        ///      * \note
        ///      * This note consists of two paragraphs.
        ///      * This is the first paragraph.
        ///      *
        ///      * \par
        ///      * And this is the second paragraph.
        ///      *
        ///      * More normal text. 
        ///      */
        ///       
        ///     class Test {};
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// </summary>
        public const string Par = "par";

        /// <summary>
        /// \param [(dir)] <parameter-name> { parameter description }
        /// 
        /// Starts a parameter description for a function parameter with name <parameter-name>, followed by a
        /// description of the parameter. The existence of the parameter is checked and a warning is given if the
        /// documentation of this (or any other) parameter is missing or not present in the function declaration or
        /// definition.
        /// 
        /// The \param command has an optional attribute, (dir), specifying the direction of the parameter. Possible 
        /// values are "[in]", "[in,out]", and "[out]", note the [square] brackets in this description. When a
        /// parameter is both input and output, [in,out] is used as attribute. Here is an example for the function
        /// memcpy:
        /// /*!
        /// Copies bytes from a source memory area to a destination memory area,
        /// where both areas may not overlap.
        /// @param[out] dest The memory area to copy to.
        /// @param[in] src The memory area to copy from.
        /// @param[in] n The number of bytes to copy
        /// */
        /// void memcpy(void *dest, const void *src, size_t n);
        /// 
        /// The parameter description is a paragraph with no special internal structure. All visual enhancement
        /// commands may be used inside the paragraph.
        /// 
        /// Multiple adjacent \param commands will be joined into a single paragraph. Each parameter description
        /// will start on a new line. The \param description ends when a blank line or some other sectioning command 
        /// is encountered. See section \fn for an example.
        /// 
        /// Note that you can also document multiple parameters with a single \param command using a comma separated 
        /// list. Here is an example:
        /// /** Sets the position.
        /// @param x,y,z Coordinates of the position in 3D space.
        /// */
        /// void setPosition(double x,double y,double z,double t)
        /// {
        /// }
        /// 
        /// Note that for PHP one can also specify the type (or types if you separate them with a pipe symbol) which 
        /// are allowed for a parameter (as this is not part of the definition). The syntax is the same as for
        /// phpDocumentor, i.e.
        /// 
        /// @param  datatype1|datatype2 $paramname description
        /// 
        /// </summary>
        [Pattern(@"^*(?<" + FormatNames.DoxygenCommand +
                 @">[@\\]param)\s*(?<" + FormatNames.DoxygenParamDirection +
                 @">(?:\[out])|(?:\[in])|(?:\[in,\s*out]))?\s+(?<" + FormatNames.DoxygenParamArgName + 
                 @">\w+\b)?")]
        public const string Param = "param";

        /// <summary>
        /// \tparam <template-parameter-name> { description }
        /// 
        /// Starts a template parameter for a class or function template parameter with name <template-parameter-name>,
        /// followed by a description of the template parameter.
        /// 
        /// Otherwise similar to \param.
        /// </summary>
        public const string Tparam = "tparam";

        /// <summary>
        /// \post { description of the postcondition }
        /// 
        /// Starts a paragraph where the postcondition of an entity can be described. The paragraph will be indented.
        /// The text of the paragraph has no special internal structure. All visual enhancement commands may be used
        /// inside the paragraph. Multiple adjacent \post commands will be joined into a single paragraph. Each
        /// postcondition will start on a new line. Alternatively, one \post command may mention several
        /// postconditions. The \post command ends when a blank line or some other sectioning command is encountered.
        /// </summary>
        public const string Post = "post";

        /// <summary>
        /// \pre { description of the precondition }
        /// 
        /// Starts a paragraph where the precondition of an entity can be described. The paragraph will be indented.
        /// The text of the paragraph has no special internal structure. All visual enhancement commands may be used
        /// inside the paragraph. Multiple adjacent \pre commands will be joined into a single paragraph. Each
        /// precondition will start on a new line. Alternatively, one \pre command may mention several preconditions.
        /// The \pre command ends when a blank line or some other sectioning command is encountered.
        /// </summary>
        public const string Pre = "pre";

        /// <summary>
        /// \remark { remark text }
        /// 
        /// Starts a paragraph where one or more remarks may be entered. The paragraph will be indented. The text of
        /// the paragraph has no special internal structure. All visual enhancement commands may be used inside the
        /// paragraph. Multiple adjacent \remark commands will be joined into a single paragraph. Each remark will
        /// start on a new line. Alternatively, one \remark command may mention several remarks. The \remark command
        /// ends when a blank line or some other sectioning command is encountered.
        /// </summary>
        public const string Remark = "remark";

        /// <summary>
        /// \remarks { remark text }
        /// 
        /// Equivalent to \remark.
        /// </summary>
        public const string Remarks = "remarks";

        /// <summary>
        /// \result { description of the result value }
        /// 
        /// Equivalent to \return.
        /// </summary>
        public const string Result = "result";

        /// <summary>
        /// \return { description of the return value }
        /// 
        /// Starts a return value description for a function. The text of the paragraph has no special internal
        /// structure. All visual enhancement commands may be used inside the paragraph. Multiple adjacent \return
        /// commands will be joined into a single paragraph. The \return description ends when a blank line or some
        /// other sectioning command is encountered. See section \fn for an example.
        /// </summary>
        public const string Return = "return";

        /// <summary>
        /// \returns { description of the return value }
        /// 
        /// Equivalent to \return.
        /// </summary>
        public const string Returns = "returns";

        /// <summary>
        /// \retval <return value> { description }
        /// 
        /// Starts a description for a function's return value with name <return value>, followed by a description of
        /// the return value. The text of the paragraph that forms the description has no special internal structure.
        /// All visual enhancement commands may be used inside the paragraph. Multiple adjacent \retval commands will
        /// be joined into a single paragraph. Each return value description will start on a new line. The \retval
        /// description ends when a blank line or some other sectioning command is encountered.
        /// </summary>
        public const string Retval = "retval";

        /// <summary>
        /// \sa { references }
        /// 
        /// Starts a paragraph where one or more cross-references to classes, functions, methods, variables, files or
        /// URL may be specified. Two names joined by either :: or # are understood as referring to a class and one of
        /// its members. One of several overloaded methods or constructors may be selected by including a parenthesized
        /// list of argument types after the method name.
        /// 
        /// Synonymous to \see.
        /// 
        /// See Also
        ///     section autolink for information on how to create links to objects.
        /// 
        /// </summary>
        public const string Sa = "sa";

        /// <summary>
        /// \see { references }
        /// 
        /// Equivalent to \sa. Introduced for compatibility with Javadoc.
        /// </summary>
        public const string See = "see";

        /// <summary>
        /// \short { short description }
        /// 
        /// Equivalent to \brief.
        /// </summary>
        public const string Short = "short";

        /// <summary>
        /// \since { text }
        /// 
        /// This tag can be used to specify since when (version or time) an entity is available. The paragraph that
        /// follows \since does not have any special internal structure. All visual enhancement commands may be used
        /// inside the paragraph. The \since description ends when a blank line or some other sectioning command is
        /// encountered.
        /// </summary>
        public const string Since = "since";

        /// <summary>
        /// \test { paragraph describing a test case }
        /// 
        /// Starts a paragraph where a test case can be described. The description will also add the test case to a
        /// separate test list. The two instances of the description will be cross-referenced. Each test case in the
        /// test list will be preceded by a header that indicates the origin of the test case.
        /// </summary>
        public const string Test = "test";

        /// <summary>
        /// \throw <exception-object> { exception description }
        /// 
        /// Synonymous to \exception (see section \exception).
        /// 
        /// Note:
        ///     the tag \throws is a synonym for this tag.
        /// 
        /// See Also
        ///     section \exception
        /// 
        /// </summary>
        public const string Throw = "throw";

        /// <summary>
        /// \throws <exception-object> { exception description }
        /// 
        /// Equivalent to \throw.
        /// </summary>
        public const string Throws = "throws";

        /// <summary>
        /// \todo { paragraph describing what is to be done }
        /// 
        /// Starts a paragraph where a TODO item is described. The description will also add an item to a separate TODO
        /// list. The two instances of the description will be cross-referenced. Each item in the TODO list will be
        /// preceded by a header that indicates the origin of the item.
        /// </summary>
        public const string Todo = "todo";

        /// <summary>
        /// \version { version number }
        /// 
        /// Starts a paragraph where one or more version strings may be entered. The paragraph will be indented. The
        /// text of the paragraph has no special internal structure. All visual enhancement commands may be used inside
        /// the paragraph. Multiple adjacent \version commands will be joined into a single paragraph. Each version
        /// description will start on a new line. Alternatively, one \version command may mention several version
        /// strings. The \version command ends when a blank line or some other sectioning command is encountered. See
        /// section \author for an example.
        /// </summary>
        public const string Version = "version";

        /// <summary>
        /// \warning { warning message }
        /// 
        /// Starts a paragraph where one or more warning messages may be entered. The paragraph will be indented. The
        /// text of the paragraph has no special internal structure. All visual enhancement commands may be used inside
        /// the paragraph. Multiple adjacent \warning commands will be joined into a single paragraph. Each warning
        /// description will start on a new line. Alternatively, one \warning command may mention several warnings. The
        /// \warning command ends when a blank line or some other sectioning command is encountered. 
        /// See section \author for an example.
        /// </summary>
        public const string Warning = "warning";

        /// <summary>
        /// \xrefitem <key> "(heading)" "(list title)" { text }
        /// 
        /// This command is a generalization of commands such as \todo and \bug. It can be used to create user-defined
        /// text sections which are automatically cross-referenced between the place of occurrence and a related page,
        /// which will be generated. On the related page all sections of the same type will be collected.
        /// 
        /// The first argument <key> is an identifier uniquely representing the type of the section. The second 
        /// argument is a quoted string representing the heading of the section under which text passed as the fourth
        /// argument is put. The third argument (list title) is used as the title for the related page containing all
        /// items with the same key. The keys "todo", "test", "bug" and "deprecated" are predefined.
        /// 
        /// To get an idea on how to use the \xrefitem command and what its effect is, consider the todo list, which
        /// (for English output) can be seen an alias for the command
        /// 
        /// \xrefitem todo "Todo" "Todo List" 
        /// 
        /// Since it is very tedious and error-prone to repeat the first three parameters of the command for each
        /// section, the command is meant to be used in combination with the ALIASES option in the configuration file.
        /// To define a new command \reminder, for instance, one should add the following line to the configuration
        /// file:
        /// 
        /// ALIASES += "reminder=\xrefitem reminders \"Reminder\" \"Reminders\"" 
        /// 
        /// Note the use of escaped quotes for the second and third argument of the \xrefitem command.

        /// </summary>
        public const string Xrefitem = "xrefitem";

        /// <summary>
        /// \addindex (text)
        /// 
        /// This command adds (text) to the LaTeX index.
        /// </summary>
        [Pattern(@"^*(?<" + FormatNames.DoxygenCommand +
                 @">[@\\]addindex)\b")]
        public const string Addindex = "addindex";

        /// <summary>
        /// \anchor <word>
        /// 
        /// This command places an invisible, named anchor into the documentation to which you can refer with
        /// the \ref command.
        /// 
        /// Note
        ///     Anchors can currently only be put into a comment block that is marked as a page (using \page) or
        ///     mainpage (\mainpage).
        /// 
        /// See Also
        ///     section \ref.
        /// 
        /// </summary>
        public const string Anchor = "anchor";

        /// <summary>
        /// \cite <label>
        /// 
        /// Adds a bibliographic reference in the text and in the list of bibliographic references. The <label> must be
        /// a valid BibTeX label that can be found in one of the .bib files listed in CITE_BIB_FILES. For the LaTeX
        /// output the formatting of the reference in the text can be configured with LATEX_BIB_STYLE. For other output
        /// formats a fixed representation is used. Note that using this command requires the bibtex tool to be present
        /// in the search path.
        /// </summary>
        public const string Cite = "cite";

        /// <summary>
        /// \endlink
        /// 
        /// This command ends a link that is started with the \link command.
        /// 
        /// See Also
        ///     section \link.
        /// 
        /// </summary>
        public const string Endlink = "endlink";

        /// <summary>
        /// \link <link-object>
        /// 
        /// The links that are automatically generated by doxygen always have the name of the object they point to as
        /// link-text.
        /// 
        /// The \link command can be used to create a link to an object (a file, class, or member) with a user
        /// specified link-text. The link command should end with an \endlink command. All text between the \link
        /// and \endlink commands serves as text for a link to the <link-object> specified as the first argument
        /// of \link.
        /// 
        /// See section autolink for more information on automatically generated links and valid link-objects.
        /// </summary>
        public const string Link = "link";

        /// <summary>
        /// \ref <name> ["(text)"]
        /// 
        /// Creates a reference to a named section, subsection, page or anchor. For HTML documentation the reference
        /// command will generate a link to the section. For a section or subsection the title of the section will be
        /// used as the text of the link. For an anchor the optional text between quotes will be used or <name> if no
        /// text is specified. For LaTeX documentation the reference command will generate a section number for
        /// sections or the text followed by a page number if <name> refers to an anchor.
        /// 
        /// See Also
        ///     Section \page for an example of the \ref command.
        /// 
        /// </summary>
        public const string Ref = "ref";

        /// <summary>
        /// \subpage <name> ["(text)"]
        /// 
        /// This command can be used to create a hierarchy of pages. The same structure can be made using 
        /// the \defgroup and \ingroup commands, but for pages the \subpage command is often more convenient. The main
        /// page (see \mainpage) is typically the root of hierarchy.
        /// 
        /// This command behaves similar as \ref in the sense that it creates a reference to a page labeled <name> with
        /// the optional link text as specified in the second argument.
        /// 
        /// It differs from the \ref command in that it only works for pages, and creates a parent-child relation
        /// between pages, where the child page (or sub page) is identified by label <name>.
        /// 
        /// See the \section and \subsection commands if you want to add structure without creating multiple pages.
        /// 
        /// Note
        ///     Each page can be the sub page of only one other page and no cyclic relations are allowed, i.e. the page
        ///     hierarchy must have a tree structure.
        /// 
        /// Here is an example:
        /// 
        /// /*! \mainpage A simple manual
        /// 
        /// Some general info.
        /// 
        /// This manual is divided in the following sections:
        /// - \subpage intro
        /// - \subpage advanced "Advanced usage"
        /// */
        /// 
        /// //-----------------------------------------------------------
        /// 
        /// /*! \page intro Introduction
        /// This page introduces the user to the topic.
        /// Now you can proceed to the \ref advanced "advanced section".
        /// */
        /// 
        /// //-----------------------------------------------------------
        /// 
        /// /*! \page advanced Advanced Usage
        /// This page is for advanced users.
        /// Make sure you have first read \ref intro "the introduction".
        /// */
        /// 
        /// </summary>
        public const string Subpage = "subpage";

        /// <summary>
        /// \tableofcontents
        /// 
        /// Creates a table of contents at the top of a page, listing all sections and subsections in the page.
        /// 
        /// Warning
        ///     This command only works inside related page documentation and not in other documentation blocks and
        ///     only has effect in the HTML output!
        /// 
        /// </summary>
        public const string Tableofcontents = "tableofcontents";

        /// <summary>
        /// \section <section-name> (section title)
        /// 
        /// Creates a section with name <section-name>. The title of the section should be specified as the second
        /// argument of the \section command.
        /// 
        /// Warning
        ///     This command only works inside related page documentation and not in other documentation blocks!
        /// 
        /// See Also
        ///     Section \page for an example of the \section command.
        /// 
        /// </summary>
        public const string Section = "section";

        /// <summary>
        /// \subsection <subsection-name> (subsection title)
        /// 
        /// Creates a subsection with name <subsection-name>. The title of the subsection should be specified as the
        /// second argument of the \subsection command.
        /// 
        /// Warning
        ///     This command only works inside a section of a related page documentation block and not in other
        ///     documentation blocks!
        /// 
        /// See Also
        ///     Section \page for an example of the \subsection command.
        /// 
        /// </summary>
        public const string Subsection = "subsection";

        /// <summary>
        /// \subsubsection <subsubsection-name> (subsubsection title)
        /// 
        /// Creates a subsubsection with name <subsubsection-name>. The title of the subsubsection should be specified
        /// as the second argument of the \subsubsection command.
        /// 
        /// Warning
        ///     This command only works inside a subsection of a related page documentation block and not in other
        ///     documentation blocks!
        /// 
        /// See Also
        ///     Section \page for an example of the \section command and \subsection command.
        /// 
        /// </summary>
        public const string Subsubsection = "subsubsection";

        /// <summary>
        /// \paragraph <paragraph-name> (paragraph title)
        /// 
        /// Creates a named paragraph with name <paragraph-name>. The title of the paragraph should be specified as the
        /// second argument of the \paragraph command.
        /// 
        /// Warning
        ///     This command only works inside a subsubsection of a related page documentation block and not in other
        ///     documentation blocks!
        /// 
        /// </summary>
        public const string Paragraph = "paragraph";

        /// <summary>
        /// \dontinclude <file-name>
        /// 
        /// This command can be used to parse a source file without actually verbatim including it in the documentation
        /// (as the \include command does). This is useful if you want to divide the source file into smaller pieces
        /// and add documentation between the pieces. Source files or directories can be specified using
        /// the EXAMPLE_PATH tag of doxygen's configuration file.
        /// 
        /// The class and member declarations and definitions inside the code fragment are 'remembered' during the
        /// parsing of the comment block that contained the \dontinclude command.
        /// 
        /// For line by line descriptions of source files, one or more lines of the example can be displayed using
        /// the \line, \skip, \skipline, and \until commands. An internal pointer is used for these commands.
        /// The \dontinclude command sets the pointer to the first line of the example.
        /// 
        /// Example:
        /// 
        ///     /*! A test class. */
        /// 
        ///     class Test
        ///     {
        ///       public:
        ///         /// a member function
        ///         void example();
        ///     };
        /// 
        ///     /*! \page example
        ///      *  \dontinclude example_test.cpp
        ///      *  Our main function starts like this:
        ///      *  \skip main
        ///      *  \until {
        ///      *  First we create a object \c t of the Test class.
        ///      *  \skipline Test
        ///      *  Then we call the example member function 
        ///      *  \line example
        ///      *  After that our little test routine ends.
        ///      *  \line }
        ///      */
        /// 
        ///     Where the example file example_test.cpp looks as follows:
        /// 
        ///     void main()
        ///     {
        ///       Test t;
        ///       t.example();
        ///     }
        /// 
        ///     Click here for the corresponding HTML documentation that is generated by doxygen. 
        /// 
        /// Alternatively, the \snippet command can be used to include only a fragment of a source file. For this to
        /// work the fragment has to be marked.
        /// 
        /// See Also
        ///     sections \line, \skip, \skipline, \until, and \include.
        /// 
        /// </summary>
        public const string Dontinclude = "dontinclude";

        /// <summary>
        /// \include <file-name>
        /// 
        /// This command can be used to include a source file as a block of code. The command takes the name of an
        /// include file as an argument. Source files or directories can be specified using the EXAMPLE_PATH tag of
        /// doxygen's configuration file.
        /// 
        /// If <file-name> itself is not unique for the set of example files specified by the EXAMPLE_PATH tag, you can
        /// include part of the absolute path to disambiguate it.
        /// 
        /// Using the \include command is equivalent to inserting the file into the documentation block and surrounding
        /// it with \code and \endcode commands.
        /// 
        /// The main purpose of the \include command is to avoid code duplication in case of example blocks that
        /// consist of multiple source and header files.
        /// 
        /// For a line by line description of a source files use the \dontinclude command in combination with
        /// the \line, \skip, \skipline, and \until commands.
        /// 
        /// Alternatively, the \snippet command can be used to include only a fragment of a source file. For this to
        /// work the fragment has to be marked.
        /// 
        /// Note
        ///     Doxygen's special commands do not work inside blocks of code. It is allowed to nest C-style comments
        ///     inside a code block though.
        /// 
        /// See Also
        ///     sections \example, \dontinclude, and \verbatim.
        /// 
        /// </summary>
        public const string Include = "include";

        /// <summary>
        /// \includelineno <file-name>
        /// 
        /// This command works the same way as \include, but will add line numbers to the included file.
        /// 
        /// See Also
        ///     section \include.
        /// 
        /// </summary>
        public const string Includelineno = "includelineno";

        /// <summary>
        /// \line ( pattern )
        /// 
        /// This command searches line by line through the example that was last included using \include
        /// or \dontinclude until it finds a non-blank line. If that line contains the specified pattern, it is written
        /// to the output.
        /// 
        /// The internal pointer that is used to keep track of the current line in the example, is set to the start of
        /// the line following the non-blank line that was found (or to the end of the example if no such line could be
        /// found).
        /// 
        /// See section \dontinclude for an example.
        /// </summary>
        public const string Line = "line";

        /// <summary>
        /// \skip ( pattern )
        /// 
        /// This command searches line by line through the example that was last included using \include
        /// or \dontinclude until it finds a line that contains the specified pattern.
        /// 
        /// The internal pointer that is used to keep track of the current line in the example, is set to the start of 
        /// the line that contains the specified pattern (or to the end of the example if the pattern could not be
        /// found).
        /// 
        /// See section \dontinclude for an example.
        /// </summary>
        public const string Skip = "skip";

        /// <summary>
        /// \skipline ( pattern )
        /// 
        /// This command searches line by line through the example that was last included using \include
        /// or \dontinclude until it finds a line that contains the specified pattern. It then writes the line
        /// to the output.
        /// 
        /// The internal pointer that is used to keep track of the current line in the example, is set to the start
        /// of the line following the line that is written (or to the end of the example if the pattern could not
        /// be found).
        /// 
        /// Note:
        ///     The command:
        /// 
        ///     \skipline pattern
        /// 
        ///     is equivalent to:
        /// 
        ///     \skip pattern
        ///     \line pattern
        /// 
        /// See section \dontinclude for an example.
        /// </summary>
        public const string Skipline = "skipline";

        /// <summary>
        /// \snippet <file-name> ( block_id )
        /// 
        /// Where the \include command can be used to include a complete file as source code, this command can
        /// be used to quote only a fragment of a source file.
        /// 
        /// For example, the putting the following command in the documentation, references a snippet in file
        /// example.cpp residing in a subdirectory which should be pointed to by EXAMPLE_PATH.
        /// 
        ///   \snippet snippets/example.cpp Adding a resource
        /// 
        /// The text following the file name is the unique identifier for the snippet. This is used to delimit the
        /// quoted code in the relevant snippet file as shown in the following example that corresponds to the
        /// above \snippet command:
        /// QImage image(64, 64, QImage::Format_RGB32);
        /// image.fill(qRgb(255, 160, 128));
        /// //! [Adding a resource]
        /// document->addResource(QTextDocument::ImageResource,
        /// QUrl("mydata://image.png"), QVariant(image));
        /// //! [Adding a resource]
        /// ...
        /// 
        /// Note that the lines containing the block markers will not be included, so the output will be:
        /// document->addResource(QTextDocument::ImageResource,
        /// QUrl("mydata://image.png"), QVariant(image));
        /// 
        /// Note also that the [block_id] markers should appear exactly twice in the source file.
        /// 
        /// see section \dontinclude for an alternative way to include fragments of a source file that does
        /// not require markers.
        /// </summary>
        public const string Snippet = "snippet";

        /// <summary>
        /// \until ( pattern )
        /// 
        /// This command writes all lines of the example that was last included using \include or \dontinclude to the
        /// output, until it finds a line containing the specified pattern. The line containing the pattern will
        /// be written as well.
        /// 
        /// The internal pointer that is used to keep track of the current line in the example, is set to the start
        /// of the line following last written line (or to the end of the example if the pattern could not be found).
        /// 
        /// See section \dontinclude for an example.
        /// </summary>
        public const string Until = "until";

        /// <summary>
        /// \verbinclude <file-name>
        /// 
        /// This command includes the file <file-name> verbatim in the documentation. The command is equivalent
        /// to pasting the file in the documentation and placing \verbatim and \endverbatim commands around it.
        /// 
        /// Files or directories that doxygen should look for can be specified using the EXAMPLE_PATH tag of doxygen's
        /// configuration file.
        /// </summary>
        public const string Verbinclude = "verbinclude";

        /// <summary>
        /// \htmlinclude <file-name>
        /// 
        /// This command includes the file <file-name> as is in the HTML documentation. The command is equivalent
        /// to pasting the file in the documentation and placing \htmlonly and \endhtmlonly commands around it.
        /// 
        /// Files or directories that doxygen should look for can be specified using the EXAMPLE_PATH tag of doxygen's
        /// configuration file.
        /// </summary>
        public const string Htmlinclude = "htmlinclude";

        /// <summary>
        /// \a <word>
        /// 
        /// Displays the argument <word> in italics. Use this command to emphasize words. Use this command to refer
        /// to member arguments in the running text.
        /// 
        /// Example:
        /// 
        ///       ... the \a x and \a y coordinates are used to ...
        /// 
        ///     This will result in the following text:
        /// 
        ///     ... the x and y coordinates are used to ...
        /// 
        /// Equivalent to \e and \em. To emphasize multiple words use <em>multiple words</em>.
        /// </summary>
        [Pattern(@"^*(?<" + FormatNames.DoxygenCommand +
                 @">(?:[@\\]e)|(?:[@\\]em)|(?:[@\\]a))\s+(?<" + FormatNames.DoxygenEmphasize +
                 @">\w+\b)?")]
        public const string A = "a";

        /// <summary>
        /// \arg { item-description }
        /// 
        /// This command has one argument that continues until the first blank line or until
        /// another \arg is encountered. The command can be used to generate a simple, not nested list of arguments.
        /// Each argument should start with a \arg command.
        /// 
        /// Example:
        ///     Typing:
        /// 
        ///       \arg \c AlignLeft left alignment.
        ///       \arg \c AlignCenter center alignment.
        ///       \arg \c AlignRight right alignment
        /// 
        ///       No other types of alignment are supported.
        /// 
        ///     will result in the following text:
        /// 
        ///         AlignLeft left alignment.
        ///         AlignCenter center alignment.
        ///         AlignRight right alignment
        /// 
        /// 
        ///     No other types of alignment are supported.
        /// 
        /// Note:
        ///     For nested lists, HTML commands should be used.
        /// 
        /// Equivalent to \li
        /// </summary>
        public const string Arg = "arg";

        /// <summary>
        /// \b <word>
        /// 
        /// Displays the argument <word> using a bold font. Equivalent to <b>word</b>. To put multiple words in bold
        /// use <b>multiple words</b>.
        /// </summary>
        public const string B = "b";

        /// <summary>
        /// \c <word>
        /// 
        /// Displays the argument <word> using a typewriter font. Use this to refer to a word of code. Equivalent
        /// to <tt>word</tt>.
        /// 
        /// Example:
        ///     Typing:
        /// 
        ///          ... This function returns \c void and not \c int ...
        /// 
        ///     will result in the following text:
        /// 
        ///     ... This function returns void and not int ...
        /// 
        /// Equivalent to \p To have multiple words in typewriter font use <tt>multiple words</tt>.
        /// </summary>
        public const string C = "c";

        /// <summary>
        /// \code [ '{'<word>'}']
        /// 
        /// Starts a block of code. A code block is treated differently from ordinary text. It is interpreted
        /// as source code. The names of classes and members and other documented entities are automatically
        /// replaced by links to the documentation.
        /// 
        /// By default the language that is assumed for syntax highlighting is based on the location
        /// where the \code block was found. If this part of a Python file for instance, the syntax highlight
        /// will be done according to the Python syntax.
        /// 
        /// If it unclear from the context which language is meant (for instance the comment is in a .txt
        /// or .markdown file) then you can also explicitly indicate the language, by putting the file extension
        /// typically that doxygen associated with the language in curly brackets after the code block.
        /// Here is an example:
        /// 
        ///   \code{.py}
        ///   class Python:
        ///      pass
        ///   \endcode
        /// 
        ///   \code{.cpp}
        ///   class Cpp {};
        ///   \endcode
        /// 
        /// See Also
        ///     section \endcode and section \verbatim.
        /// 
        /// </summary>
        public const string Code = "code";

        /// <summary>
        /// \copydoc <link-object>
        /// 
        /// Copies a documentation block from the object specified by <link-object> and pastes it at the location
        /// of the command. This command can be useful to avoid cases where a documentation block would otherwise
        /// have to be duplicated or it can be used to extend the documentation of an inherited member.
        /// 
        /// The link object can point to a member (of a class, file or group), a class, a namespace, a group, a page,
        /// or a file (checked in that order). Note that if the object pointed to is a member (function, variable,
        /// typedef, etc), the compound (class, file, or group) containing it should also be documented
        /// for the copying to work.
        /// 
        /// To copy the documentation for a member of a class one can, for instance, put the following
        /// in the documentation:
        /// 
        ///   /*! @copydoc MyClass::myfunction()
        ///    *  More documentation.
        ///    */
        /// 
        /// if the member is overloaded, you should specify the argument types explicitly (without spaces!),
        /// like in the following:
        /// 
        ///   //! @copydoc MyClass::myfunction(type1,type2)
        /// 
        /// Qualified names are only needed if the context in which the documentation block is found requires them.
        /// 
        /// The \copydoc command can be used recursively, but cycles in the \copydoc relation will be broken and
        /// flagged as an error.
        /// 
        /// Note that \copydoc foo() is roughly equivalent to doing:
        /// 
        ///   \brief \copybrief foo()
        ///   \details \copydetails foo()
        /// 
        /// See \copybrief and \copydetails for copying only the brief or detailed part of the comment block.
        /// </summary>
        public const string Copydoc = "copydoc";

        /// <summary>
        /// \copybrief <link-object>
        /// 
        /// Works in a similar way as \copydoc but will only copy the brief description, not the detailed
        /// documentation.
        /// </summary>
        public const string Copybrief = "copybrief";

        /// <summary>
        /// \copydetails <link-object>
        /// 
        /// Works in a similar way as \copydoc but will only copy the detailed documentation, not the brief
        /// description.
        /// </summary>
        public const string Copydetails = "copydetails";

        /// <summary>
        /// \dot
        /// 
        /// Starts a text fragment which should contain a valid description of a dot graph. The text fragment
        /// ends with \enddot. Doxygen will pass the text on to dot and include the resulting image (and image map)
        /// into the output. The nodes of a graph can be made clickable by using the URL attribute. By using
        /// the command \ref inside the URL value you can conveniently link to an item inside doxygen.
        /// Here is an example:
        /// /*! class B */
        /// class B {};
        /// /*! class C */
        /// class C {};
        /// /*! \mainpage
        /// Class relations expressed via an inline dot graph:
        /// \dot
        /// digraph example {
        ///     node [shape=record, fontname=Helvetica, fontsize=10];
        ///     b [ label="class B" URL="\ref B"];
        ///     c [ label="class C" URL="\ref C"];
        ///     b -> c [ arrowhead="open", style="dashed" ];
        /// }
        /// \enddot
        /// Note that the classes in the above graph are clickable
        /// (in the HTML output).
        /// */
        /// </summary>
        public const string Dot = "dot";

        /// <summary>
        /// \msc
        /// 
        /// Starts a text fragment which should contain a valid description of a message sequence chart.
        /// See http://www.mcternan.me.uk/mscgen/ for examples. The text fragment ends with \endmsc.
        /// 
        /// Note
        ///     The text fragment should only include the part of the message sequence chart that is within
        ///     the msc {...} block. 
        ///     You need to install the mscgen tool, if you want to use this command.
        /// 
        /// Here is an example of the use of the \msc command.
        /// /** Sender class. Can be used to send a command to the server.
        ///     The receiver will acknowledge the command by calling Ack().
        ///     \msc
        ///         Sender,Receiver;
        ///         Sender->Receiver [label="Command()", URL="\ref Receiver::Command()"];
        ///         Sender<-Receiver [label="Ack()", URL="\ref Ack()", ID="1"];
        ///     \endmsc
        /// */
        /// class Sender
        /// {
        ///     public:
        ///         /** Acknowledgement from server */
        ///         void Ack(bool ok);
        /// };
        /// /** Receiver class. Can be used to receive and execute commands.
        ///     After execution of a command, the receiver will send an acknowledgement
        ///     \msc
        ///         Receiver,Sender;
        ///         Receiver<-Sender [label="Command()", URL="\ref Command()"];
        ///         Receiver->Sender [label="Ack()", URL="\ref Sender::Ack()", ID="1"];
        ///     \endmsc
        /// */
        /// class Receiver
        /// {
        ///     public:
        ///         /** Executable a command on the server */
        ///         void Command(int commandId);
        /// };
        /// 
        /// See Also
        ///     section \mscfile.
        /// 
        /// </summary>
        public const string Msc = "msc";

        /// <summary>
        /// \dotfile <file> ["caption"]
        /// 
        /// Inserts an image generated by dot from <file> into the documentation.
        /// 
        /// The first argument specifies the file name of the image. doxygen will look for files in the paths
        /// (or files) that you specified after the DOTFILE_DIRS tag. If the dot file is found it will be used as an
        /// input file to the dot tool. The resulting image will be put into the correct output directory. If the dot
        /// file name contains spaces you'll have to put quotes ("...") around it.
        /// 
        /// The second argument is optional and can be used to specify the caption that is displayed below the image.
        /// This argument has to be specified between quotes even if it does not contain any spaces. The quotes are
        /// stripped before the caption is displayed.
        /// </summary>
        public const string Dotfile = "dotfile";

        /// <summary>
        /// \mscfile <file> ["caption"]
        /// 
        /// Inserts an image generated by mscgen from <file> into the documentation.
        /// See http://www.mcternan.me.uk/mscgen/ for examples.
        /// 
        /// The first argument specifies the file name of the image. doxygen will look for files in the paths
        /// (or files) that you specified after the MSCFILE_DIRS tag. If the msc file is found it will be used as an
        /// input file to the mscgen tool. The resulting image will be put into the correct output directory.
        /// If the msc file name contains spaces you'll have to put quotes ("...") around it.
        /// 
        /// The second argument is optional and can be used to specify the caption that is displayed below the image.
        /// This argument has to be specified between quotes even if it does not contain any spaces. The quotes are
        /// stripped before the caption is displayed.
        /// 
        /// See Also
        ///     section \msc.
        /// 
        /// </summary>
        public const string Mscfile = "mscfile";

        /// <summary>
        /// \e <word>
        /// 
        /// Displays the argument <word> in italics. Use this command to emphasize words.
        /// 
        /// Example:
        ///     Typing:
        /// 
        ///       ... this is a \e really good example ...
        /// 
        ///     will result in the following text:
        /// 
        ///     ... this is a really good example ...
        /// 
        /// Equivalent to \a and \em. To emphasize multiple words use <em>multiple words</em>.
        /// </summary>
        [Pattern(@"^*(?<" + FormatNames.DoxygenCommand +
                 @">(?:[@\\]e)|(?:[@\\]em)|(?:[@\\]a))\s+(?<" + FormatNames.DoxygenEmphasize +
                 @">\w+\b)?")]
        public const string E = "e";

        /// <summary>
        /// \em <word>
        /// 
        /// Displays the argument <word> in italics. Use this command to emphasize words.
        /// 
        /// Example:
        ///     Typing:
        /// 
        ///       ... this is a \em really good example ...
        /// 
        ///     will result in the following text:
        /// 
        ///     ... this is a really good example ...
        /// 
        /// Equivalent to \a and \e. To emphasize multiple words use <em>multiple words</em>.
        /// </summary>
        [Pattern(@"^*(?<" + FormatNames.DoxygenCommand +
                 @">(?:[@\\]e)|(?:[@\\]em)|(?:[@\\]a))\s+(?<" + FormatNames.DoxygenEmphasize +
                 @">\w+\b)?")]
        public const string Em = "em";

        /// <summary>
        /// \endcode
        /// 
        /// Ends a block of code.
        /// 
        /// See Also
        ///     section \code
        /// 
        /// </summary>
        public const string Endcode = "endcode";

        /// <summary>
        /// \enddot
        /// 
        /// Ends a blocks that was started with \dot.
        /// </summary>
        public const string Enddot = "enddot";

        /// <summary>
        /// \endmsc
        /// 
        /// Ends a blocks that was started with \msc.
        /// </summary>
        public const string Endmsc = "endmsc";

        /// <summary>
        /// \endhtmlonly
        /// 
        /// Ends a block of text that was started with a \htmlonly command.
        /// 
        /// See Also
        ///     section \htmlonly.
        /// 
        /// </summary>
        public const string Endhtmlonly = "endhtmlonly";

        /// <summary>
        /// \endlatexonly
        /// 
        /// Ends a block of text that was started with a \latexonly command.
        /// 
        /// See Also
        ///     section \latexonly.
        /// 
        /// </summary>
        public const string Endlatexonly = "endlatexonly";

        /// <summary>
        /// \endmanonly
        /// 
        /// Ends a block of text that was started with a \manonly command.
        /// 
        /// See Also
        ///     section \manonly.
        /// 
        /// </summary>
        public const string Endmanonly = "endmanonly";

        /// <summary>
        /// \endrtfonly
        /// 
        /// Ends a block of text that was started with a \rtfonly command.
        /// 
        /// See Also
        ///     section \rtfonly.
        /// 
        /// </summary>
        public const string Endrtfonly = "endrtfonly";

        /// <summary>
        /// \endverbatim
        /// 
        /// Ends a block of text that was started with a \verbatim command.
        /// 
        /// See Also
        ///     section \verbatim.
        /// 
        /// </summary>
        public const string Endverbatim = "endverbatim";

        /// <summary>
        /// \endxmlonly
        /// 
        /// Ends a block of text that was started with a \xmlonly command.
        /// 
        /// See Also
        ///     section \xmlonly.
        /// 
        /// </summary>
        public const string Endxmlonly = "endxmlonly";

        /// <summary>
        /// \f$
        /// 
        /// Marks the start and end of an in-text formula.
        /// 
        /// See Also
        ///     section formulas for an example.
        /// 
        /// </summary>
        public const string FDollar = "f$";

        /// <summary>
        /// \f[
        /// 
        /// Marks the start of a long formula that is displayed centered on a separate line.
        /// 
        /// See Also
        ///     section \f] and section formulas.
        /// 
        /// </summary>
        public const string FLeftSquareBracket = "f[";

        /// <summary>
        /// \f]
        /// 
        /// Marks the end of a long formula that is displayed centered on a separate line.
        /// 
        /// See Also
        ///     section \f[ and section formulas.
        /// 
        /// </summary>
        public const string FRightSquareBracket = "f]";

        /// <summary>
        /// \f{environment}{
        /// 
        /// Marks the start of a formula that is in a specific environment.
        /// 
        /// Note
        ///     The second { is optional and is only to help editors (such as Vim) to do proper syntax highlighting by
        ///     making the number of opening and closing braces the same. 
        /// 
        /// See Also
        ///     section \f} and section formulas.
        /// 
        /// </summary>
        public const string FLeftCurlyBracket = "f{";

        /// <summary>
        /// \f}
        /// 
        /// Marks the end of a formula that is in a specific environment.
        /// 
        /// See Also
        ///     section \f{ and section formulas.
        /// 
        /// </summary>
        public const string FRightCurlyBracket = "f}";

        /// <summary>
        /// \htmlonly
        /// 
        /// Starts a block of text that will be verbatim included in the generated HTML documentation only. The block
        /// ends with a \endhtmlonly command.
        /// 
        /// This command can be used to include HTML code that is too complex for doxygen (i.e. applets, java-scripts,
        /// and HTML tags that require attributes). You can use the \latexonly and \endlatexonly pair to provide a
        /// proper LaTeX alternative.
        /// 
        /// Note
        ///     environment variables (like $(HOME) ) are resolved inside a HTML-only block.
        /// 
        /// See Also
        ///     section \manonly, section \latexonly, and section \rtfonly.
        /// 
        /// </summary>
        public const string Htmlonly = "htmlonly";

        /// <summary>
        /// \image <format> <file> ["caption"] [<sizeindication>=<size>]
        /// 
        /// Inserts an image into the documentation. This command is format specific, so if you want to insert an image
        /// for more than one format you'll have to repeat this command for each format.
        /// 
        /// The first argument specifies the output format. Currently, the following values are supported: html, latex
        /// and rtf.
        /// 
        /// The second argument specifies the file name of the image. doxygen will look for files in the paths
        /// (or files) that you specified after the IMAGE_PATH tag. If the image is found it will be copied to the 
        /// correct output directory. If the image name contains spaces you'll have to put quotes ("...") around it. 
        /// You can also specify an absolute URL instead of a file name, but then doxygen does not copy the image nor
        /// check its existence.
        /// 
        /// The third argument is optional and can be used to specify the caption that is displayed below the image. 
        /// This argument has to be specified on a single line and between quotes even if it does not contain any
        /// spaces. The quotes are stripped before the caption is displayed.
        /// 
        /// The fourth argument is also optional and can be used to specify the width or height of the image. This is 
        /// only useful for LaTeX output (i.e. format=latex). The sizeindication can be either width or height.
        /// The size should be a valid size specifier in LaTeX (for example 10cm or 6in or a symbolic width 
        /// like \textwidth).
        /// 
        /// Here is example of a comment block:
        /// 
        ///   /*! Here is a snapshot of my new application:
        ///    *  \image html application.jpg
        ///    *  \image latex application.eps "My application" width=10cm
        ///    */
        /// 
        /// And this is an example of how the relevant part of the configuration file may look:
        /// 
        ///   IMAGE_PATH     = my_image_dir
        /// 
        /// Warning
        ///     The image format for HTML is limited to what your browser supports. For LaTeX, the image format must be
        ///     Encapsulated PostScript (eps).
        /// 
        ///     Doxygen does not check if the image is in the correct format. So you have to make sure this 
        ///     is the case!
        /// 
        /// </summary>
        public const string Image = "image";

        /// <summary>
        /// \latexonly
        /// 
        /// Starts a block of text that will be verbatim included in the generated LaTeX documentation only. The block
        /// ends with a \endlatexonly command.
        /// 
        /// This command can be used to include LaTeX code that is too complex for doxygen (i.e. images, formulas, 
        /// special characters). You can use the \htmlonly and \endhtmlonly pair to provide a proper HTML alternative.
        /// 
        /// Note: environment variables (like $(HOME) ) are resolved inside a LaTeX-only block.
        /// 
        /// See Also
        ///     section \rtfonly, section \xmlonly, section \manonly, and section \htmlonly.
        /// 
        /// </summary>
        public const string Latexonly = "latexonly";

        /// <summary>
        /// \manonly
        /// 
        /// Starts a block of text that will be verbatim included in the generated MAN documentation only. The block 
        /// ends with a \endmanonly command.
        /// 
        /// This command can be used to include groff code directly into MAN pages. You can use the \htmlonly 
        /// and \latexonly and \endhtmlonly and \endlatexonly pairs to provide proper HTML and LaTeX alternatives.
        /// 
        /// See Also
        ///     section \htmlonly, section \xmlonly, section \rtfonly, and section \latexonly.
        /// 
        /// </summary>
        public const string Manonly = "manonly";

        /// <summary>
        /// \li { item-description }
        /// 
        /// This command has one argument that continues until the first blank line or until another \li is 
        /// encountered. The command can be used to generate a simple, not nested list of arguments. Each argument 
        /// should start with a \li command.
        /// 
        /// Example:
        ///     Typing:
        /// 
        ///       \li \c AlignLeft left alignment.
        ///       \li \c AlignCenter center alignment.
        ///       \li \c AlignRight right alignment
        /// 
        ///       No other types of alignment are supported.
        /// 
        ///     will result in the following text:
        /// 
        ///         AlignLeft left alignment.
        ///         AlignCenter center alignment.
        ///         AlignRight right alignment
        /// 
        /// 
        ///     No other types of alignment are supported.
        /// 
        /// Note:
        ///     For nested lists, HTML commands should be used.
        /// 
        /// Equivalent to \arg
        /// </summary>
        public const string Li = "li";

        /// <summary>
        /// \n
        /// 
        /// Forces a new line. Equivalent to <br> and inspired by the printf function.
        /// </summary>
        public const string N = "n";

        /// <summary>
        /// \p <word>
        /// 
        /// Displays the parameter <word> using a typewriter font. You can use this command to refer to member 
        /// function parameters in the running text.
        /// 
        /// Example:
        /// 
        ///       ... the \p x and \p y coordinates are used to ...
        /// 
        ///     This will result in the following text:
        /// 
        ///     ... the x and y coordinates are used to ...
        /// 
        /// Equivalent to \c To have multiple words in typewriter font use <tt>multiple words</tt>.
        /// </summary>
        public const string P = "p";

        /// <summary>
        /// \rtfonly
        /// 
        /// Starts a block of text that will be verbatim included in the generated RTF documentation only. The block
        /// ends with a \endrtfonly command.
        /// 
        /// This command can be used to include RTF code that is too complex for doxygen.
        /// 
        /// Note: environment variables (like $(HOME) ) are resolved inside a RTF-only block.
        /// 
        /// See Also
        ///     section \manonly, section \xmlonly, section \latexonly, and section \htmlonly.
        /// 
        /// </summary>
        public const string Rtfonly = "rtfonly";

        /// <summary>
        /// \verbatim
        /// 
        /// Starts a block of text that will be verbatim included in the documentation. The block should
        /// end with a \endverbatim block. All commands are disabled in a verbatim block.
        /// 
        /// Warning
        ///     Make sure you include a \endverbatim command for each \verbatim command or the parser
        ///     will get confused!
        /// 
        /// See Also
        ///     section \code, and section \verbinclude.
        /// 
        /// </summary>
        public const string Verbatim = "verbatim";

        /// <summary>
        /// \xmlonly
        /// 
        /// Starts a block of text that will be verbatim included in the generated XML output only. The block ends with
        /// a endxmlonly command.
        /// 
        /// This command can be used to include custom XML tags.
        /// 
        /// See Also
        ///     section \manonly, section \rtfonly, section \latexonly, and section \htmlonly.
        /// 
        /// </summary>
        public const string Xmlonly = "xmlonly";

        /// <summary>
        /// \\
        /// 
        /// This command writes a backslash character (\) to the output. The backslash has to be escaped in some cases
        /// because doxygen uses it to detect commands.
        /// </summary>
        public const string ReversSolidus = @"\";

        /// <summary>
        /// \@
        /// 
        /// This command writes an at-sign (@) to the output. The at-sign has to be escaped in some cases because
        /// doxygen uses it to detect JavaDoc commands.
        /// </summary>
        public const string CommercialAt = "@";

        /// <summary>
        /// \~[LanguageId]
        /// 
        /// This command enables/disables a language specific filter. This can be used to put documentation for
        /// different language into one comment block and use the OUTPUT_LANGUAGE tag to filter out only a specific
        /// language. Use \~language_id to enable output for a specific language only and \~ to enable output for all
        /// languages (this is also the default mode).
        /// 
        /// Example:
        /// 
        /// /*! \~english This is english \~dutch Dit is Nederlands \~german Dieses ist
        ///     deutsch. \~ output for all languages.
        ///  */
        /// 
        /// </summary>
        public const string Tilde = "~";

        /// <summary>
        /// \&
        /// 
        /// This command writes the & character to output. This character has to be escaped because it has a special
        /// meaning in HTML.
        /// </summary>
        public const string Ampersand = "&";

        /// <summary>
        /// \$
        /// 
        /// This command writes the $ character to the output. This character has to be escaped in some cases, because
        /// it is used to expand environment variables.
        /// </summary>
        public const string DollarSign = "$";

        /// <summary>
        /// \#
        /// 
        /// This command writes the # character to the output. This character has to be escaped in some cases, because
        /// it is used to refer to documented entities.
        /// </summary>
        public const string NumberSign = "#";

        /// <summary>
        /// \<
        /// 
        /// This command writes the < character to the output. This character has to be escaped because it has a
        /// special meaning in HTML.
        /// </summary>
        public const string LessThanSign = "<";

        /// <summary>
        /// \>
        /// 
        /// This command writes the > character to the output. This character has to be escaped because it has a
        /// special meaning in HTML.
        /// </summary>
        public const string GreaterThanSign = ">";

        /// <summary>
        /// \%
        /// 
        /// This command writes the % character to the output. This character has to be escaped in some cases, because
        /// it is used to prevent auto-linking to word that is also a documented class or struct.
        /// </summary>
        public const string PercentSign = "%";

        /// <summary>
        /// \"
        /// 
        /// This command writes the " character to the output. This character has to be escaped in some cases, because
        /// it is used in pairs to indicate an unformatted text fragment.
        /// </summary>
        public const string QuatationMark = "\"";

        /// <summary>
        /// \.
        /// 
        /// This command writes a dot to the output. This can be useful to prevent ending a brief description when
        /// JAVADOC_AUTOBRIEF is enabled or to prevent starting a numbered list when the dot follows a number at the
        /// start of a line.
        /// </summary>
        public const string FullStop = ".";

        /// <summary>
        /// \::
        /// 
        /// This command write a double colon (::) to the output. This character sequence has to be escaped in some
        /// cases, because it is used to ref to documented entities.
        public const string DoubleColon = "::";

        private static string GetPattern(string fieldName)
        {
            var field = typeof(Commands).GetField(fieldName);
            var attrs = field.GetCustomAttributes(typeof(PatternAttribute), false);
            string pattern = null;

            if (attrs.Length == 1)
	        {
                var attr = (PatternAttribute)attrs[0];
                pattern = attr.Pattern;
	        }

            return pattern;
        }

        public static IEnumerable<Tuple<string, string>> GetCommandsAndPatterns()
        {
            var collection = typeof(Commands).GetFields()
                .Select(f => new Tuple<string, string>((string)f.GetValue(null), GetPattern(f.Name)));

            return collection;
        }


        // The following commands are supported to remain compatible to the Qt class browser generator. Do not use
        // these commands in your own documentation.
        // 
        //     \annotatedclasslist
        //     \classhierarchy
        //     \define
        //     \functionindex
        //     \header
        //     \headerfilelist
        //     \inherit
        //     \l
        //     \postheader
    }
}
