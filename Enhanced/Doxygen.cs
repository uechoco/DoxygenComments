﻿/**
 * Copyright (c) 2013 Alexander Manenko
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
namespace Enhanced
{
    using System.Collections.Generic;

    public sealed class Doxygen
    {
        private readonly IDictionary<string, int> commandToToken;
        private readonly IDictionary<int, string> tokenToCommand;

        public Doxygen()
        {
            const int itemsCount = 168;

            this.commandToToken = new Dictionary<string, int>(itemsCount);
            this.tokenToCommand = new Dictionary<int, string>(itemsCount);
            
            InitializeCommandToTokenMapping(this.commandToToken);
            InitializeTokenToCommandMapping(this.tokenToCommand);
        }

        public int Token(string command)
        {
            return GetMapping(this.commandToToken, command, Token_unknown);
        }

        public string Command(int token)
        {
            return GetMapping(this.tokenToCommand, token, null);
        }

        private static TValue GetMapping<TKey, TValue>(IDictionary<TKey, TValue> map, TKey key, TValue defaultValue)
        {
            TValue value;

            if (!map.TryGetValue(key, out value))
            {
                value = defaultValue;
            }

            return value;
        }

        #region Mapping between tokens and commands
        private static void InitializeCommandToTokenMapping(IDictionary<string, int> map)
        {
            map[Command_a] = Token_a;
            map[Command_addindex] = Token_addindex;
            map[Command_addtogroup] = Token_addtogroup;
            map[Command_anchor] = Token_anchor;
            map[Command_arg] = Token_arg;
            map[Command_attention] = Token_attention;
            map[Command_author] = Token_author;
            map[Command_authors] = Token_authors;
            map[Command_b] = Token_b;
            map[Command_brief] = Token_brief;
            map[Command_bug] = Token_bug;
            map[Command_c] = Token_c;
            map[Command_callgraph] = Token_callgraph;
            map[Command_callergraph] = Token_callergraph;
            map[Command_category] = Token_category;
            map[Command_cite] = Token_cite;
            map[Command_class] = Token_class;
            map[Command_code] = Token_code;
            map[Command_cond] = Token_cond;
            map[Command_copybrief] = Token_copybrief;
            map[Command_copydetails] = Token_copydetails;
            map[Command_copydoc] = Token_copydoc;
            map[Command_copyright] = Token_copyright;
            map[Command_date] = Token_date;
            map[Command_def] = Token_def;
            map[Command_defgroup] = Token_defgroup;
            map[Command_deprecated] = Token_deprecated;
            map[Command_details] = Token_details;
            map[Command_dir] = Token_dir;
            map[Command_docbookonly] = Token_docbookonly;
            map[Command_dontinclude] = Token_dontinclude;
            map[Command_dot] = Token_dot;
            map[Command_dotfile] = Token_dotfile;
            map[Command_e] = Token_e;
            map[Command_else] = Token_else;
            map[Command_elseif] = Token_elseif;
            map[Command_em] = Token_em;
            map[Command_endcode] = Token_endcode;
            map[Command_endcond] = Token_endcond;
            map[Command_enddocbookonly] = Token_enddocbookonly;
            map[Command_enddot] = Token_enddot;
            map[Command_endhtmlonly] = Token_endhtmlonly;
            map[Command_endif] = Token_endif;
            map[Command_endinternal] = Token_endinternal;
            map[Command_endlatexonly] = Token_endlatexonly;
            map[Command_endlink] = Token_endlink;
            map[Command_endmanonly] = Token_endmanonly;
            map[Command_endmsc] = Token_endmsc;
            map[Command_endrtfonly] = Token_endrtfonly;
            map[Command_endsecreflist] = Token_endsecreflist;
            map[Command_endverbatim] = Token_endverbatim;
            map[Command_endxmlonly] = Token_endxmlonly;
            map[Command_enum] = Token_enum;
            map[Command_example] = Token_example;
            map[Command_exception] = Token_exception;
            map[Command_extends] = Token_extends;
            map[Command_f_dollar_sign] = Token_f_dollar_sign;
            map[Command_f_left_square_bracket] = Token_f_left_square_bracket;
            map[Command_f_right_square_bracket] = Token_f_right_square_bracket;
            map[Command_f_left_curly_bracket] = Token_f_left_curly_bracket;
            map[Command_f_right_curly_bracket] = Token_f_right_curly_bracket;
            map[Command_file] = Token_file;
            map[Command_fn] = Token_fn;
            map[Command_headerfile] = Token_headerfile;
            map[Command_hideinitializer] = Token_hideinitializer;
            map[Command_htmlinclude] = Token_htmlinclude;
            map[Command_htmlonly] = Token_htmlonly;
            map[Command_idlexcept] = Token_idlexcept;
            map[Command_if] = Token_if;
            map[Command_ifnot] = Token_ifnot;
            map[Command_image] = Token_image;
            map[Command_implements] = Token_implements;
            map[Command_include] = Token_include;
            map[Command_includelineno] = Token_includelineno;
            map[Command_ingroup] = Token_ingroup;
            map[Command_internal] = Token_internal;
            map[Command_invariant] = Token_invariant;
            map[Command_interface] = Token_interface;
            map[Command_latexonly] = Token_latexonly;
            map[Command_li] = Token_li;
            map[Command_line] = Token_line;
            map[Command_link] = Token_link;
            map[Command_mainpage] = Token_mainpage;
            map[Command_manonly] = Token_manonly;
            map[Command_memberof] = Token_memberof;
            map[Command_msc] = Token_msc;
            map[Command_mscfile] = Token_mscfile;
            map[Command_n] = Token_n;
            map[Command_name] = Token_name;
            map[Command_namespace] = Token_namespace;
            map[Command_nosubgrouping] = Token_nosubgrouping;
            map[Command_note] = Token_note;
            map[Command_overload] = Token_overload;
            map[Command_p] = Token_p;
            map[Command_package] = Token_package;
            map[Command_page] = Token_page;
            map[Command_par] = Token_par;
            map[Command_paragraph] = Token_paragraph;
            map[Command_param] = Token_param;
            map[Command_post] = Token_post;
            map[Command_pre] = Token_pre;
            map[Command_private] = Token_private;
            map[Command_privatesection] = Token_privatesection;
            map[Command_property] = Token_property;
            map[Command_protected] = Token_protected;
            map[Command_protectedsection] = Token_protectedsection;
            map[Command_protocol] = Token_protocol;
            map[Command_public] = Token_public;
            map[Command_publicsection] = Token_publicsection;
            map[Command_pure] = Token_pure;
            map[Command_ref] = Token_ref;
            map[Command_refitem] = Token_refitem;
            map[Command_related] = Token_related;
            map[Command_relates] = Token_relates;
            map[Command_relatedalso] = Token_relatedalso;
            map[Command_relatesalso] = Token_relatesalso;
            map[Command_remark] = Token_remark;
            map[Command_remarks] = Token_remarks;
            map[Command_result] = Token_result;
            map[Command_return] = Token_return;
            map[Command_returns] = Token_returns;
            map[Command_retval] = Token_retval;
            map[Command_rtfonly] = Token_rtfonly;
            map[Command_sa] = Token_sa;
            map[Command_secreflist] = Token_secreflist;
            map[Command_section] = Token_section;
            map[Command_see] = Token_see;
            map[Command_short] = Token_short;
            map[Command_showinitializer] = Token_showinitializer;
            map[Command_since] = Token_since;
            map[Command_skip] = Token_skip;
            map[Command_skipline] = Token_skipline;
            map[Command_snippet] = Token_snippet;
            map[Command_struct] = Token_struct;
            map[Command_subpage] = Token_subpage;
            map[Command_subsection] = Token_subsection;
            map[Command_subsubsection] = Token_subsubsection;
            map[Command_tableofcontents] = Token_tableofcontents;
            map[Command_test] = Token_test;
            map[Command_throw] = Token_throw;
            map[Command_throws] = Token_throws;
            map[Command_todo] = Token_todo;
            map[Command_tparam] = Token_tparam;
            map[Command_typedef] = Token_typedef;
            map[Command_union] = Token_union;
            map[Command_until] = Token_until;
            map[Command_var] = Token_var;
            map[Command_verbatim] = Token_verbatim;
            map[Command_verbinclude] = Token_verbinclude;
            map[Command_version] = Token_version;
            map[Command_vhdlflow] = Token_vhdlflow;
            map[Command_warning] = Token_warning;
            map[Command_weakgroup] = Token_weakgroup;
            map[Command_xmlonly] = Token_xmlonly;
            map[Command_xrefitem] = Token_xrefitem;
            map[Command_dollar_sign] = Token_dollar_sign;
            map[Command_commercial_at] = Token_commercial_at;
            map[Command_reverse_solidus] = Token_reverse_solidus;
            map[Command_ampersand] = Token_ampersand;
            map[Command_tilde] = Token_tilde;
            map[Command_less_than_sign] = Token_less_than_sign;
            map[Command_greater_than_sign] = Token_greater_than_sign;
            map[Command_number_sign] = Token_number_sign;
            map[Command_percent_sign] = Token_percent_sign;
            map[Command_quatation_mark] = Token_quatation_mark;
            map[Command_full_stop] = Token_full_stop;
            map[Command_double_colon] = Token_double_colon;
            map[Command_broken_bar] = Token_broken_bar;
        }

        private static void InitializeTokenToCommandMapping(IDictionary<int, string> map)
        {
            map[Token_a] = Command_a;
            map[Token_addindex] = Command_addindex;
            map[Token_addtogroup] = Command_addtogroup;
            map[Token_anchor] = Command_anchor;
            map[Token_arg] = Command_arg;
            map[Token_attention] = Command_attention;
            map[Token_author] = Command_author;
            map[Token_authors] = Command_authors;
            map[Token_b] = Command_b;
            map[Token_brief] = Command_brief;
            map[Token_bug] = Command_bug;
            map[Token_c] = Command_c;
            map[Token_callgraph] = Command_callgraph;
            map[Token_callergraph] = Command_callergraph;
            map[Token_category] = Command_category;
            map[Token_cite] = Command_cite;
            map[Token_class] = Command_class;
            map[Token_code] = Command_code;
            map[Token_cond] = Command_cond;
            map[Token_copybrief] = Command_copybrief;
            map[Token_copydetails] = Command_copydetails;
            map[Token_copydoc] = Command_copydoc;
            map[Token_copyright] = Command_copyright;
            map[Token_date] = Command_date;
            map[Token_def] = Command_def;
            map[Token_defgroup] = Command_defgroup;
            map[Token_deprecated] = Command_deprecated;
            map[Token_details] = Command_details;
            map[Token_dir] = Command_dir;
            map[Token_docbookonly] = Command_docbookonly;
            map[Token_dontinclude] = Command_dontinclude;
            map[Token_dot] = Command_dot;
            map[Token_dotfile] = Command_dotfile;
            map[Token_e] = Command_e;
            map[Token_else] = Command_else;
            map[Token_elseif] = Command_elseif;
            map[Token_em] = Command_em;
            map[Token_endcode] = Command_endcode;
            map[Token_endcond] = Command_endcond;
            map[Token_enddocbookonly] = Command_enddocbookonly;
            map[Token_enddot] = Command_enddot;
            map[Token_endhtmlonly] = Command_endhtmlonly;
            map[Token_endif] = Command_endif;
            map[Token_endinternal] = Command_endinternal;
            map[Token_endlatexonly] = Command_endlatexonly;
            map[Token_endlink] = Command_endlink;
            map[Token_endmanonly] = Command_endmanonly;
            map[Token_endmsc] = Command_endmsc;
            map[Token_endrtfonly] = Command_endrtfonly;
            map[Token_endsecreflist] = Command_endsecreflist;
            map[Token_endverbatim] = Command_endverbatim;
            map[Token_endxmlonly] = Command_endxmlonly;
            map[Token_enum] = Command_enum;
            map[Token_example] = Command_example;
            map[Token_exception] = Command_exception;
            map[Token_extends] = Command_extends;
            map[Token_f_dollar_sign] = Command_f_dollar_sign;
            map[Token_f_left_square_bracket] = Command_f_left_square_bracket;
            map[Token_f_right_square_bracket] = Command_f_right_square_bracket;
            map[Token_f_left_curly_bracket] = Command_f_left_curly_bracket;
            map[Token_f_right_curly_bracket] = Command_f_right_curly_bracket;
            map[Token_file] = Command_file;
            map[Token_fn] = Command_fn;
            map[Token_headerfile] = Command_headerfile;
            map[Token_hideinitializer] = Command_hideinitializer;
            map[Token_htmlinclude] = Command_htmlinclude;
            map[Token_htmlonly] = Command_htmlonly;
            map[Token_idlexcept] = Command_idlexcept;
            map[Token_if] = Command_if;
            map[Token_ifnot] = Command_ifnot;
            map[Token_image] = Command_image;
            map[Token_implements] = Command_implements;
            map[Token_include] = Command_include;
            map[Token_includelineno] = Command_includelineno;
            map[Token_ingroup] = Command_ingroup;
            map[Token_internal] = Command_internal;
            map[Token_invariant] = Command_invariant;
            map[Token_interface] = Command_interface;
            map[Token_latexonly] = Command_latexonly;
            map[Token_li] = Command_li;
            map[Token_line] = Command_line;
            map[Token_link] = Command_link;
            map[Token_mainpage] = Command_mainpage;
            map[Token_manonly] = Command_manonly;
            map[Token_memberof] = Command_memberof;
            map[Token_msc] = Command_msc;
            map[Token_mscfile] = Command_mscfile;
            map[Token_n] = Command_n;
            map[Token_name] = Command_name;
            map[Token_namespace] = Command_namespace;
            map[Token_nosubgrouping] = Command_nosubgrouping;
            map[Token_note] = Command_note;
            map[Token_overload] = Command_overload;
            map[Token_p] = Command_p;
            map[Token_package] = Command_package;
            map[Token_page] = Command_page;
            map[Token_par] = Command_par;
            map[Token_paragraph] = Command_paragraph;
            map[Token_param] = Command_param;
            map[Token_post] = Command_post;
            map[Token_pre] = Command_pre;
            map[Token_private] = Command_private;
            map[Token_privatesection] = Command_privatesection;
            map[Token_property] = Command_property;
            map[Token_protected] = Command_protected;
            map[Token_protectedsection] = Command_protectedsection;
            map[Token_protocol] = Command_protocol;
            map[Token_public] = Command_public;
            map[Token_publicsection] = Command_publicsection;
            map[Token_pure] = Command_pure;
            map[Token_ref] = Command_ref;
            map[Token_refitem] = Command_refitem;
            map[Token_related] = Command_related;
            map[Token_relates] = Command_relates;
            map[Token_relatedalso] = Command_relatedalso;
            map[Token_relatesalso] = Command_relatesalso;
            map[Token_remark] = Command_remark;
            map[Token_remarks] = Command_remarks;
            map[Token_result] = Command_result;
            map[Token_return] = Command_return;
            map[Token_returns] = Command_returns;
            map[Token_retval] = Command_retval;
            map[Token_rtfonly] = Command_rtfonly;
            map[Token_sa] = Command_sa;
            map[Token_secreflist] = Command_secreflist;
            map[Token_section] = Command_section;
            map[Token_see] = Command_see;
            map[Token_short] = Command_short;
            map[Token_showinitializer] = Command_showinitializer;
            map[Token_since] = Command_since;
            map[Token_skip] = Command_skip;
            map[Token_skipline] = Command_skipline;
            map[Token_snippet] = Command_snippet;
            map[Token_struct] = Command_struct;
            map[Token_subpage] = Command_subpage;
            map[Token_subsection] = Command_subsection;
            map[Token_subsubsection] = Command_subsubsection;
            map[Token_tableofcontents] = Command_tableofcontents;
            map[Token_test] = Command_test;
            map[Token_throw] = Command_throw;
            map[Token_throws] = Command_throws;
            map[Token_todo] = Command_todo;
            map[Token_tparam] = Command_tparam;
            map[Token_typedef] = Command_typedef;
            map[Token_union] = Command_union;
            map[Token_until] = Command_until;
            map[Token_var] = Command_var;
            map[Token_verbatim] = Command_verbatim;
            map[Token_verbinclude] = Command_verbinclude;
            map[Token_version] = Command_version;
            map[Token_vhdlflow] = Command_vhdlflow;
            map[Token_warning] = Command_warning;
            map[Token_weakgroup] = Command_weakgroup;
            map[Token_xmlonly] = Command_xmlonly;
            map[Token_xrefitem] = Command_xrefitem;
            map[Token_dollar_sign] = Command_dollar_sign;
            map[Token_commercial_at] = Command_commercial_at;
            map[Token_reverse_solidus] = Command_reverse_solidus;
            map[Token_ampersand] = Command_ampersand;
            map[Token_tilde] = Command_tilde;
            map[Token_less_than_sign] = Command_less_than_sign;
            map[Token_greater_than_sign] = Command_greater_than_sign;
            map[Token_number_sign] = Command_number_sign;
            map[Token_percent_sign] = Command_percent_sign;
            map[Token_quatation_mark] = Command_quatation_mark;
            map[Token_full_stop] = Command_full_stop;
            map[Token_double_colon] = Command_double_colon;
            map[Token_broken_bar] = Command_broken_bar;
        } 
        #endregion

        #region Commands
        
        public const string Command_a = "a";
        public const string Command_addindex = "addindex";
        [Pattern(@"^*(?<DoxygenCommand>[@\\]addtogroup)\s+(?<DoxygenCommandArgOne>\w+\b)?\s+(?<DoxygenCommandArgTwo>\w+\b)?")]
        public const string Command_addtogroup = "addtogroup";
        public const string Command_anchor = "anchor";
        public const string Command_arg = "arg";
        public const string Command_attention = "attention";
        public const string Command_author = "author";
        public const string Command_authors = "authors";
        public const string Command_b = "b";
        public const string Command_brief = "brief";
        public const string Command_bug = "bug";
        public const string Command_c = "c";
        [Pattern(@"^*(?<DoxygenCommand>[@\\]callgraph)\b")]
        public const string Command_callgraph = "callgraph";
        [Pattern(@"^*(?<DoxygenCommand>[@\\]callergraph)\b")]
        public const string Command_callergraph = "callergraph";
         [Pattern(@"^*(?<DoxygenCommand>[@\\]category)\s+(?<DoxygenCommandArgOne>\w+\b)?\s+(?<DoxygenCommandArgTwo>[\w.-]+\b)?\s+(?<DoxygenCommandArgThree" + ">\"" + @"?[\w/\\.-]+\b" + "\"?)?")]
        public const string Command_category = "category";
        public const string Command_cite = "cite";
        public const string Command_class = "class";
        public const string Command_code = "code";
        public const string Command_cond = "cond";
        public const string Command_copybrief = "copybrief";
        public const string Command_copydetails = "copydetails";
        public const string Command_copydoc = "copydoc";
        public const string Command_copyright = "copyright";
        public const string Command_date = "date";
        public const string Command_def = "def";
        public const string Command_defgroup = "defgroup";
        public const string Command_deprecated = "deprecated";
        public const string Command_details = "details";
        public const string Command_dir = "dir";
        public const string Command_docbookonly = "docbookonly";
        public const string Command_dontinclude = "dontinclude";
        public const string Command_dot = "dot";
        public const string Command_dotfile = "dotfile";
        public const string Command_e = "e";
        public const string Command_else = "else";
        public const string Command_elseif = "elseif";
        public const string Command_em = "em";
        public const string Command_endcode = "endcode";
        public const string Command_endcond = "endcond";
        public const string Command_enddocbookonly = "enddocbookonly";
        public const string Command_enddot = "enddot";
        public const string Command_endhtmlonly = "endhtmlonly";
        public const string Command_endif = "endif";
        public const string Command_endinternal = "endinternal";
        public const string Command_endlatexonly = "endlatexonly";
        public const string Command_endlink = "endlink";
        public const string Command_endmanonly = "endmanonly";
        public const string Command_endmsc = "endmsc";
        public const string Command_endrtfonly = "endrtfonly";
        public const string Command_endsecreflist = "endsecreflist";
        public const string Command_endverbatim = "endverbatim";
        public const string Command_endxmlonly = "endxmlonly";
        public const string Command_enum = "enum";
        public const string Command_example = "example";
        public const string Command_exception = "exception";
        public const string Command_extends = "extends";
        public const string Command_f_dollar_sign = "f$";
        public const string Command_f_left_square_bracket = "f[";
        public const string Command_f_right_square_bracket = "f]";
        public const string Command_f_left_curly_bracket = "f{";
        public const string Command_f_right_curly_bracket = "f}";
        public const string Command_file = "file";
        public const string Command_fn = "fn";
        public const string Command_headerfile = "headerfile";
        public const string Command_hideinitializer = "hideinitializer";
        public const string Command_htmlinclude = "htmlinclude";
        public const string Command_htmlonly = "htmlonly";
        public const string Command_idlexcept = "idlexcept";
        public const string Command_if = "if";
        public const string Command_ifnot = "ifnot";
        public const string Command_image = "image";
        public const string Command_implements = "implements";
        public const string Command_include = "include";
        public const string Command_includelineno = "includelineno";
        public const string Command_ingroup = "ingroup";
        public const string Command_internal = "internal";
        public const string Command_invariant = "invariant";
        public const string Command_interface = "interface";
        public const string Command_latexonly = "latexonly";
        public const string Command_li = "li";
        public const string Command_line = "line";
        public const string Command_link = "link";
        public const string Command_mainpage = "mainpage";
        public const string Command_manonly = "manonly";
        public const string Command_memberof = "memberof";
        public const string Command_msc = "msc";
        public const string Command_mscfile = "mscfile";
        public const string Command_n = "n";
        public const string Command_name = "name";
        public const string Command_namespace = "namespace";
        public const string Command_nosubgrouping = "nosubgrouping";
        public const string Command_note = "note";
        public const string Command_overload = "overload";
        public const string Command_p = "p";
        public const string Command_package = "package";
        public const string Command_page = "page";
        public const string Command_par = "par";
        public const string Command_paragraph = "paragraph";
        public const string Command_param = "param";
        public const string Command_post = "post";
        public const string Command_pre = "pre";
        public const string Command_private = "private";
        public const string Command_privatesection = "privatesection";
        public const string Command_property = "property";
        public const string Command_protected = "protected";
        public const string Command_protectedsection = "protectedsection";
        public const string Command_protocol = "protocol";
        public const string Command_public = "public";
        public const string Command_publicsection = "publicsection";
        public const string Command_pure = "pure";
        public const string Command_ref = "ref";
        public const string Command_refitem = "refitem";
        public const string Command_related = "related";
        public const string Command_relates = "relates";
        public const string Command_relatedalso = "relatedalso";
        public const string Command_relatesalso = "relatesalso";
        public const string Command_remark = "remark";
        public const string Command_remarks = "remarks";
        public const string Command_result = "result";
        public const string Command_return = "return";
        public const string Command_returns = "returns";
        public const string Command_retval = "retval";
        public const string Command_rtfonly = "rtfonly";
        public const string Command_sa = "sa";
        public const string Command_secreflist = "secreflist";
        public const string Command_section = "section";
        public const string Command_see = "see";
        public const string Command_short = "short";
        public const string Command_showinitializer = "showinitializer";
        public const string Command_since = "since";
        public const string Command_skip = "skip";
        public const string Command_skipline = "skipline";
        public const string Command_snippet = "snippet";
        public const string Command_struct = "struct";
        public const string Command_subpage = "subpage";
        public const string Command_subsection = "subsection";
        public const string Command_subsubsection = "subsubsection";
        public const string Command_tableofcontents = "tableofcontents";
        public const string Command_test = "test";
        public const string Command_throw = "throw";
        public const string Command_throws = "throws";
        public const string Command_todo = "todo";
        public const string Command_tparam = "tparam";
        public const string Command_typedef = "typedef";
        public const string Command_union = "union";
        public const string Command_until = "until";
        public const string Command_var = "var";
        public const string Command_verbatim = "verbatim";
        public const string Command_verbinclude = "verbinclude";
        public const string Command_version = "version";
        public const string Command_vhdlflow = "vhdlflow";
        public const string Command_warning = "warning";
        public const string Command_weakgroup = "weakgroup";
        public const string Command_xmlonly = "xmlonly";
        public const string Command_xrefitem = "xrefitem";
        public const string Command_dollar_sign = "$";
        public const string Command_commercial_at = "@";
        public const string Command_reverse_solidus = "\\";
        public const string Command_ampersand = "&";
        public const string Command_tilde = "~";
        public const string Command_less_than_sign = "<";
        public const string Command_greater_than_sign = ">";
        public const string Command_number_sign = "#";
        public const string Command_percent_sign = "%";
        public const string Command_quatation_mark = "\"";
        public const string Command_full_stop = ".";
        public const string Command_double_colon = "::";
        public const string Command_broken_bar = "|";
        #endregion

        #region Tokens
        public const int Token_a = 0;
        public const int Token_addindex = 1;
        public const int Token_addtogroup = 2;
        public const int Token_anchor = 3;
        public const int Token_arg = 4;
        public const int Token_attention = 5;
        public const int Token_author = 6;
        public const int Token_authors = 7;
        public const int Token_b = 8;
        public const int Token_brief = 9;
        public const int Token_bug = 10;
        public const int Token_c = 11;
        public const int Token_callgraph = 12;
        public const int Token_callergraph = 13;
        public const int Token_category = 14;
        public const int Token_cite = 15;
        public const int Token_class = 16;
        public const int Token_code = 17;
        public const int Token_cond = 18;
        public const int Token_copybrief = 19;
        public const int Token_copydetails = 20;
        public const int Token_copydoc = 21;
        public const int Token_copyright = 22;
        public const int Token_date = 23;
        public const int Token_def = 24;
        public const int Token_defgroup = 25;
        public const int Token_deprecated = 26;
        public const int Token_details = 27;
        public const int Token_dir = 28;
        public const int Token_docbookonly = 29;
        public const int Token_dontinclude = 30;
        public const int Token_dot = 31;
        public const int Token_dotfile = 32;
        public const int Token_e = 33;
        public const int Token_else = 34;
        public const int Token_elseif = 35;
        public const int Token_em = 36;
        public const int Token_endcode = 37;
        public const int Token_endcond = 38;
        public const int Token_enddocbookonly = 39;
        public const int Token_enddot = 40;
        public const int Token_endhtmlonly = 41;
        public const int Token_endif = 42;
        public const int Token_endinternal = 43;
        public const int Token_endlatexonly = 44;
        public const int Token_endlink = 45;
        public const int Token_endmanonly = 46;
        public const int Token_endmsc = 47;
        public const int Token_endrtfonly = 48;
        public const int Token_endsecreflist = 49;
        public const int Token_endverbatim = 50;
        public const int Token_endxmlonly = 51;
        public const int Token_enum = 52;
        public const int Token_example = 53;
        public const int Token_exception = 54;
        public const int Token_extends = 55;
        public const int Token_f_dollar_sign = 56;
        public const int Token_f_left_square_bracket = 57;
        public const int Token_f_right_square_bracket = 58;
        public const int Token_f_left_curly_bracket = 59;
        public const int Token_f_right_curly_bracket = 60;
        public const int Token_file = 61;
        public const int Token_fn = 62;
        public const int Token_headerfile = 63;
        public const int Token_hideinitializer = 64;
        public const int Token_htmlinclude = 65;
        public const int Token_htmlonly = 66;
        public const int Token_idlexcept = 67;
        public const int Token_if = 68;
        public const int Token_ifnot = 69;
        public const int Token_image = 70;
        public const int Token_implements = 71;
        public const int Token_include = 72;
        public const int Token_includelineno = 73;
        public const int Token_ingroup = 74;
        public const int Token_internal = 75;
        public const int Token_invariant = 76;
        public const int Token_interface = 77;
        public const int Token_latexonly = 78;
        public const int Token_li = 79;
        public const int Token_line = 80;
        public const int Token_link = 81;
        public const int Token_mainpage = 82;
        public const int Token_manonly = 83;
        public const int Token_memberof = 84;
        public const int Token_msc = 85;
        public const int Token_mscfile = 86;
        public const int Token_n = 87;
        public const int Token_name = 88;
        public const int Token_namespace = 89;
        public const int Token_nosubgrouping = 90;
        public const int Token_note = 91;
        public const int Token_overload = 92;
        public const int Token_p = 93;
        public const int Token_package = 94;
        public const int Token_page = 95;
        public const int Token_par = 96;
        public const int Token_paragraph = 97;
        public const int Token_param = 98;
        public const int Token_post = 99;
        public const int Token_pre = 100;
        public const int Token_private = 101;
        public const int Token_privatesection = 102;
        public const int Token_property = 103;
        public const int Token_protected = 104;
        public const int Token_protectedsection = 105;
        public const int Token_protocol = 106;
        public const int Token_public = 107;
        public const int Token_publicsection = 108;
        public const int Token_pure = 109;
        public const int Token_ref = 110;
        public const int Token_refitem = 111;
        public const int Token_related = 112;
        public const int Token_relates = 113;
        public const int Token_relatedalso = 114;
        public const int Token_relatesalso = 115;
        public const int Token_remark = 116;
        public const int Token_remarks = 117;
        public const int Token_result = 118;
        public const int Token_return = 119;
        public const int Token_returns = 120;
        public const int Token_retval = 121;
        public const int Token_rtfonly = 122;
        public const int Token_sa = 123;
        public const int Token_secreflist = 124;
        public const int Token_section = 125;
        public const int Token_see = 126;
        public const int Token_short = 127;
        public const int Token_showinitializer = 128;
        public const int Token_since = 129;
        public const int Token_skip = 130;
        public const int Token_skipline = 131;
        public const int Token_snippet = 132;
        public const int Token_struct = 133;
        public const int Token_subpage = 134;
        public const int Token_subsection = 135;
        public const int Token_subsubsection = 136;
        public const int Token_tableofcontents = 137;
        public const int Token_test = 138;
        public const int Token_throw = 139;
        public const int Token_throws = 140;
        public const int Token_todo = 141;
        public const int Token_tparam = 142;
        public const int Token_typedef = 143;
        public const int Token_union = 144;
        public const int Token_until = 145;
        public const int Token_var = 146;
        public const int Token_verbatim = 147;
        public const int Token_verbinclude = 148;
        public const int Token_version = 149;
        public const int Token_vhdlflow = 150;
        public const int Token_warning = 151;
        public const int Token_weakgroup = 152;
        public const int Token_xmlonly = 153;
        public const int Token_xrefitem = 154;
        public const int Token_dollar_sign = 155;
        public const int Token_commercial_at = 156;
        public const int Token_reverse_solidus = 157;
        public const int Token_ampersand = 158;
        public const int Token_tilde = 159;
        public const int Token_less_than_sign = 160;
        public const int Token_greater_than_sign = 161;
        public const int Token_number_sign = 162;
        public const int Token_percent_sign = 163;
        public const int Token_quatation_mark = 164;
        public const int Token_full_stop = 165;
        public const int Token_double_colon = 166;
        public const int Token_broken_bar = 167;

        public const int Token_unknown = -1;
        #endregion
    }
}